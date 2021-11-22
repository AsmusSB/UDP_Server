﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UDP_Server {
    public class Program {

        private static IPAddress ip = IPAddress.Any;
        private static int port = 7161;

        public static void Main(string[] args) {
            while(true) {
                string data = ReadFromPort();
                if (data != null) {
                    Console.WriteLine(data);
                }
            }
        }

        public static string ReadFromPort() {
            try {
                UdpClient socket = new UdpClient();
                socket.Client.Bind(new IPEndPoint(ip, port));

                IPEndPoint from = null;
                byte[] data = socket.Receive(ref from);
                string dataString = Encoding.UTF8.GetString(data);

                return dataString;
            } catch(Exception e) {
                //Console.Error.WriteLine(e);
            }
            return null;
        }
    }
}