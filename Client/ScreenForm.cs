using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class ScreenForm : Form
    {
        bool keyControl = false;
        bool mouseControl = false;

        private TcpClient screenClient;
        private Thread screenThread;
        private NetworkStream ns;
        private BinaryReader br;
        private BinaryWriter bw;
        private MemoryStream ms;
        public ScreenForm()
        {
            InitializeComponent();

            toolBarButtonPause.Enabled = false;
            toolBarButtonReleaseMouse.Enabled = false;
            toolBarButtonReleaseKeyboard.Enabled = false;
        }

        private void Start()
        {

            try
            {
                int port = MainForm.screenPort;
                IPAddress ip = MainForm.address;
                screenClient = new TcpClient();
                screenClient.Connect(ip, port);

                ns = screenClient.GetStream();

                br = new BinaryReader(ns);
                bw = new BinaryWriter(ns);


                screenThread = new Thread(Receive);
                screenThread.IsBackground = true;
                screenThread.Start();
            }
            catch
            {
                MessageBox.Show("Screen 连接失败");
            }
        }

        private void Receive()
        {

            byte[] receiveBytes = null;
            int receiveLength;
            string name = "temp";
            int i = 0;
            Bitmap image = null;
            while (true)
            {
                try
                {
                    i++;
                    receiveLength = br.ReadInt32();
                    receiveBytes = new Byte[receiveLength];
                    receiveBytes = br.ReadBytes(receiveLength);

                    ms = new MemoryStream(receiveBytes);
                }
                catch
                {
                    //MessageBox.Show("接受桌面图片错误1");
                }
                try
                {
                    image = (Bitmap)Image.FromStream(ms);
                }
                catch
                {
                    image = null;
                   // MessageBox.Show("接受桌面图片错误2");
                }
                try
                {
                    name += i + ".png";
                    pictureBox.Image = Image.FromStream(ms);

                    name = "temp";
                    image.Dispose();
                }
                catch
                {
                    //MessageBox.Show("接受桌面图片错误3");
                }
                ms.Flush();
                ms = null;
                receiveBytes = null;
            }
        }

        private void ScreenForm_Load(object sender, EventArgs e)
        {
            MainForm.SendControl("Screen");
            Start();
        }

        private void ScreenForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.SendControl("Screen Closed");
        }

        private void toolBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            if (e.Button == toolBarButtonStart)
            {
                bw.Write("desktop,");

                toolBarButtonStart.Enabled = false;
                toolBarButtonPause.Enabled = true;
            }
            else if (e.Button == toolBarButtonPause)
            {
                bw.Write("pause,");
            }
            else if (e.Button == toolBarButtonMouse)
            {
                mouseControl = true;
                toolBarButtonMouse.Enabled = false;
                toolBarButtonReleaseMouse.Enabled = true;
            }
            else if (e.Button == toolBarButtonReleaseMouse)
            {
                mouseControl = false;
            }
            else if (e.Button == toolBarButtonKeyboard)
            {
                keyControl = true;
                toolBarButtonKeyboard.Enabled = false;
                toolBarButtonReleaseKeyboard.Enabled = true;
            }
            else if (e.Button == toolBarButtonReleaseKeyboard)
            {
                keyControl = false;
            }
            else if (e.Button == toolBarButtonBox)
            {
                richTextBoxSend.Visible = true;
                buttonSend.Visible = true;
                buttonHide.Visible = true;
            }
        }



        /// <summary>
        /// 鼠标点击事件
        /// </summary>
        /// <param name="me"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        private void buttonHide_Click(object sender, EventArgs e)
        {
            richTextBoxSend.Hide();
            buttonSend.Hide();
            buttonHide.Hide();
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            string sendStr = "talkbox," + richTextBoxSend.Text;
            bw.Write(sendStr);
            richTextBoxSend.Clear();
        }

        private void ScreenForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (keyControl)
            {
                bw.Write("keyboard," + e.KeyValue + "," + "keydown");
            }
        }

        private void ScreenForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (keyControl)
            {
                bw.Write("keyboard," + e.KeyValue + "," + "keyup");
            }
        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (mouseControl)
            {
                if (e.Button == MouseButtons.Left)
                    bw.Write("mouse,event,left,click");
                if (e.Button == MouseButtons.Right)
                    bw.Write("mouse,event,right,click");
            }
        }

        private void pictureBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (mouseControl)
            {
                if (e.Button == MouseButtons.Left)
                    bw.Write("mouse,event,left,dobuleclick");
            }
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (mouseControl)
            {
                if (e.Button == MouseButtons.Left)
                    bw.Write("mouse,event,left,down");
                if (e.Button == MouseButtons.Right)
                    bw.Write("mouse,event,right,down");
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (mouseControl)
            {
                if (e.Button == MouseButtons.Left)
                    bw.Write("mouse,event,left,up");
                if (e.Button == MouseButtons.Right)
                    bw.Write("mouse,evnet,right,up");
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseControl)
            {
                bw.Write("mouse,move," + e.X + "," + e.Y);
            }
        }

        private void ScreenForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            try
            {
                screenThread.Abort();

                Thread.Sleep(1000);

                bw.Write("close,");

                ms.Close();
                ns.Close();
                br.Close();
                bw.Close();

                screenClient.Close();
            }
            catch
            {

            }


        }
    }
}
