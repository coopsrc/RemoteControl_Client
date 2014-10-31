namespace Client
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.退出EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemSystemSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemView = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemFunction = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助内容CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于我们AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolBar = new System.Windows.Forms.ToolBar();
            this.toolBarButtonRemote = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton4 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonVideo = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton6 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonFileManage = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonCommand = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton8 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonChat = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton3 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonPushScreen = new System.Windows.Forms.ToolBarButton();
            this.imageListToolBar = new System.Windows.Forms.ImageList(this.components);
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.statusBarPanelLocalIP = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanelPort = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanelHostCount = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanelStatus = new System.Windows.Forms.StatusBarPanel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageRemoteHost = new System.Windows.Forms.TabPage();
            this.listViewOnlineHost = new System.Windows.Forms.ListView();
            this.columnHeaderAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderArea = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderHostName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLoginUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderOS = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCPU = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMemo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDisk = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMonitor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderVideo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStripOnlineHost = new System.Windows.Forms.ToolStrip();
            this.tabPageFileManage = new System.Windows.Forms.TabPage();
            this.toolStripFileManage = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonHideDisplay = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonNewFile = new System.Windows.Forms.ToolStripDropDownButton();
            this.txt文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.word文档ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButtonNewFolder = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonCut = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPaste = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonFind = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonUpload = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDownload = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonRename = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRefash = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBoxCurDir = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButtonBack = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonMove = new System.Windows.Forms.ToolStripButton();
            this.splitContainerFileManage = new System.Windows.Forms.SplitContainer();
            this.treeViewDir = new System.Windows.Forms.TreeView();
            this.listViewFile = new Client.ListViewDoubleBuffered();
            this.columnHeaderFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderFileSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCreateTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderChangeTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageListAll = new System.Windows.Forms.ImageList(this.components);
            this.imageListFileManage = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.comboBoxCurrentHost = new System.Windows.Forms.ComboBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.labelPort = new System.Windows.Forms.Label();
            this.labelHost = new System.Windows.Forms.Label();
            this.imageListChat = new System.Windows.Forms.ImageList(this.components);
            this.imageListListView = new System.Windows.Forms.ImageList(this.components);
            this.imageListTreeView = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelLocalIP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelHostCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelStatus)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPageRemoteHost.SuspendLayout();
            this.tabPageFileManage.SuspendLayout();
            this.toolStripFileManage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFileManage)).BeginInit();
            this.splitContainerFileManage.Panel1.SuspendLayout();
            this.splitContainerFileManage.Panel2.SuspendLayout();
            this.splitContainerFileManage.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemFile,
            this.ToolStripMenuItemSetting,
            this.ToolStripMenuItemView,
            this.ToolStripMenuItemFunction,
            this.ToolStripMenuItemHelp});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(784, 25);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            this.menuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip_ItemClicked);
            // 
            // ToolStripMenuItemFile
            // 
            this.ToolStripMenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出EToolStripMenuItem});
            this.ToolStripMenuItemFile.Name = "ToolStripMenuItemFile";
            this.ToolStripMenuItemFile.Size = new System.Drawing.Size(58, 21);
            this.ToolStripMenuItemFile.Text = "文件(&F)";
            // 
            // 退出EToolStripMenuItem
            // 
            this.退出EToolStripMenuItem.Name = "退出EToolStripMenuItem";
            this.退出EToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.退出EToolStripMenuItem.Text = "退出(&E)";
            // 
            // ToolStripMenuItemSetting
            // 
            this.ToolStripMenuItemSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemSystemSetting});
            this.ToolStripMenuItemSetting.Name = "ToolStripMenuItemSetting";
            this.ToolStripMenuItemSetting.Size = new System.Drawing.Size(59, 21);
            this.ToolStripMenuItemSetting.Text = "设置(&S)";
            // 
            // ToolStripMenuItemSystemSetting
            // 
            this.ToolStripMenuItemSystemSetting.Name = "ToolStripMenuItemSystemSetting";
            this.ToolStripMenuItemSystemSetting.Size = new System.Drawing.Size(124, 22);
            this.ToolStripMenuItemSystemSetting.Text = "系统设置";
            // 
            // ToolStripMenuItemView
            // 
            this.ToolStripMenuItemView.Name = "ToolStripMenuItemView";
            this.ToolStripMenuItemView.Size = new System.Drawing.Size(60, 21);
            this.ToolStripMenuItemView.Text = "查看(&V)";
            // 
            // ToolStripMenuItemFunction
            // 
            this.ToolStripMenuItemFunction.Name = "ToolStripMenuItemFunction";
            this.ToolStripMenuItemFunction.Size = new System.Drawing.Size(60, 21);
            this.ToolStripMenuItemFunction.Text = "功能(&R)";
            // 
            // ToolStripMenuItemHelp
            // 
            this.ToolStripMenuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.帮助内容CToolStripMenuItem,
            this.关于我们AToolStripMenuItem});
            this.ToolStripMenuItemHelp.Name = "ToolStripMenuItemHelp";
            this.ToolStripMenuItemHelp.Size = new System.Drawing.Size(61, 21);
            this.ToolStripMenuItemHelp.Text = "帮助(&H)";
            // 
            // 帮助内容CToolStripMenuItem
            // 
            this.帮助内容CToolStripMenuItem.Name = "帮助内容CToolStripMenuItem";
            this.帮助内容CToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.帮助内容CToolStripMenuItem.Text = "帮助内容(&C)";
            // 
            // 关于我们AToolStripMenuItem
            // 
            this.关于我们AToolStripMenuItem.Name = "关于我们AToolStripMenuItem";
            this.关于我们AToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.关于我们AToolStripMenuItem.Text = "关于我们(&A)";
            // 
            // toolBar
            // 
            this.toolBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.toolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.toolBarButtonRemote,
            this.toolBarButton4,
            this.toolBarButtonVideo,
            this.toolBarButton6,
            this.toolBarButtonFileManage,
            this.toolBarButton1,
            this.toolBarButtonCommand,
            this.toolBarButton8,
            this.toolBarButtonChat,
            this.toolBarButton3,
            this.toolBarButtonPushScreen});
            this.toolBar.ButtonSize = new System.Drawing.Size(60, 55);
            this.toolBar.CausesValidation = false;
            this.toolBar.Dock = System.Windows.Forms.DockStyle.None;
            this.toolBar.DropDownArrows = true;
            this.toolBar.ImageList = this.imageListToolBar;
            this.toolBar.Location = new System.Drawing.Point(0, 25);
            this.toolBar.Name = "toolBar";
            this.toolBar.ShowToolTips = true;
            this.toolBar.Size = new System.Drawing.Size(784, 57);
            this.toolBar.TabIndex = 1;
            this.toolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar_ButtonClick);
            // 
            // toolBarButtonRemote
            // 
            this.toolBarButtonRemote.ImageIndex = 1;
            this.toolBarButtonRemote.Name = "toolBarButtonRemote";
            this.toolBarButtonRemote.Text = "远程桌面";
            // 
            // toolBarButton4
            // 
            this.toolBarButton4.Name = "toolBarButton4";
            this.toolBarButton4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // toolBarButtonVideo
            // 
            this.toolBarButtonVideo.ImageIndex = 2;
            this.toolBarButtonVideo.Name = "toolBarButtonVideo";
            this.toolBarButtonVideo.Text = "视频监控";
            // 
            // toolBarButton6
            // 
            this.toolBarButton6.Name = "toolBarButton6";
            this.toolBarButton6.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // toolBarButtonFileManage
            // 
            this.toolBarButtonFileManage.ImageIndex = 5;
            this.toolBarButtonFileManage.Name = "toolBarButtonFileManage";
            this.toolBarButtonFileManage.Text = "文件管理";
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.Name = "toolBarButton1";
            this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // toolBarButtonCommand
            // 
            this.toolBarButtonCommand.ImageIndex = 4;
            this.toolBarButtonCommand.Name = "toolBarButtonCommand";
            this.toolBarButtonCommand.Text = "命令提示符";
            // 
            // toolBarButton8
            // 
            this.toolBarButton8.Name = "toolBarButton8";
            this.toolBarButton8.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // toolBarButtonChat
            // 
            this.toolBarButtonChat.ImageIndex = 6;
            this.toolBarButtonChat.Name = "toolBarButtonChat";
            this.toolBarButtonChat.Text = "对话提醒";
            // 
            // toolBarButton3
            // 
            this.toolBarButton3.Name = "toolBarButton3";
            this.toolBarButton3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // toolBarButtonPushScreen
            // 
            this.toolBarButtonPushScreen.ImageIndex = 7;
            this.toolBarButtonPushScreen.Name = "toolBarButtonPushScreen";
            this.toolBarButtonPushScreen.Text = "推送桌面";
            // 
            // imageListToolBar
            // 
            this.imageListToolBar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListToolBar.ImageStream")));
            this.imageListToolBar.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListToolBar.Images.SetKeyName(0, "VPN.ico");
            this.imageListToolBar.Images.SetKeyName(1, "Monitor.ico");
            this.imageListToolBar.Images.SetKeyName(2, "VideoCamera.ico");
            this.imageListToolBar.Images.SetKeyName(3, "Journal.ico");
            this.imageListToolBar.Images.SetKeyName(4, "cmd.ico");
            this.imageListToolBar.Images.SetKeyName(5, "fileManage.ico");
            this.imageListToolBar.Images.SetKeyName(6, "chat.ico");
            this.imageListToolBar.Images.SetKeyName(7, "network_center.ico");
            // 
            // statusBar
            // 
            this.statusBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusBar.Dock = System.Windows.Forms.DockStyle.None;
            this.statusBar.Location = new System.Drawing.Point(0, 539);
            this.statusBar.Name = "statusBar";
            this.statusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanelLocalIP,
            this.statusBarPanelPort,
            this.statusBarPanelHostCount,
            this.statusBarPanelStatus});
            this.statusBar.ShowPanels = true;
            this.statusBar.Size = new System.Drawing.Size(784, 22);
            this.statusBar.TabIndex = 2;
            // 
            // statusBarPanelLocalIP
            // 
            this.statusBarPanelLocalIP.Name = "statusBarPanelLocalIP";
            this.statusBarPanelLocalIP.Text = "本地IP：";
            this.statusBarPanelLocalIP.Width = 120;
            // 
            // statusBarPanelPort
            // 
            this.statusBarPanelPort.Name = "statusBarPanelPort";
            this.statusBarPanelPort.Text = "监听端口：";
            this.statusBarPanelPort.Width = 220;
            // 
            // statusBarPanelHostCount
            // 
            this.statusBarPanelHostCount.Name = "statusBarPanelHostCount";
            this.statusBarPanelHostCount.Text = "上线主机：0";
            this.statusBarPanelHostCount.Width = 120;
            // 
            // statusBarPanelStatus
            // 
            this.statusBarPanelStatus.Name = "statusBarPanelStatus";
            this.statusBarPanelStatus.Text = "连接状态：";
            this.statusBarPanelStatus.Width = 800;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPageRemoteHost);
            this.tabControl.Controls.Add(this.tabPageFileManage);
            this.tabControl.Location = new System.Drawing.Point(12, 122);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(760, 411);
            this.tabControl.TabIndex = 4;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPageRemoteHost
            // 
            this.tabPageRemoteHost.Controls.Add(this.listViewOnlineHost);
            this.tabPageRemoteHost.Controls.Add(this.toolStripOnlineHost);
            this.tabPageRemoteHost.Location = new System.Drawing.Point(4, 22);
            this.tabPageRemoteHost.Name = "tabPageRemoteHost";
            this.tabPageRemoteHost.Size = new System.Drawing.Size(752, 385);
            this.tabPageRemoteHost.TabIndex = 3;
            this.tabPageRemoteHost.Text = "上线主机";
            this.tabPageRemoteHost.UseVisualStyleBackColor = true;
            // 
            // listViewOnlineHost
            // 
            this.listViewOnlineHost.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderAddress,
            this.columnHeaderArea,
            this.columnHeaderHostName,
            this.columnHeaderLoginUser,
            this.columnHeaderOS,
            this.columnHeaderCPU,
            this.columnHeaderMemo,
            this.columnHeaderDisk,
            this.columnHeaderMonitor,
            this.columnHeaderVideo});
            this.listViewOnlineHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewOnlineHost.GridLines = true;
            this.listViewOnlineHost.Location = new System.Drawing.Point(0, 25);
            this.listViewOnlineHost.Name = "listViewOnlineHost";
            this.listViewOnlineHost.Size = new System.Drawing.Size(752, 360);
            this.listViewOnlineHost.TabIndex = 8;
            this.listViewOnlineHost.TabStop = false;
            this.listViewOnlineHost.TileSize = new System.Drawing.Size(128, 32);
            this.listViewOnlineHost.UseCompatibleStateImageBehavior = false;
            this.listViewOnlineHost.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderAddress
            // 
            this.columnHeaderAddress.Text = "主机IP地址";
            this.columnHeaderAddress.Width = 110;
            // 
            // columnHeaderArea
            // 
            this.columnHeaderArea.Text = "所在地区";
            this.columnHeaderArea.Width = 80;
            // 
            // columnHeaderHostName
            // 
            this.columnHeaderHostName.Text = "主机名";
            // 
            // columnHeaderLoginUser
            // 
            this.columnHeaderLoginUser.Text = "用户名";
            // 
            // columnHeaderOS
            // 
            this.columnHeaderOS.Text = "操作系统";
            this.columnHeaderOS.Width = 120;
            // 
            // columnHeaderCPU
            // 
            this.columnHeaderCPU.Text = "CPU";
            // 
            // columnHeaderMemo
            // 
            this.columnHeaderMemo.Text = "内存";
            // 
            // columnHeaderDisk
            // 
            this.columnHeaderDisk.Text = "硬盘";
            // 
            // columnHeaderMonitor
            // 
            this.columnHeaderMonitor.Text = "显示器";
            this.columnHeaderMonitor.Width = 50;
            // 
            // columnHeaderVideo
            // 
            this.columnHeaderVideo.Text = "视频";
            this.columnHeaderVideo.Width = 50;
            // 
            // toolStripOnlineHost
            // 
            this.toolStripOnlineHost.Location = new System.Drawing.Point(0, 0);
            this.toolStripOnlineHost.Name = "toolStripOnlineHost";
            this.toolStripOnlineHost.Size = new System.Drawing.Size(752, 25);
            this.toolStripOnlineHost.TabIndex = 0;
            this.toolStripOnlineHost.Text = "toolStrip1";
            // 
            // tabPageFileManage
            // 
            this.tabPageFileManage.Controls.Add(this.toolStripFileManage);
            this.tabPageFileManage.Controls.Add(this.splitContainerFileManage);
            this.tabPageFileManage.Location = new System.Drawing.Point(4, 22);
            this.tabPageFileManage.Name = "tabPageFileManage";
            this.tabPageFileManage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFileManage.Size = new System.Drawing.Size(752, 385);
            this.tabPageFileManage.TabIndex = 0;
            this.tabPageFileManage.Text = "文件管理";
            this.tabPageFileManage.UseVisualStyleBackColor = true;
            // 
            // toolStripFileManage
            // 
            this.toolStripFileManage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonHideDisplay,
            this.toolStripSeparator8,
            this.toolStripButtonNewFile,
            this.toolStripButtonNewFolder,
            this.toolStripSeparator2,
            this.toolStripButtonCut,
            this.toolStripButtonPaste,
            this.toolStripButtonDelete,
            this.toolStripSeparator7,
            this.toolStripSeparator4,
            this.toolStripButtonFind,
            this.toolStripSeparator3,
            this.toolStripButtonUpload,
            this.toolStripButtonDownload,
            this.toolStripSeparator5,
            this.toolStripButtonRename,
            this.toolStripButtonRefash,
            this.toolStripLabel,
            this.toolStripTextBoxCurDir,
            this.toolStripButtonBack,
            this.toolStripSeparator6,
            this.toolStripButtonMove});
            this.toolStripFileManage.Location = new System.Drawing.Point(3, 3);
            this.toolStripFileManage.Name = "toolStripFileManage";
            this.toolStripFileManage.Size = new System.Drawing.Size(746, 25);
            this.toolStripFileManage.TabIndex = 16;
            this.toolStripFileManage.Text = "toolStrip";
            // 
            // toolStripButtonHideDisplay
            // 
            this.toolStripButtonHideDisplay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonHideDisplay.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonHideDisplay.Image")));
            this.toolStripButtonHideDisplay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonHideDisplay.Name = "toolStripButtonHideDisplay";
            this.toolStripButtonHideDisplay.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonHideDisplay.Text = "toolStripButton1";
            this.toolStripButtonHideDisplay.ToolTipText = "隐藏";
            this.toolStripButtonHideDisplay.Click += new System.EventHandler(this.toolStripButtonHideDisplay_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonNewFile
            // 
            this.toolStripButtonNewFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonNewFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txt文件ToolStripMenuItem,
            this.word文档ToolStripMenuItem});
            this.toolStripButtonNewFile.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonNewFile.Image")));
            this.toolStripButtonNewFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNewFile.Name = "toolStripButtonNewFile";
            this.toolStripButtonNewFile.Size = new System.Drawing.Size(29, 22);
            this.toolStripButtonNewFile.Text = "toolStripButton13";
            this.toolStripButtonNewFile.ToolTipText = "新建文件";
            // 
            // txt文件ToolStripMenuItem
            // 
            this.txt文件ToolStripMenuItem.Name = "txt文件ToolStripMenuItem";
            this.txt文件ToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.txt文件ToolStripMenuItem.Text = "txt文件";
            this.txt文件ToolStripMenuItem.Click += new System.EventHandler(this.txt文件ToolStripMenuItem_Click);
            // 
            // word文档ToolStripMenuItem
            // 
            this.word文档ToolStripMenuItem.Name = "word文档ToolStripMenuItem";
            this.word文档ToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.word文档ToolStripMenuItem.Text = "Word文档";
            this.word文档ToolStripMenuItem.Click += new System.EventHandler(this.word文档ToolStripMenuItem_Click);
            // 
            // toolStripButtonNewFolder
            // 
            this.toolStripButtonNewFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonNewFolder.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonNewFolder.Image")));
            this.toolStripButtonNewFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNewFolder.Name = "toolStripButtonNewFolder";
            this.toolStripButtonNewFolder.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonNewFolder.Text = "toolStripButton11";
            this.toolStripButtonNewFolder.ToolTipText = "新建文件夹";
            this.toolStripButtonNewFolder.Click += new System.EventHandler(this.toolStripButtonNewFolder_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonCut
            // 
            this.toolStripButtonCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCut.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCut.Image")));
            this.toolStripButtonCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCut.Name = "toolStripButtonCut";
            this.toolStripButtonCut.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonCut.Text = "剪切";
            this.toolStripButtonCut.Click += new System.EventHandler(this.toolStripButtonCut_Click);
            // 
            // toolStripButtonPaste
            // 
            this.toolStripButtonPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPaste.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPaste.Image")));
            this.toolStripButtonPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPaste.Name = "toolStripButtonPaste";
            this.toolStripButtonPaste.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonPaste.Text = "toolStripButton4";
            this.toolStripButtonPaste.ToolTipText = "粘贴";
            this.toolStripButtonPaste.Click += new System.EventHandler(this.toolStripButtonPaste_Click);
            // 
            // toolStripButtonDelete
            // 
            this.toolStripButtonDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDelete.Image")));
            this.toolStripButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDelete.Name = "toolStripButtonDelete";
            this.toolStripButtonDelete.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonDelete.Text = "toolStripButton5";
            this.toolStripButtonDelete.ToolTipText = "删除";
            this.toolStripButtonDelete.Click += new System.EventHandler(this.toolStripButtonDelete_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonFind
            // 
            this.toolStripButtonFind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonFind.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonFind.Image")));
            this.toolStripButtonFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFind.Name = "toolStripButtonFind";
            this.toolStripButtonFind.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonFind.Text = "toolStripButton1";
            this.toolStripButtonFind.ToolTipText = "查找";
            this.toolStripButtonFind.Click += new System.EventHandler(this.toolStripButtonFind_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonUpload
            // 
            this.toolStripButtonUpload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonUpload.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonUpload.Image")));
            this.toolStripButtonUpload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonUpload.Name = "toolStripButtonUpload";
            this.toolStripButtonUpload.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonUpload.Text = "toolStripButton8";
            this.toolStripButtonUpload.ToolTipText = "上传";
            this.toolStripButtonUpload.Click += new System.EventHandler(this.toolStripButtonUpload_Click);
            // 
            // toolStripButtonDownload
            // 
            this.toolStripButtonDownload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDownload.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDownload.Image")));
            this.toolStripButtonDownload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDownload.Name = "toolStripButtonDownload";
            this.toolStripButtonDownload.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonDownload.Text = "toolStripButton9";
            this.toolStripButtonDownload.ToolTipText = "下载";
            this.toolStripButtonDownload.Click += new System.EventHandler(this.toolStripButtonDownload_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonRename
            // 
            this.toolStripButtonRename.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRename.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRename.Image")));
            this.toolStripButtonRename.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRename.Name = "toolStripButtonRename";
            this.toolStripButtonRename.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonRename.Text = "toolStripButton12";
            this.toolStripButtonRename.ToolTipText = "重命名";
            this.toolStripButtonRename.Click += new System.EventHandler(this.toolStripButtonRename_Click);
            // 
            // toolStripButtonRefash
            // 
            this.toolStripButtonRefash.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRefash.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRefash.Image")));
            this.toolStripButtonRefash.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRefash.Name = "toolStripButtonRefash";
            this.toolStripButtonRefash.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonRefash.Text = "toolStripButton10";
            this.toolStripButtonRefash.ToolTipText = "刷新";
            this.toolStripButtonRefash.Click += new System.EventHandler(this.toolStripButtonRefash_Click);
            // 
            // toolStripLabel
            // 
            this.toolStripLabel.Name = "toolStripLabel";
            this.toolStripLabel.Size = new System.Drawing.Size(68, 22);
            this.toolStripLabel.Text = "当前目录：";
            // 
            // toolStripTextBoxCurDir
            // 
            this.toolStripTextBoxCurDir.Name = "toolStripTextBoxCurDir";
            this.toolStripTextBoxCurDir.ReadOnly = true;
            this.toolStripTextBoxCurDir.Size = new System.Drawing.Size(250, 25);
            // 
            // toolStripButtonBack
            // 
            this.toolStripButtonBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonBack.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonBack.Image")));
            this.toolStripButtonBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonBack.Name = "toolStripButtonBack";
            this.toolStripButtonBack.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonBack.Text = "toolStripButton1";
            this.toolStripButtonBack.ToolTipText = "后退";
            this.toolStripButtonBack.Click += new System.EventHandler(this.toolStripButtonBack_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonMove
            // 
            this.toolStripButtonMove.Checked = true;
            this.toolStripButtonMove.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripButtonMove.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonMove.Image")));
            this.toolStripButtonMove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonMove.Name = "toolStripButtonMove";
            this.toolStripButtonMove.Size = new System.Drawing.Size(52, 22);
            this.toolStripButtonMove.Text = "转到";
            // 
            // splitContainerFileManage
            // 
            this.splitContainerFileManage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerFileManage.Location = new System.Drawing.Point(3, 31);
            this.splitContainerFileManage.Name = "splitContainerFileManage";
            // 
            // splitContainerFileManage.Panel1
            // 
            this.splitContainerFileManage.Panel1.Controls.Add(this.treeViewDir);
            // 
            // splitContainerFileManage.Panel2
            // 
            this.splitContainerFileManage.Panel2.Controls.Add(this.listViewFile);
            this.splitContainerFileManage.Size = new System.Drawing.Size(746, 351);
            this.splitContainerFileManage.SplitterDistance = 185;
            this.splitContainerFileManage.TabIndex = 15;
            // 
            // treeViewDir
            // 
            this.treeViewDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewDir.Location = new System.Drawing.Point(0, 0);
            this.treeViewDir.Name = "treeViewDir";
            this.treeViewDir.Size = new System.Drawing.Size(185, 351);
            this.treeViewDir.TabIndex = 0;
            this.treeViewDir.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeViewDir_BeforeCollapse);
            this.treeViewDir.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeViewDir_BeforeExpand);
            this.treeViewDir.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewFile_AfterSelect);
            this.treeViewDir.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewDir_NodeMouseClick);
            // 
            // listViewFile
            // 
            this.listViewFile.AutoArrange = false;
            this.listViewFile.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderFileName,
            this.columnHeaderFileSize,
            this.columnHeaderCreateTime,
            this.columnHeaderChangeTime});
            this.listViewFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewFile.FullRowSelect = true;
            this.listViewFile.GridLines = true;
            this.listViewFile.Location = new System.Drawing.Point(0, 0);
            this.listViewFile.MultiSelect = false;
            this.listViewFile.Name = "listViewFile";
            this.listViewFile.Size = new System.Drawing.Size(557, 351);
            this.listViewFile.TabIndex = 0;
            this.listViewFile.TabStop = false;
            this.listViewFile.UseCompatibleStateImageBehavior = false;
            this.listViewFile.View = System.Windows.Forms.View.Details;
            this.listViewFile.ItemMouseHover += new System.Windows.Forms.ListViewItemMouseHoverEventHandler(this.listViewFile_ItemMouseHover);
            this.listViewFile.DoubleClick += new System.EventHandler(this.listViewFile_DoubleClick);
            // 
            // columnHeaderFileName
            // 
            this.columnHeaderFileName.Text = "文件名";
            this.columnHeaderFileName.Width = 100;
            // 
            // columnHeaderFileSize
            // 
            this.columnHeaderFileSize.Text = "文件大小";
            this.columnHeaderFileSize.Width = 80;
            // 
            // columnHeaderCreateTime
            // 
            this.columnHeaderCreateTime.Text = "创建时间";
            this.columnHeaderCreateTime.Width = 120;
            // 
            // columnHeaderChangeTime
            // 
            this.columnHeaderChangeTime.Text = "修改时间";
            this.columnHeaderChangeTime.Width = 120;
            // 
            // imageListAll
            // 
            this.imageListAll.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListAll.ImageStream")));
            this.imageListAll.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListAll.Images.SetKeyName(0, "cmd.ico");
            this.imageListAll.Images.SetKeyName(1, "computer.ico");
            this.imageListAll.Images.SetKeyName(2, "Journal.ico");
            this.imageListAll.Images.SetKeyName(3, "Monitor.ico");
            this.imageListAll.Images.SetKeyName(4, "Network_Map.ico");
            this.imageListAll.Images.SetKeyName(5, "VideoCamera.ico");
            this.imageListAll.Images.SetKeyName(6, "VPN.ico");
            this.imageListAll.Images.SetKeyName(7, "back.ico");
            this.imageListAll.Images.SetKeyName(8, "copy.ico");
            this.imageListAll.Images.SetKeyName(9, "cut.ico");
            this.imageListAll.Images.SetKeyName(10, "delete.ico");
            this.imageListAll.Images.SetKeyName(11, "do.ico");
            this.imageListAll.Images.SetKeyName(12, "docfind.ico");
            this.imageListAll.Images.SetKeyName(13, "download.ico");
            this.imageListAll.Images.SetKeyName(14, "left.ico");
            this.imageListAll.Images.SetKeyName(15, "move.ico");
            this.imageListAll.Images.SetKeyName(16, "newfile.ico");
            this.imageListAll.Images.SetKeyName(17, "newfolder.ico");
            this.imageListAll.Images.SetKeyName(18, "paste.ico");
            this.imageListAll.Images.SetKeyName(19, "refash.ico");
            this.imageListAll.Images.SetKeyName(20, "rename.ico");
            this.imageListAll.Images.SetKeyName(21, "right.ico");
            this.imageListAll.Images.SetKeyName(22, "sort.ico");
            this.imageListAll.Images.SetKeyName(23, "undo.ico");
            this.imageListAll.Images.SetKeyName(24, "upload.ico");
            this.imageListAll.Images.SetKeyName(25, "connect_toNetwork.ico");
            this.imageListAll.Images.SetKeyName(26, "fileManage.ico");
            // 
            // imageListFileManage
            // 
            this.imageListFileManage.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListFileManage.ImageStream")));
            this.imageListFileManage.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListFileManage.Images.SetKeyName(0, "left.ico");
            this.imageListFileManage.Images.SetKeyName(1, "right.ico");
            this.imageListFileManage.Images.SetKeyName(2, "newfile.ico");
            this.imageListFileManage.Images.SetKeyName(3, "newfolder.ico");
            this.imageListFileManage.Images.SetKeyName(4, "copy.ico");
            this.imageListFileManage.Images.SetKeyName(5, "cut.ico");
            this.imageListFileManage.Images.SetKeyName(6, "paste.ico");
            this.imageListFileManage.Images.SetKeyName(7, "delete.ico");
            this.imageListFileManage.Images.SetKeyName(8, "docfind.ico");
            this.imageListFileManage.Images.SetKeyName(9, "sort.ico");
            this.imageListFileManage.Images.SetKeyName(10, "upload.ico");
            this.imageListFileManage.Images.SetKeyName(11, "download.ico");
            this.imageListFileManage.Images.SetKeyName(12, "rename.ico");
            this.imageListFileManage.Images.SetKeyName(13, "refash.ico");
            this.imageListFileManage.Images.SetKeyName(14, "back.ico");
            this.imageListFileManage.Images.SetKeyName(15, "move.ico");
            this.imageListFileManage.Images.SetKeyName(16, "hide.ico");
            this.imageListFileManage.Images.SetKeyName(17, "display.ico");
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.buttonDisconnect);
            this.panel1.Controls.Add(this.comboBoxCurrentHost);
            this.panel1.Controls.Add(this.buttonConnect);
            this.panel1.Controls.Add(this.textBoxPort);
            this.panel1.Controls.Add(this.labelPort);
            this.panel1.Controls.Add(this.labelHost);
            this.panel1.Location = new System.Drawing.Point(0, 88);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 28);
            this.panel1.TabIndex = 5;
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.Location = new System.Drawing.Point(525, 2);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(70, 21);
            this.buttonDisconnect.TabIndex = 15;
            this.buttonDisconnect.Text = "断开";
            this.buttonDisconnect.UseVisualStyleBackColor = true;
            this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);
            // 
            // comboBoxCurrentHost
            // 
            this.comboBoxCurrentHost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCurrentHost.FormattingEnabled = true;
            this.comboBoxCurrentHost.Items.AddRange(new object[] {
            "localhost(127.0.0.1)"});
            this.comboBoxCurrentHost.Location = new System.Drawing.Point(74, 3);
            this.comboBoxCurrentHost.Name = "comboBoxCurrentHost";
            this.comboBoxCurrentHost.Size = new System.Drawing.Size(237, 20);
            this.comboBoxCurrentHost.TabIndex = 14;
            this.comboBoxCurrentHost.SelectedIndexChanged += new System.EventHandler(this.comboBoxCurrentHost_SelectedIndexChanged);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(449, 2);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(70, 21);
            this.buttonConnect.TabIndex = 13;
            this.buttonConnect.Text = "连接";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // textBoxPort
            // 
            this.textBoxPort.Enabled = false;
            this.textBoxPort.Location = new System.Drawing.Point(364, 2);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(79, 21);
            this.textBoxPort.TabIndex = 10;
            this.textBoxPort.Text = "1008";
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(317, 6);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(41, 12);
            this.labelPort.TabIndex = 9;
            this.labelPort.Text = "端口：";
            // 
            // labelHost
            // 
            this.labelHost.AutoSize = true;
            this.labelHost.Location = new System.Drawing.Point(3, 6);
            this.labelHost.Name = "labelHost";
            this.labelHost.Size = new System.Drawing.Size(65, 12);
            this.labelHost.TabIndex = 7;
            this.labelHost.Text = "当前主机：";
            // 
            // imageListChat
            // 
            this.imageListChat.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListChat.ImageStream")));
            this.imageListChat.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListChat.Images.SetKeyName(0, "awake.ico");
            this.imageListChat.Images.SetKeyName(1, "chat.ico");
            this.imageListChat.Images.SetKeyName(2, "popup.ico");
            // 
            // imageListListView
            // 
            this.imageListListView.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageListListView.ImageSize = new System.Drawing.Size(16, 16);
            this.imageListListView.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // imageListTreeView
            // 
            this.imageListTreeView.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListTreeView.ImageStream")));
            this.imageListTreeView.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListTreeView.Images.SetKeyName(0, "1.jpg");
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.toolBar);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.Text = "RemoteControl Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelLocalIP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelHostCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanelStatus)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPageRemoteHost.ResumeLayout(false);
            this.tabPageRemoteHost.PerformLayout();
            this.tabPageFileManage.ResumeLayout(false);
            this.tabPageFileManage.PerformLayout();
            this.toolStripFileManage.ResumeLayout(false);
            this.toolStripFileManage.PerformLayout();
            this.splitContainerFileManage.Panel1.ResumeLayout(false);
            this.splitContainerFileManage.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFileManage)).EndInit();
            this.splitContainerFileManage.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemFile;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSetting;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSystemSetting;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemView;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemFunction;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemHelp;
        private System.Windows.Forms.ToolStripMenuItem 帮助内容CToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于我们AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出EToolStripMenuItem;
        private System.Windows.Forms.ToolBar toolBar;
        private System.Windows.Forms.ToolBarButton toolBarButton4;
        private System.Windows.Forms.ToolBarButton toolBarButtonVideo;
        private System.Windows.Forms.ToolBarButton toolBarButton6;
        private System.Windows.Forms.ToolBarButton toolBarButton8;
        private System.Windows.Forms.ToolBarButton toolBarButtonCommand;
        private System.Windows.Forms.ImageList imageListToolBar;
        private System.Windows.Forms.StatusBar statusBar;
        private System.Windows.Forms.StatusBarPanel statusBarPanelLocalIP;
        private System.Windows.Forms.StatusBarPanel statusBarPanelPort;
        private System.Windows.Forms.StatusBarPanel statusBarPanelHostCount;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageFileManage;
        private System.Windows.Forms.TabPage tabPageRemoteHost;
        private System.Windows.Forms.ImageList imageListFileManage;
        private System.Windows.Forms.SplitContainer splitContainerFileManage;
        private System.Windows.Forms.TreeView treeViewDir;
        //private System.Windows.Forms.ListView listViewFile;
        private ListViewDoubleBuffered listViewFile;
        private System.Windows.Forms.ColumnHeader columnHeaderFileName;
        private System.Windows.Forms.ColumnHeader columnHeaderFileSize;
        private System.Windows.Forms.ColumnHeader columnHeaderCreateTime;
        private System.Windows.Forms.ColumnHeader columnHeaderChangeTime;
        private System.Windows.Forms.ImageList imageListAll;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.Label labelHost;
        private System.Windows.Forms.ListView listViewOnlineHost;
        private System.Windows.Forms.ColumnHeader columnHeaderAddress;
        private System.Windows.Forms.ColumnHeader columnHeaderArea;
        private System.Windows.Forms.ColumnHeader columnHeaderHostName;
        private System.Windows.Forms.ColumnHeader columnHeaderLoginUser;
        private System.Windows.Forms.ColumnHeader columnHeaderOS;
        private System.Windows.Forms.ColumnHeader columnHeaderCPU;
        private System.Windows.Forms.ColumnHeader columnHeaderMemo;
        private System.Windows.Forms.ColumnHeader columnHeaderDisk;
        private System.Windows.Forms.ColumnHeader columnHeaderMonitor;
        private System.Windows.Forms.ColumnHeader columnHeaderVideo;
        private System.Windows.Forms.ToolStrip toolStripOnlineHost;
        private System.Windows.Forms.ToolBarButton toolBarButtonRemote;
        private System.Windows.Forms.ComboBox comboBoxCurrentHost;
        private System.Windows.Forms.StatusBarPanel statusBarPanelStatus;
        private System.Windows.Forms.Button buttonDisconnect;
        private System.Windows.Forms.ToolBarButton toolBarButtonFileManage;
        private System.Windows.Forms.ToolBarButton toolBarButton1;
        private System.Windows.Forms.ToolBarButton toolBarButtonChat;
        private System.Windows.Forms.ImageList imageListChat;
        private System.Windows.Forms.ToolBarButton toolBarButton3;
        private System.Windows.Forms.ToolBarButton toolBarButtonPushScreen;
        private System.Windows.Forms.ToolStrip toolStripFileManage;
        private System.Windows.Forms.ToolStripButton toolStripButtonHideDisplay;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButtonNewFile;
        private System.Windows.Forms.ToolStripMenuItem txt文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem word文档ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonNewFolder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonCut;
        private System.Windows.Forms.ToolStripButton toolStripButtonPaste;
        private System.Windows.Forms.ToolStripButton toolStripButtonDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButtonFind;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButtonUpload;
        private System.Windows.Forms.ToolStripButton toolStripButtonDownload;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStripButtonRename;
        private System.Windows.Forms.ToolStripButton toolStripButtonRefash;
        private System.Windows.Forms.ToolStripLabel toolStripLabel;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxCurDir;
        private System.Windows.Forms.ToolStripButton toolStripButtonBack;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton toolStripButtonMove;
        private System.Windows.Forms.ImageList imageListListView;
        private System.Windows.Forms.ImageList imageListTreeView;
    }
}

