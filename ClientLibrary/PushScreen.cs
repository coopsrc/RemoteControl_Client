using System;
using System.Collections.Generic;
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

namespace ClientLibrary
{
    public class PushScreen
    {
        private int portServer;
        private int portClient;
        private IPAddress multcastAddress;

        private UdpClient udpClient;
        private NetworkStream networkStream;
        private IPEndPoint ipEndPoint;
        private Thread thread;

        private ScreenShot screenShot;
        private Bitmap bitmap;
        private MemoryStream ms;

        public PushScreen()
        {
            portServer = 1234;
            portClient = 10090;
            multcastAddress = IPAddress.Parse("234.5.6.7");
        }
        public PushScreen(IPAddress multcastAddress, int portServer, int portClient)
        {
            this.multcastAddress = multcastAddress;
            this.portClient = portClient;
            this.portServer = portServer;
        }

        public void Start()
        {
            udpClient = new UdpClient(portClient);
            udpClient.JoinMulticastGroup(multcastAddress);
            ipEndPoint = new IPEndPoint(multcastAddress, portServer);
            thread = new Thread(Send);
            thread.IsBackground = true;
            thread.Start();
        }

        private void Send()
        {
            screenShot = new ScreenShot();
            int i=1;
            while (true)
            {
                bitmap = screenShot.CaptureScreen();
                ms = new MemoryStream();
                bitmap.Save(ms, ImageFormat.Png);
                bitmap.Save(i+".png", ImageFormat.Png);
                i++;
                ms.Position = 0;
                byte[] bits;

                try
                {
                    bits = ms.GetBuffer();
                    ms.Flush();


                    udpClient.Send(bits, bits.Length, ipEndPoint);

                }
                catch
                {
                    //发送失败
                    ms.Flush();
                }
                //Thread.Sleep(40);
            }
          
        }


        public void Stop()
        {
            thread.Abort();

            byte[] data = Encoding.Unicode.GetBytes("Close");
            udpClient.Send(data, data.Length, ipEndPoint);
            udpClient.Send(data, data.Length, ipEndPoint);
            udpClient.Send(data, data.Length, ipEndPoint);
            udpClient.Send(data, data.Length, ipEndPoint);
            udpClient.Send(data, data.Length, ipEndPoint);
            udpClient.Send(data, data.Length, ipEndPoint);
            udpClient.Send(data, data.Length, ipEndPoint);
            udpClient.Send(data, data.Length, ipEndPoint);
            udpClient.Send(data, data.Length, ipEndPoint);
            udpClient.Send(data, data.Length, ipEndPoint);
            udpClient.Send(data, data.Length, ipEndPoint);

            try
            {
                networkStream.Close();
            }
            catch
            {

            }
            udpClient.Close();
        }
    }
}
