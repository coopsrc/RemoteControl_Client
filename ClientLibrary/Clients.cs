using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientLibrary
{
    /// <summary>
    /// 保存用于各个操作的TcpClient，network以及线程信息
    /// </summary>
    static class Clients
    {
        public static int filePort = 10083;
        public static int fileOperationPort = 20083;
        //文件管理连接

        public static TcpClient file_FileManageClient;
        public static NetworkStream file_FileManageNetSream;

        public static bool isFile_ManageConnected = false;
        public static bool isThread_FileManageStarted = false;
        public static Thread thread_FileMange;

        //文件操作
        public static TcpClient file_OperationClient;
        public static NetworkStream file_OperationNetStream;
        public static Thread thread_FileOperation;
        public static bool isFile_OperationConnected = false;
        public static bool isThread_FileOperationStarted = false;

        public static StreamReader sr_op;
        public static StreamWriter sw_op;

        //文件传输专用
        public static TcpClient client_FileTransport;
        public static NetworkStream netStream_FileTransport;
        public const int port_FileTransport = 20084;

        //获取分区信息：
        public static bool isThread_ReceiveDrivesInfoStarted = false;
        public static Thread thread_ReceiveDrivesInfo;
        //获取文件目录（结点）
        public static bool isThread_ReceiveNodesInfoStarted = false;
        public static Thread thread_ReceiveNodesInfo;
    }
}