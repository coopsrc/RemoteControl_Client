using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class DownloadProcessBar : Form
    {
        public DownloadProcessBar(string msg)
        {
            InitializeComponent();
            this.buttonOK.Enabled = false;
            this.ControlBox = false;//禁用关闭按钮等
            //while (true)
            //{
            //    try
            //    {
            //        Clients.client_FileTransport = new TcpClient();
            //        Clients.client_FileTransport.Connect(MainForm.selectAddress, Clients.port_FileTransport);
            //        break;
            //    }
            //    catch
            //    {
            //        continue;
            //    }
            //}

            Thread t = new Thread(ReceiveFile);
            t.Start(msg);
        }
        private void ReceiveFile(object obj)
        {
            string msg = (string)obj;
            string savePath = msg.Split(',')[0];
            int len = int.Parse(msg.Split(',')[1]);
            FileStream fileReceive = new FileStream(savePath, FileMode.Create, FileAccess.Write);

            int bufferSize = Clients.client_FileTransport.ReceiveBufferSize;
            byte[] buffer = new byte[bufferSize]; //定义缓冲区
            int left = len;
            //接收数据
            while (left > 0)
            {
                if (left > buffer.Length)
                {
                    Clients.netStream_FileTransport.Read(buffer, 0, buffer.Length);
                    fileReceive.Write(buffer, 0, buffer.Length);
                    left -= bufferSize;
                    int value = (bufferSize - left) / len;
                    SetProgress(value);
                }
                else
                {
                    Clients.netStream_FileTransport.Read(buffer, 0, left);
                    fileReceive.Write(buffer, 0, left);
                    left -= bufferSize;
                    SetProgress(100);
                }
            }
            fileReceive.Close();
        }


        void SetProgress(int value)
        {
            object[] objs = new object[] { 100, 0 };
                Thread.Sleep(200);
                objs[1] = value;
                //异步调用
                this.Invoke(new ShowProgressDelegate(ShowProgress), objs);
            
        }

        delegate void ShowProgressDelegate(int totalStep, int currentStep);

        /// <summary>
        /// 刷新进度条
        /// </summary>
        /// <param name="totalStep"></param>
        /// <param name="currentStep"></param>
        void ShowProgress(int totalStep, int currentStep)
        {
            this.progressBar1.Maximum = totalStep;
            this.progressBar1.Value = currentStep;

            if(currentStep!=100)
            {
                labelStatus.Text = "正在下载";
            }
            else
            {
                labelStatus.Text = "下载完成";
                this.buttonOK.Enabled = true;
            }
            this.labelPercentage.Text = this.progressBar1.Value * 100 / progressBar1.Maximum + "%";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
