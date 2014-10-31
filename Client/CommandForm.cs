using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ClientLibrary;
using System.Net.Sockets;
using System.Threading;

namespace Client
{
    public partial class CommandForm : Form
    {
        //Command连接
        public static TcpClient tcpClient;
        public static NetworkStream networkStream;
        public static Thread thread;
        public static bool connected = false;

        public CommandForm()
        {
            InitializeComponent();
            richTextBoxCMD.AppendText(">");
        }

        /// <summary>
        /// 连接Command端口
        /// </summary>
        public void Start()
        {
            try
            {
                tcpClient = new TcpClient();
                tcpClient.Connect(MainForm.address, MainForm.commandPort);

                connected = true;

                networkStream = tcpClient.GetStream();

                Send("Connect");

                thread = new Thread(Receive);
                thread.Start();
            }
            catch
            {
                MessageBox.Show("Command 连接失败");
            }

        }


        /// <summary>
        /// 接收Command数据
        /// </summary>
        public void Receive()
        {
            byte[] buffer = new byte[1024];
            int bytesRead;

            while (true)
            {
                {
                    bytesRead = networkStream.Read(buffer, 0, 1024);
                    if (bytesRead > 0)
                    {
                        AddRichTextBoxCMD(Encoding.Unicode.GetString(buffer, 0, bytesRead));

                        if (bytesRead < 1024)
                        {
                            AddRichTextBoxCMD("==========================================================================================\n>");
                        }
                    }
                }
            }
        }


        /// <summary>
        /// 发送Command命令
        /// </summary>
        /// <param name="cmd"></param>
        public void Send(string cmd)
        {
            byte[] buffer = Encoding.Unicode.GetBytes(cmd);
            try
            {
                networkStream.Write(buffer, 0, buffer.Length);
            }
            catch
            {
                //发送失败
            }
        }

        private delegate void AddRichTextBoxCMDDelegate(string msg);
        private void AddRichTextBoxCMD(string msg)
        {
            if (richTextBoxCMD.InvokeRequired)
            {
                AddRichTextBoxCMDDelegate d = new AddRichTextBoxCMDDelegate(AddRichTextBoxCMD);
                this.Invoke(d, msg);
            }
            else
            {
                richTextBoxCMD.AppendText("\n" + msg + "\n");
            }
        }
        private void richTextBoxCMD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (connected)
                {
                    try
                    {
                        string command = richTextBoxCMD.Lines[richTextBoxCMD.Lines.Length - 1].Split('>')[1];

                        Send(command);


                    }
                    catch (Exception)
                    {
                        richTextBoxCMD.AppendText("\nCOMMAND ERROR\n>");
                    }
                }
            }
        }

        private void CommandForm_Load(object sender, EventArgs e)
        {
            MainForm.SendControl("Command");

            Start();
        }

        private void CommandForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.SendControl("Command Closed");
        }

        private void CommandForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Send("Closed");

            thread.Abort();
            networkStream.Close();
            tcpClient.Close();
            tcpClient.Client.Close();
        }

    }
}
