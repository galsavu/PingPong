﻿using Server.Abstraction;
using System.Net.Sockets;
using System.Net;
using System.Text;
using UI.Output.Abstraction;
namespace Server
{
    public class PingPongServer : INetworkServer
    {
        private IOutput _output;
        public IPEndPoint ipEndPoint { get; set; }
        public Socket Listener { get; set; }

        public PingPongServer(string ipAddress, int port, IOutput output)
        {
            IPAddress ip = IPAddress.Parse(ipAddress);
            ipEndPoint = new IPEndPoint(ip, port);
            Listener = new Socket(ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            Listener.Bind(ipEndPoint);
            _output = output;
        }

        public void StartSocket()
        {     
            while (true)
            {
                Listener.Listen();
                Listener.Accept();
                Task.Run(() => Communicate());
            }
        }

        public void Communicate()
        {
            
        }
    }
}