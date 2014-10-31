using ClientLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
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
    public partial class VideoForm : Form
    {
        public static TcpClient tcpClient;
        public static NetworkStream networkStream;
        public static BinaryReader br;
        public static MemoryStream ms;
        public static Thread thread;
        public static bool connected = false;

        public VideoForm()
        {
            InitializeComponent();
        }

        //创建连接
        private void Start()
        {
            try
            {
                tcpClient = new TcpClient();
                tcpClient.Connect(MainForm.address, MainForm.videoPort);

                connected = true;

                networkStream = tcpClient.GetStream();
                br = new BinaryReader(networkStream);

                Send("Connect");

                thread = new Thread(Receive);
                thread.IsBackground = true;
                thread.Start();
            }
            catch
            {
                MessageBox.Show("Video 连接失败");
                return;
            }
        }


        /// <summary>
        /// 接收服务端发送的图片
        /// </summary>
        private void Receive()
        {
            byte[] receiveBytes = null;
            int receiveLength;
            Bitmap image = null;
            while (true)
            {
                receiveLength = br.ReadInt32();
                receiveBytes = new Byte[receiveLength];
                receiveBytes = br.ReadBytes(receiveLength);
                ms = new MemoryStream(receiveBytes);
                image = (Bitmap)Image.FromStream(ms);
                pictureBoxVideo.Image = Image.FromStream(ms);

                image.Dispose();
                ms.Flush();
                ms = null;
                receiveBytes = null;
            }
        }


        /// <summary>
        /// 向服务端发送命令
        /// </summary>
        /// <param name="str">命令</param>
        private void Send(string str)
        {
            byte[] buffer = Encoding.Unicode.GetBytes(str);
            try
            {
                networkStream.Write(buffer, 0, buffer.Length);
            }
            catch
            {
                //发送失败
            }
        }


        /// <summary>
        /// 窗口激活
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VideoForm_Activated(object sender, EventArgs e)
        {


        }


        /// <summary>
        /// 窗口关闭
        /// 退出线程、网络流、TCP连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VideoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Send("Close");

            thread.Abort();

            networkStream.Close();

            try
            {
                br.Close();
                ms.Close();
            }
            catch
            {

            }

            tcpClient.Close();
            tcpClient.Client.Close();
        }


        /// <summary>
        /// 窗口载入
        /// 向服务端发送命令，打开视频服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VideoForm_Load(object sender, EventArgs e)
        {
            MainForm.SendControl("Video");
            Start();
        }


        /// <summary>
        /// 窗口关闭
        /// 向服务端发送命令
        /// 关闭视频传输、关闭视频服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VideoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.SendControl("Video Closed");
        }


        /// <summary>
        /// 菜单栏点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            if (e.Button == toolBarButtonOpen)
            {
                Send("Open");
            }
            else if (e.Button == toolBarButtonClose)
            {
                Send("Pause");
                pictureBoxVideo.Image = null;
            }
            else if (e.Button == toolBarButtonCapture)
            {
                CaptureImage();
            }
            else if (e.Button == toolBarButtonTune)
            {
                SetVideoRate();
            }
        }


        /// <summary>
        /// 设置视频 FPS
        /// </summary>
        private void SetVideoRate()
        {
            VideoRateForm videoRateForm = new VideoRateForm();

            if (videoRateForm.ShowDialog() == DialogResult.OK)
            {
                Send("VideoRate:" + videoRateForm.VideoRate);
            }
        }


        /// <summary>
        /// 保存图像
        /// </summary>
        private void CaptureImage()
        {
            Image image = pictureBoxVideo.Image;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "保存图像";
            saveFileDialog.Filter = @"jpeg|*.jpg|bmp|*.bmp|gif|*.gif|png|*.png";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog.FileName.ToString();

                if (fileName != "" && fileName != null)
                {
                    string fileExtName = fileName.Substring(fileName.LastIndexOf(".") + 1).ToString();

                    //默认保存Jpg格式
                    ImageFormat imgformat = ImageFormat.Jpeg;

                    if (fileExtName != "")
                    {
                        switch (fileExtName)
                        {
                            case "jpg":
                                imgformat = ImageFormat.Jpeg;
                                break;
                            case "bmp":
                                imgformat = ImageFormat.Bmp;
                                break;
                            case "gif":
                                imgformat = ImageFormat.Gif;
                                break;
                            case "png":
                                imgformat = ImageFormat.Png;
                                break;
                            default:
                                MessageBox.Show("只能存取为: jpg,bmp,gif,png 格式");
                                break;
                        }

                    }

                    try
                    {
                        image.Save(fileName, imgformat);
                    }
                    catch
                    {
                        MessageBox.Show("保存失败!");
                    }

                }
            }
        }

    }
}
