using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ClientLibrary;
using ClientLibrary.BaseInfo;
using System.Threading;
using Microsoft.Win32;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Client
{
    public partial class MainForm : Form
    {

        public static IPAddress address;
        public const int port = 1008;

        public static int controlPort = 10080;
        public static int screenPort = 10081;
        public static int videoPort = 10082;
        public static int filePort = 10083;
        public static int chatPort = 10084;
        public static int awakePort = 10085;
        public static int commandPort = 10086;
        public static int PushScreenPort = 10087;

        public static IPAddress selectAddress;
        public static int seleceHostIndex = 0;

        public static List<HostList> hostList = new List<HostList>();
        public static int hostCount = 0;


        //控制连接
        public static TcpClient controlClient;
        public static NetworkStream controlNetworkStream;
        public static Thread controlThread;
        public static bool controlConnected = false;


        //扫描主机
        Socket socket;

        //文件管理
        int last_MoseHoverIndex = -1;
        public static bool cancled = false;
        private static string pasteFileName = "";
        private static bool isReadyToCopy = false;
        TreeNode selectedTreeNode;

        //推送桌面

        PushScreen pushScreen;

        public MainForm()
        {
            InitializeComponent();
            init();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            Thread scanThread = new Thread(Scan);
            scanThread.IsBackground = true;
            scanThread.Start();
        }


        /// <summary>
        /// 初始化变量
        /// </summary>
        public void init()
        {
            comboBoxCurrentHost.SelectedIndex = 0;

            buttonDisconnect.Enabled = false;

            this.statusBarPanelStatus.Text = "连接状态：未连接";

            selectAddress = IPAddress.Parse(comboBoxCurrentHost.Text.Split('(', ')')[1]);

            address = selectAddress;

            //文件管理
            ThreadPool.SetMaxThreads(5, 5);
            toolStripButtonPaste.Enabled = false;


            //推送桌面
            pushScreen = new PushScreen();
        }


        /// <summary>
        /// 扫描已经开启服务的远程主机。
        /// </summary>
        public void Scan()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, 1008);
            EndPoint endPoint = (EndPoint)ipEndPoint;
            socket.Bind(endPoint);

            while (true)
            {
                byte[] data = new byte[1024];
                socket.ReceiveFrom(data, ref endPoint);

                #region 格式化接收的数据
                string[] receiveMessage = Encoding.Unicode.GetString(data).Split(',');
                string hostAddress = receiveMessage[0];
                string location = receiveMessage[1];
                string hostName = receiveMessage[2];
                string userName = receiveMessage[3];
                string osName = receiveMessage[4];
                string cpuType = receiveMessage[5];
                string memorySize = receiveMessage[6];
                string hardDiskSize = receiveMessage[7];
                string screenSize = receiveMessage[8];
                string videoStatus = receiveMessage[9];
                string connectStatus = receiveMessage[10];
                #endregion

              //  string listName = "List" + hostAddress;

              // HostList temp = new HostList(IPAddress.Parse(hostAddress), location, hostName, userName, osName, cpuType, memorySize, hardDiskSize, screenSize, videoStatus);
                HostList temp;

                if (connectStatus.Equals("连接"))
                {
                    temp = new HostList(IPAddress.Parse(hostAddress), location, hostName, userName, osName, cpuType, memorySize, hardDiskSize, screenSize, videoStatus);
                    if (!hostList.Contains(temp))
                    {
                        hostList.Add(temp);
                    }
                }
                else if (connectStatus.Equals("断开"))
                {
                    for (int i = 0; i < hostList.Count; i++)
                    {
                        if (hostList[i].HostAddress.Equals(IPAddress.Parse(hostAddress)))
                        {
                            hostList.RemoveAt(i);
                        }
                    }
                }

                hostCount = hostList.Count;
                //刷新状态栏
                string text = "上线主机：" + hostCount;
                setStatusBarPanelHostCountText(text);
                //刷新在线主机
                refreshComboBoxCurrentHost();
                refreshListViewOnlineHost();
            }
        }


        /// <summary>
        /// 刷新状态栏在线主机数目
        /// </summary>
        /// <param name="text"></param>
        private delegate void setStatusBarPanelHostCountTextDelegate(string text);
        private void setStatusBarPanelHostCountText(string text)
        {
            if (statusBar.InvokeRequired)
            {
                setStatusBarPanelHostCountTextDelegate d = new setStatusBarPanelHostCountTextDelegate(setStatusBarPanelHostCountText);
                this.Invoke(d, text);
            }
            else
            {
                statusBarPanelHostCount.Text = text;
            }
        }


        /// <summary>
        /// 刷新在线主机列表
        /// </summary>
        private delegate void refreshListViewOnlineHostDelegate();
        private void refreshListViewOnlineHost()
        {
            if (listViewOnlineHost.InvokeRequired)
            {
                refreshListViewOnlineHostDelegate d = new refreshListViewOnlineHostDelegate(refreshListViewOnlineHost);
                this.Invoke(d);
            }
            else
            {
                listViewOnlineHost.Items.Clear();

                foreach (HostList item in hostList)
                {
                    ListViewItem listViewItem = new ListViewItem();

                    listViewItem.Text = item.HostAddress.ToString();
                    listViewItem.SubItems.Add(item.Location);
                    listViewItem.SubItems.Add(item.HostName);
                    listViewItem.SubItems.Add(item.UserName);
                    listViewItem.SubItems.Add(item.OsName);
                    listViewItem.SubItems.Add(item.CpuType);
                    listViewItem.SubItems.Add(item.MemorySize);
                    listViewItem.SubItems.Add(item.HardDiskSize);
                    listViewItem.SubItems.Add(item.ScreenSize);
                    listViewItem.SubItems.Add(item.VideoStatus);

                    listViewOnlineHost.Items.Add(listViewItem);
                }


            }
        }


        /// <summary>
        /// 刷新在线主机下拉列表
        /// </summary>
        private delegate void refreshComboBoxCurrentHostDelegate();
        private void refreshComboBoxCurrentHost()
        {

            if (comboBoxCurrentHost.InvokeRequired)
            {

                refreshComboBoxCurrentHostDelegate d = new refreshComboBoxCurrentHostDelegate(refreshComboBoxCurrentHost);
                this.Invoke(d);
            }
            else
            {
                comboBoxCurrentHost.Items.Clear();
                comboBoxCurrentHost.Items.Add("localhost(127.0.0.1)");
                foreach (HostList item in hostList)
                {
                    comboBoxCurrentHost.Items.Add(item.HostName + "(" + item.HostAddress + ")");
                }
                try
                {
                    comboBoxCurrentHost.SelectedIndex = seleceHostIndex;
                }
                catch
                {
                    comboBoxCurrentHost.SelectedIndex = 0;
                }
            }
        }


        /// <summary>
        /// 显示、隐藏文件管理面板左侧的树形结构面板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonHideDisplay_Click(object sender, EventArgs e)
        {
            if (!this.splitContainerFileManage.Panel1Collapsed)
            {
                this.splitContainerFileManage.Panel1Collapsed = true;
                toolStripButtonHideDisplay.Image = imageListFileManage.Images[1];
                toolStripButtonHideDisplay.ToolTipText = "显示";
            }
            else
            {
                this.splitContainerFileManage.Panel1Collapsed = false;
                toolStripButtonHideDisplay.Image = imageListFileManage.Images[0];
                toolStripButtonHideDisplay.ToolTipText = "隐藏";
            }
        }


        /// <summary>
        /// 菜单栏点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == ToolStripMenuItemSystemSetting)
            {

            }
        }


        /// <summary>
        /// 工具栏点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            if (e.Button == toolBarButtonPushScreen)
            {
                if (toolBarButtonPushScreen.Text == "推送桌面")
                {
                    SendControl("PushScreen");
                    pushScreen.Start();

                    toolBarButtonPushScreen.Text = "停止推送";
                }
                else
                {
                    toolBarButtonPushScreen.Text = "推送桌面";
                    SendControl("PushScreen Closed");
                    pushScreen.Stop();
                }

            }
            else if (controlConnected)
            {
                if (e.Button == toolBarButtonRemote)
                {
                    ScreenForm screenForm = new ScreenForm();
                    screenForm.ShowDialog();

                }
                else if (e.Button == toolBarButtonVideo)
                {
                    VideoForm videoForm = new VideoForm();
                    videoForm.ShowDialog();
                }
                else if (e.Button == toolBarButtonCommand)
                {
                    CommandForm commandForm = new CommandForm();
                    commandForm.ShowDialog();
                }
                else if (e.Button == toolBarButtonFileManage)
                {
                    if (!Clients.isThread_FileManageStarted)
                    {
                        Clients.thread_FileMange = new Thread(FileManagementConnection);
                        Clients.thread_FileMange.Start();
                        Clients.isThread_FileManageStarted = true;
                    }
                    tabControl.SelectedTab = this.tabPageFileManage;
                }
                else if (e.Button == toolBarButtonChat)
                {
                    ChatForm chatForm = new ChatForm();
                    chatForm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("请先连接远程主机");
            }
        }


        /// <summary>
        /// 主标签切换触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 连接远程主机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonConnect_Click(object sender, EventArgs e)
        {
            buttonConnect.Enabled = false;
            buttonDisconnect.Enabled = true;

            this.statusBarPanelStatus.Text = "连接状态：正在连接";

            address = selectAddress;

            try
            {
                controlClient = new TcpClient();
                controlClient.Connect(address, controlPort);

                controlConnected = true;

                this.statusBarPanelStatus.Text = "连接状态：已连接";

                controlNetworkStream = controlClient.GetStream();

                SendControl("Connect");

                controlThread = new Thread(ReceiveControl);
                controlThread.Start();

            }
            catch
            {
                controlConnected = false;
                this.statusBarPanelStatus.Text = "连接状态：连接失败";
                buttonConnect.Enabled = true;
                buttonDisconnect.Enabled = false;
                return;
            }
        }


        /// <summary>
        /// 窗口关闭断开连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!controlConnected)
            {
                this.Disconnect();
            }
        }


        #region 文件管理：连接文件管理
        /// <summary>
        /// 连接文件管理
        /// </summary>
        private void FileManagementConnection()
        {
            treeViewDir.ImageList = imageListTreeView;
            listViewFile.SmallImageList = imageListListView;
            SendControl("FileManage");
            while (true)
            {
                try
                {
                    //打开文件管理连接
                    if (!Clients.isFile_ManageConnected)
                    {
                        Clients.file_FileManageClient = new TcpClient();
                        Clients.file_FileManageClient.Connect(selectAddress, Clients.filePort);
                        Clients.isFile_ManageConnected = true;
                        break;
                    }
                }
                catch
                {
                    break;
                }
            }
            while (true)
            {
                try
                {
                    //打开文件操作连接
                    if (!Clients.isFile_OperationConnected)
                    {
                        Clients.file_OperationClient = new TcpClient();
                        Clients.file_OperationClient.Connect(selectAddress, Clients.fileOperationPort);
                        Clients.isFile_OperationConnected = true;
                        break;
                    }
                }
                catch
                {
                    break;
                }
            }
            if (!Clients.isThread_ReceiveDrivesInfoStarted)
            {
                Clients.file_FileManageNetSream = Clients.file_FileManageClient.GetStream();
                Clients.thread_ReceiveDrivesInfo = new Thread(ReceiveDrivesInfo);
                Clients.thread_ReceiveDrivesInfo.Start();
                Clients.isThread_ReceiveDrivesInfoStarted = true;
            }
            if (!Clients.isThread_FileOperationStarted)
            {
                Clients.file_OperationNetStream = Clients.file_OperationClient.GetStream();
                //Clients.thread_FileOperation = new Thread(ReceiveFileOperationStatusInfo);
                //Clients.thread_FileOperation.Start();
                Clients.isThread_FileOperationStarted = true;
                Clients.sw_op = new StreamWriter(Clients.file_OperationNetStream);
                Clients.sr_op = new StreamReader(Clients.file_OperationNetStream);

            }
        }

        #endregion


        #region 文件管理

        private void Send_forCreatNode(TreeNode node)
        {
            selectedTreeNode = node;
            string nodeMsg = selectedTreeNode.Text.ToString();
            if (nodeMsg.Contains("(不可访问)"))
            {
                nodeMsg.Replace("(不可访问)", "");
            }
            byte[] path = Encoding.Unicode.GetBytes(nodeMsg);
            int bufferSize = Clients.file_FileManageClient.SendBufferSize;
            int left = path.Length;
            int startIndex = 0;
            while (left > 0)
            {
                if (left > bufferSize)
                    Clients.file_FileManageNetSream.Write(path, startIndex, bufferSize);
                else
                    Clients.file_FileManageNetSream.Write(path, startIndex, left);

                startIndex += bufferSize;
                left -= bufferSize;
            }
        }

        private void Send_forFileOperation(string opMsg)
        {
            Clients.sw_op.WriteLine(opMsg);
            Clients.sw_op.Flush();
        }

        /// <summary>
        /// 获得服务器返回的分区信息
        /// </summary>
        private void ReceiveDrivesInfo()
        {

            MemoryStream ms = new MemoryStream();
            int bufferSize = Clients.file_FileManageClient.ReceiveBufferSize;
            byte[] buffer = new byte[bufferSize];
            int read = 0;
            while (true)
            {
                read = Clients.file_FileManageNetSream.Read(buffer, 0, bufferSize);
                if (read > 0)
                {
                    ms.Write(buffer, 0, bufferSize);
                    if (read < bufferSize)
                    {
                        IFormatter formatter = new BinaryFormatter();
                        ms.Position = 0;//在反序列化的时候，需要先把流的指针位置重新设置到0
                        TreeNode nodeDir = (TreeNode)formatter.Deserialize(ms); //反序列化
                        ms.Close();
                        InitTreeView(nodeDir);
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// 获得服务器返回的目录信息
        /// </summary>
        private void ReceiveNodesInfo()
        {
            MemoryStream ms = new MemoryStream();
            int bufferSize = Clients.file_FileManageClient.ReceiveBufferSize;
            byte[] buffer = new byte[bufferSize];
            int read = 0;
            while (true)
            {
                read = Clients.file_FileManageNetSream.Read(buffer, 0, bufferSize);
                ms.Write(buffer, 0, read);
                if (read < bufferSize)
                {
                    //反序列化
                    IFormatter formatter = new BinaryFormatter();
                    ms.Position = 0;//在反序列化的时候，需要先把流的指针位置重新设置到0
                    TreeNode nodeDir = null;
                    try
                    {
                        nodeDir = (TreeNode)formatter.Deserialize(ms);
                    }
                    catch
                    {
                        ms.Position = 0;
                        continue;
                    }
                    if (!nodeDir.Tag.Equals("ReadOnly"))
                    {
                        ListViewShow(nodeDir);
                        AddNode(nodeDir);
                    }
                    else if (nodeDir.Tag.Equals("ReadOnly"))
                        ChangeNodeText();
                    ms = new MemoryStream();
                    ms.Position = 0;
                }
            }
        }


        /// <summary>
        /// 获得服务器返回的文件操作信息
        /// </summary>        
        private bool ReceiveAnswer()
        {
            bool answer = false;
            //Clients.sr_op = new StreamReader(Clients.file_OperationNetStream);
            string receiveMsg = "";
            //while(true)
            {
                receiveMsg = Clients.sr_op.ReadLine();
                switch (receiveMsg)
                {
                    case "success":
                        answer = true;
                        break;
                    case "fail":
                        answer = false;
                        break;
                    case "ok":
                        answer = true;
                        break;
                    case "no":
                        answer = false;
                        break;
                }
            }
            return answer;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool ReceiveRenameAnswer()
        {
            bool answer = false;
            string receiveMsg = "";
            receiveMsg = Clients.sr_op.ReadLine();
            string[] splitStr = receiveMsg.Split(',');

            switch (splitStr[0])
            {
                case "success":
                    MessageBox.Show("重命名成功！");
                    answer = true;
                    break;
                case "fail":
                    MessageBox.Show(splitStr[1]);
                    break;
            }
            return answer;
        }

        #endregion


        #region 文件管理 TreeView操作

        private delegate void InitTreeViewDelegate(object obj);
        /// <summary>
        /// 初始化TreeViewFile
        /// </summary>
        /// <param name="obj">用于初始化的结点</param>
        public void InitTreeView(object obj)
        {
            TreeNode node = (TreeNode)obj;
            if (treeViewDir.InvokeRequired)
            {
                InitTreeViewDelegate d = InitTreeView;
                treeViewDir.Invoke(d, obj);
            }
            else
                treeViewDir.Nodes.Add(node);
        }


        /// <summary>
        /// 选中某个结点时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeViewFile_AfterSelect(object sender, TreeViewEventArgs e)
        {

            if (!Clients.isThread_ReceiveNodesInfoStarted)
            {
                Clients.thread_ReceiveNodesInfo = new Thread(ReceiveNodesInfo);
                Clients.thread_ReceiveNodesInfo.Start();
                Clients.isThread_ReceiveNodesInfoStarted = true;
            }
            ///!!!!!!!!!!comboBoxCurrentHost.SelectedItem,提醒修改!!!!!!!!!!!!!////////////////////////////////
            if (e.Node.Text != comboBoxCurrentHost.SelectedItem.ToString().Split('(', ')')[0])
            {
                Send_forCreatNode(e.Node);
                NodeStack.nodeStack.Push(e.Node);
                NodeStack.curNode = e.Node;
                toolStripTextBoxCurDir.Text = e.Node.Text;

            }
        }

        /// <summary>
        /// 向被选中节点添加子节点（委托）
        /// </summary>
        /// <param name="obj"></param>
        private delegate void AddNodeDelegate(object obj);
        private void AddNode(object obj)
        {
            TreeNode treeNode = (TreeNode)obj;
            if (treeViewDir.InvokeRequired)
            {
                AddNodeDelegate d = AddNode;
                treeViewDir.Invoke(d, obj);
            }
            else
            {
                selectedTreeNode.Nodes.Clear();
                foreach (TreeNode node in treeNode.Nodes)
                {
                    string[] info = node.Tag.ToString().Split(',');
                    if (info[0] != "file")
                    {
                        selectedTreeNode.Nodes.Add(node);
                        node.ImageIndex = 0;
                    }
                }
                selectedTreeNode.Expand();
                //treeNode.Expand();
            }
        }
        private delegate void ChaneItemColorDelegate(object obj);
        private void ChangeItemColor(object obj)
        {

            int curIndex = (int)obj;
            if (listViewFile.InvokeRequired)
            {
                ChaneItemColorDelegate d = ChangeItemColor;
                listViewFile.Invoke(d, curIndex);
            }
            else
            {
                if (last_MoseHoverIndex >= 0)
                {
                    try
                    {
                        listViewFile.Items[last_MoseHoverIndex].BackColor = Color.White;
                        if (listViewFile.Items[curIndex].BackColor != Color.LightGray)
                            listViewFile.Items[curIndex].BackColor = Color.Pink;
                    }
                    catch
                    {

                    }

                }
                last_MoseHoverIndex = curIndex;
            }
        }
        private delegate void ChangeNodeTextDelegate();
        private void ChangeNodeText()
        {
            if (treeViewDir.InvokeRequired)
            {
                ChangeNodeTextDelegate d = ChangeNodeText;
                treeViewDir.Invoke(d);
            }
            else
            {
                selectedTreeNode.Text += "(不可访问)";
                listViewFile.Items.Clear();
            }
        }
        private void treeViewDir_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Checked)
            {
                e.Node.Checked = false;
                e.Node.Collapse();
            }
        }
        private void treeViewDir_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            e.Node.Checked = false;
        }
        private void treeViewDir_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Text != Dns.GetHostName() && toolStripTextBoxCurDir.Text != ""
                && e.Node.Text.Substring(0, 1) == toolStripTextBoxCurDir.Text.Substring(0, 1))
            {
                Send_forCreatNode(e.Node);
            }
        }

        #endregion


        #region 文件管理 ListView操作
        /// <summary>
        /// 向listViewFile中添加显示内容（委托）
        /// </summary>
        private delegate void ListViewShowDelegate(object obj);
        private void ListViewShow(object obj)
        {
            TreeNode tempNode = (TreeNode)obj;
            if (listViewFile.InvokeRequired)
            {
                ListViewShowDelegate d = ListViewShow;
                this.listViewFile.Invoke(d, obj);
            }
            else
            {
                this.listViewFile.Items.Clear();
                toolStripTextBoxCurDir.Text = tempNode.Text;
                foreach (TreeNode node in tempNode.Nodes)
                {
                    ListViewItem newItem = null;
                    string temp = null;
                    int index = node.Text.LastIndexOf("\\");
                    string[] info = node.Tag.ToString().Split(',');
                    int fileName_length = node.Text.ToString().Length;
                    if (info.Length > 1)
                    {
                        if (info[0] == "file")
                        {
                            temp = "  " + node.Text.Substring(index + 1, fileName_length - index - 1);
                            newItem = new ListViewItem(temp);
                        }
                        else if (info[0] == "directory")
                        {
                            temp = node.Text.Substring(index + 1, fileName_length - index - 1);
                            newItem = new ListViewItem(temp);
                        }
                        newItem = new ListViewItem(node.Text.Substring(index + 1, fileName_length - index - 1));
                        newItem.SubItems.Add(info[1]);
                        newItem.SubItems.Add(info[2]);
                        newItem.SubItems.Add(info[3]);

                        listViewFile.Items.Add(newItem);
                    }
                    else
                    {
                        ListViewItem item = new ListViewItem(node.Text.Substring(index + 1, fileName_length - index - 1));
                        listViewFile.Items.Add(item);
                    }
                }
            }
        }
        private void listViewFile_DoubleClick(object sender, EventArgs e)
        {
            string path = toolStripTextBoxCurDir.Text + "\\";
            string temp = "";
            int selectedIndex = -1;
            foreach (int index in listViewFile.SelectedIndices)
            {
                temp = listViewFile.Items[index].SubItems[0].Text;
                if (temp != "")
                {
                    path += temp;
                    selectedIndex = index;
                }
            }

            //TreeNode node = new TreeNode(path);
            //Send_forCreatNode(node);
            toolStripTextBoxCurDir.Text = path;
            if (selectedIndex >= 0 && selectedIndex < selectedTreeNode.Nodes.Count)//如果双击的是文件夹
            {
                NodeStack.nodeStack.Push(selectedTreeNode.Nodes[selectedIndex]);
                NodeStack.curNode = selectedTreeNode.Nodes[selectedIndex];
                selectedTreeNode = selectedTreeNode.Nodes[selectedIndex];
                Send_forCreatNode(selectedTreeNode);
            }

        }
        /// <summary>
        /// 移动鼠标改变item背景色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewFile_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {
            //toolTipListViewFile.Active = true;
            //toolTipListViewFile.SetToolTip(listViewFile, toolStripTextBoxCurDir.Text + e.Item.ToString());
            ThreadPool.QueueUserWorkItem(new WaitCallback(ChangeItemColor), e.Item.Index);

        }
        #endregion


        private void tabControl_Selected(object sender, TabControlEventArgs e)
        {
            if (!controlClient.Connected)
            {
                MessageBox.Show("请先连接远程主机！");
            }
            if (!Clients.isThread_FileManageStarted)
            {
                Clients.thread_FileMange = new Thread(FileManagementConnection);
                Clients.thread_FileMange.Start();
                Clients.isThread_FileManageStarted = true;
            }
        }


        #region 文件管理菜单栏事件

        private void toolStripButtonBack_Click(object sender, EventArgs e)
        {
            TreeNode node = null;
            try
            {
                node = NodeStack.nodeStack.Pop();
                if (node.Text == NodeStack.curNode.Text)
                    node = NodeStack.nodeStack.Pop();
                NodeStack.lastNode = node;
                TreeNode temp = new TreeNode(node.Text);
                Send_forCreatNode(temp);
                node.Expand();
            }
            catch
            {
                NodeStack.nodeStack.Push(NodeStack.lastNode);
                //ListViewShow(NodeStack.lastNode);
                //MessageBox.Show("");
            }
        }
        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            if (listViewFile.SelectedItems.Count == 1)
            {
                string path = toolStripTextBoxCurDir.Text + "\\";
                int index = listViewFile.SelectedIndices[0];
                path += listViewFile.Items[index].SubItems[0].Text;
                string msg = "command,Delete," + path;
                //弹出确认删除对话框
                string warnMsg = "确定要删除" + listViewFile.Items[index].SubItems[0].Text + "?";
                string caption = "删除文件";
                DialogResult yesno;
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                yesno = MessageBox.Show(warnMsg, caption, buttons);
                //确认
                if (yesno == System.Windows.Forms.DialogResult.Yes)
                {
                    Send_forFileOperation(msg);

                    if (ReceiveAnswer())
                    {
                        MessageBox.Show("删除成功");
                        if (index >= selectedTreeNode.Nodes.Count)//如果是文件
                        {
                            listViewFile.Items.RemoveAt(index);
                        }
                        else//是文件夹
                        {
                            listViewFile.Items.RemoveAt(index);
                            selectedTreeNode.Nodes.RemoveAt(index);
                        }
                    }
                    else
                    {
                        MessageBox.Show("删除失败");
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择要删除的文件或文件夹");
            }
        }
        private void toolStripButtonRename_Click(object sender, EventArgs e)
        {
            if (listViewFile.SelectedItems.Count == 1)
            {
                string dirpath = toolStripTextBoxCurDir.Text;
                int index = listViewFile.SelectedIndices[0];
                string oldName = listViewFile.Items[index].SubItems[0].Text;

                string newName = "";
                RenameBox form = new RenameBox(oldName);

                form.ShowDialog();
                while (true)
                {
                    if (cancled)
                    {
                        cancled = false;
                        break;
                    }
                    else if (RenameBox.newName != null)
                    {
                        newName = RenameBox.newName;
                        form.Close();
                        string msg = "command,ReName," + toolStripTextBoxCurDir.Text + "," + oldName + "," + newName;

                        Send_forFileOperation(msg);
                        if (ReceiveRenameAnswer())
                        {
                            //listViewFile.Items[index].SubItems[0].Text = newName;
                            //if (index < selectedTreeNode.Nodes.Count)
                            //{
                            //    selectedTreeNode.Nodes[index].Text = dirpath + newName;
                            //    selectedTreeNode.Nodes[index].Tag.ToString().Replace(oldName, newName);
                            //}
                            RefreshNode(toolStripTextBoxCurDir.Text);
                        }
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("请选择要重命名的文件或文件夹");
            }

        }
        private void toolStripButtonFind_Click(object sender, EventArgs e)
        {
            RefreshNode(toolStripTextBoxCurDir.Text);
            SearchBox form = new SearchBox();
            form.ShowDialog();
            while (true)
            {
                if (cancled)
                {
                    cancled = false;
                    form.Close();
                    break;
                }
                else if (SearchBox.searchKey != null)
                {
                    if (SearchBox.condition == false)
                    {
                        int count = 0;
                        foreach (ListViewItem item in listViewFile.Items)
                        {
                            if (item.SubItems[0].Text.Split('.')[0].Contains(SearchBox.searchKey))
                            {
                                count++;
                                item.BackColor = Color.LightGray;

                            }
                        }
                        MessageBox.Show("共找到" + count + "个文件/文件夹");
                        form.Close();
                    }
                    else if (SearchBox.condition == true)
                    {
                        bool found = false;
                        foreach (ListViewItem item in listViewFile.Items)
                        {
                            if (item.SubItems[0].Text.Split('.')[0] == SearchBox.searchKey)
                            {
                                item.BackColor = Color.LightGray;
                                MessageBox.Show("查询成功！");
                                found = true;
                                break;
                            }
                        }
                        if (!found)
                        {
                            MessageBox.Show("未查询到结果！");

                        }
                    }
                    break;
                }
            }
        }
        private void toolStripButtonDownload_Click(object sender, EventArgs e)
        {

            if (listViewFile.SelectedItems.Count == 1)
            {
                int index = listViewFile.SelectedIndices[0];
                if (index >= selectedTreeNode.Nodes.Count)//如果是文件
                {
                    string dirpath = toolStripTextBoxCurDir.Text;
                    string fileName = listViewFile.Items[index].SubItems[0].Text;
                    string path = dirpath + "\\" + fileName;
                    Send_forFileOperation("command,Download," + path);
                    while (true)
                    {
                        try
                        {
                            Clients.client_FileTransport = new TcpClient();
                            Clients.client_FileTransport.Connect(selectAddress, Clients.port_FileTransport);
                            Clients.netStream_FileTransport = Clients.client_FileTransport.GetStream();
                            break;
                        }
                        catch
                        {
                            continue;
                        }
                    }

                    string msg = Clients.sr_op.ReadLine();
                    string[] str = msg.Split(',');
                    if (str[0] == "success")//要下载的文件存在
                    {
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.FileName = fileName;   //默认保存文件的文件名
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string savePath = saveFileDialog.FileName;
                            DownloadProcessBar form = new DownloadProcessBar(savePath + "," + str[1]);
                            form.ShowDialog();
                        }
                    }
                    else
                    {
                        MessageBox.Show("要下载的文件不存在");
                    }
                }
                else//是文件夹
                {
                    MessageBox.Show("只能下载文件！");
                }
            }
            else
            {
                MessageBox.Show("请选择要下载的文件！");
            }

        }
        private void toolStripButtonUpload_Click(object sender, EventArgs e)
        {
            string chosenFilePath = null;
            OpenFileDialog chosenFileDialog = new OpenFileDialog();
            chosenFileDialog.Multiselect = false;   //禁止同时发多个文件
            if (chosenFileDialog.ShowDialog() == DialogResult.OK)
            {
                chosenFilePath = chosenFileDialog.FileName;
                FileInfo fi = new FileInfo(chosenFilePath);
                string fileName = Path.GetFileName(chosenFilePath);
                int fileSize = (int)fi.Length;
                Send_forFileOperation("command,Upload" + "," + toolStripTextBoxCurDir.Text + "\\" + fileName + "," + fileSize);
                while (true)
                {
                    try
                    {
                        Clients.client_FileTransport = new TcpClient();
                        Clients.client_FileTransport.Connect(selectAddress, Clients.port_FileTransport);
                        Clients.netStream_FileTransport = Clients.client_FileTransport.GetStream();
                        break;
                    }
                    catch
                    {
                        continue;
                    }
                }
                Thread fsThread = new Thread(SendFile);
                fsThread.Start(chosenFilePath);
                string s = Clients.sr_op.ReadLine();
                if (s == "completed")
                {
                    MessageBox.Show("文件上传完毕！");
                    RefreshNode(toolStripTextBoxCurDir.Text);
                }
                else if (s == "fail")
                {
                    MessageBox.Show("有重名文件，上传失败！");
                }

            }
        }
        private delegate void SendFileDelegate();
        private void SendFile(object obj)
        {
            string chosenFilePath = (string)obj;
            FileInfo fi = new FileInfo(chosenFilePath);
            FileStream fieSend = new FileStream(chosenFilePath, FileMode.Open, FileAccess.Read);
            int fileSize = (int)fi.Length;

            byte[] buffer = new byte[Clients.client_FileTransport.SendBufferSize];
            int len = buffer.Length;
            int left = fileSize;
            while (left > 0)
            {
                if (left > len)
                {
                    int read = fieSend.Read(buffer, 0, len);
                    Clients.netStream_FileTransport.Write(buffer, 0, read);
                    left = left - len;
                }
                else
                {
                    fieSend.Read(buffer, 0, left);
                    Clients.netStream_FileTransport.Write(buffer, 0, left);
                    left = left - len;
                }
            }
            fieSend.Close();
        }
        private void toolStripButtonRefash_Click(object sender, EventArgs e)
        {
            RefreshNode(toolStripTextBoxCurDir.Text);
        }
        private void RefreshNode(string path)
        {
            TreeNode node = new TreeNode(path);
            Send_forCreatNode(node);
        }
        private void toolStripButtonCut_Click(object sender, EventArgs e)
        {
            if (listViewFile.SelectedItems.Count == 1)
            {
                string path = toolStripTextBoxCurDir.Text + "\\";
                int index = listViewFile.SelectedIndices[0];
                path += listViewFile.Items[index].SubItems[0].Text;
                Clients.sw_op.WriteLine("command,Cut" + "," + path);
                Clients.sw_op.Flush();
                if (Clients.sr_op.ReadLine() == "Ready")
                {
                    isReadyToCopy = true;
                    toolStripButtonPaste.Enabled = true;
                    pasteFileName = listViewFile.Items[index].SubItems[0].Text;
                }
            }
            else
            {
                MessageBox.Show("请选择要剪切的文件");
            }
        }
        private void toolStripButtonPaste_Click(object sender, EventArgs e)
        {
            toolStripButtonPaste.Enabled = false;
            isReadyToCopy = false;

            string path = toolStripTextBoxCurDir.Text + "\\" + pasteFileName;
            Clients.sw_op.WriteLine("command,Paste" + "," + path);
            Clients.sw_op.Flush();

            string msg = Clients.sr_op.ReadLine();
            string[] splitStr = msg.Split(',');
            if (splitStr[0] == "success")
            {
                MessageBox.Show("剪切成功！");
                RefreshNode(toolStripTextBoxCurDir.Text);
            }
            else if (splitStr[0] == "fail")
            {
                MessageBox.Show(splitStr[1]);
            }
            pasteFileName = "";
        }
        private void txt文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewFileBox form = new NewFileBox("新建文本文档");
            form.ShowDialog();
            while (true)
            {
                if (cancled)
                {
                    cancled = false;
                    break;
                }
                else if (NewFileBox.newName != null)
                {
                    string msg = "command,NewFile,txt," + toolStripTextBoxCurDir.Text + "," + NewFileBox.newName;
                    form.Close();
                    Send_forFileOperation(msg);
                    if (Clients.sr_op.ReadLine() == "success")
                    {
                        MessageBox.Show("创建成功！");
                        RefreshNode(toolStripTextBoxCurDir.Text);
                    }
                    else
                    {
                        MessageBox.Show("创建失败！");
                    }
                    break;
                }
            }
        }
        private void word文档ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewFileBox form = new NewFileBox("新建文本文档");
            form.ShowDialog();

            while (true)
            {
                if (cancled)
                {
                    cancled = false;
                    break;
                }
                else if (NewFileBox.newName != null)
                {
                    string msg = "command,NewFile,doc," + toolStripTextBoxCurDir.Text + "," + NewFileBox.newName;
                    form.Close();
                    Send_forFileOperation(msg);
                    if (Clients.sr_op.ReadLine() == "success")
                    {
                        MessageBox.Show("创建成功！");
                        RefreshNode(toolStripTextBoxCurDir.Text);
                    }
                    else
                    {
                        MessageBox.Show("创建失败！");
                    }
                    break;
                }
            }
        }
        private void toolStripButtonNewFolder_Click(object sender, EventArgs e)
        {
            NewFileBox form = new NewFileBox("新建文件夹");
            form.ShowDialog();

            while (true)
            {
                if (cancled)
                {
                    cancled = false;
                    break;
                }
                else if (NewFileBox.newName != null)
                {
                    string msg = "command,NewFile,directory," + toolStripTextBoxCurDir.Text + "," + NewFileBox.newName;
                    form.Close();
                    Send_forFileOperation(msg);
                    if (Clients.sr_op.ReadLine() == "success")
                    {
                        MessageBox.Show("创建成功！");
                        RefreshNode(toolStripTextBoxCurDir.Text);
                    }
                    else
                    {
                        MessageBox.Show("创建失败！");
                    }
                    break;
                }
            }
        }

        #endregion


        /// <summary>
        /// 向被控端发送控制信息
        /// </summary>
        /// <param name="msg"></param>
        public static void SendControl(string msg)
        {
            byte[] buffer = Encoding.Unicode.GetBytes(msg);
            try
            {
                controlNetworkStream.Write(buffer, 0, buffer.Length);
            }
            catch
            {
                //发送失败
            }
        }


        /// <summary>
        /// 接收来自被控端的返回控制信息
        /// </summary>
        private void ReceiveControl()
        {
            byte[] buffer = new byte[1024];
            int bytesRead;
            StringBuilder message = new StringBuilder();

            while (true)
            {
                try
                {
                    bytesRead = controlNetworkStream.Read(buffer, 0, 1024);
                    message.AppendFormat("{0}", Encoding.Unicode.GetString(buffer, 0, bytesRead));


                    if (message != null)
                    {
                        Console.WriteLine(message);
                    }
                }
                catch
                {

                }
            }

        }


        /// <summary>
        /// 断开连接(控制)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            Disconnect();
        }

        /// <summary>
        /// 断开连接，关闭线程、流，修改状态栏
        /// </summary>
        private void Disconnect()
        {

            if (controlConnected)
            {
                controlClient.Close();
                controlThread.Abort();
            }

            controlConnected = false;

            this.statusBarPanelStatus.Text = "连接状态：断开连接";
            buttonConnect.Enabled = true;
            buttonDisconnect.Enabled = false;
        }


        /// <summary>
        /// 切换连接远程主机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxCurrentHost_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectAddress = IPAddress.Parse(comboBoxCurrentHost.Text.Split('(', ')')[1]);
            seleceHostIndex = comboBoxCurrentHost.SelectedIndex;
        }

    }
}