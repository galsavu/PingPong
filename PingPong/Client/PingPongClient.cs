﻿using Client.Abstraction;
using System.Net.Sockets;
using System.Net;
using UI.Input.Abstraction;
using UI.Output.Abstraction;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;

namespace Client
{
    public class PingPongClient : INetworkClient
    {
        private MemoryStream _memoryStream;
        private BinaryFormatter _formatter;
        public IPEndPoint ServerIpEndPoint { get; set; }
        public Socket ClientSocket { get; set; }
        public IInput Input { get; set; }
        public IOutput Output { get; set; }


        public PingPongClient(IPAddress ipAddress, int port)
        {
            ServerIpEndPoint = new IPEndPoint(ipAddress, port);
            ClientSocket = new Socket(ServerIpEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            _memoryStream = new MemoryStream();
            _formatter = new BinaryFormatter();

        }

        public void StartSocket()
        {
            ClientSocket.Connect(ServerIpEndPoint);
        }

        public async void Communicate()
        {
            string inputText = Input.GetInput();
            
        }
    }
}