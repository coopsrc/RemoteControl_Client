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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class ChatForm : Form
    {
        private TcpClient chatClient;
        private NetworkStream ns;
        private BinaryReader br;
        private BinaryWriter bw;

        private Thread chatThread;
        public ChatForm()
        {
            InitializeComponent();
            buttonConnect.Visible = false;
        }

        private void Start()
        {

            try
            {
                int port = MainForm.chatPort;
                IPAddress ip = MainForm.address;
                chatClient = new TcpClient();
                chatClient.Connect(ip, port);

                ns = chatClient.GetStream();

                br = new BinaryReader(ns);
                bw = new BinaryWriter(ns);


                chatThread = new Thread(Receive);
                chatThread.IsBackground = true;
                chatThread.Start();
            }
            catch
            {
                MessageBox.Show("Chat 连接失败");
            }
        }

        private void Receive()
        {
            string recStr = "";
            while (true)
            {
                try
                {
                	recStr = br.ReadString();
                }
                catch
                {
                	
                }
                if (recStr != null)
                {
                    AddRichTextBox("other:" + recStr);
                }
            }
        }

        private delegate void AddRichTextBoxDisplayDelegate(string str);
        private void AddRichTextBox(string str)
        {
            if (richTextBoxDisplay.InvokeRequired)
            {
                AddRichTextBoxDisplayDelegate d = new AddRichTextBoxDisplayDelegate(AddRichTextBox);
                this.Invoke(d, str);
            }
            else
            {
                richTextBoxDisplay.AppendText("\n" + str);
            }
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            Start();
            if (chatClient.Connected)
            {
                buttonConnect.Enabled = false;
            }
        }

        private void ChatForm_Load(object sender, EventArgs e)
        {
            MainForm.SendControl("Chat");
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            bw.Write(richTextBoxSend.Text);
            AddRichTextBox("I:" + richTextBoxSend.Text + "\r\n");
        }

        private void ChatForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.SendControl("Chat Closed");
        }

        private void ChatForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            try
            {
                bw.Write("Close");
            }
            catch
            {

            }


            chatThread.Abort();

            try
            {
                ns.Close();
                br.Close();
                bw.Close();
                chatClient.Close();
                chatClient.Client.Close();
            }
            catch
            {

            }
        }

        private void ChatForm_Activated(object sender, EventArgs e)
        {
            this.buttonConnect_Click( sender,  e);
        }
    }
}
