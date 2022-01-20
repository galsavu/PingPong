using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Abstraction;
using System.Net;
using System.Net.Sockets;
using Common.Starters;

namespace Common.Factories
{
    public class StarterFactory
    {
        private readonly SenderFactory _senderFactory;
        private readonly ReceiverFactory _receiverFactory;

        public StarterFactory()
        {
            _senderFactory = new SenderFactory();
            _receiverFactory = new ReceiverFactory();
        }

        public ICommunicateStarter CreateStarter(string type, string ip, int port)
        {
            IPAddress iPAddress = IPAddress.Parse(ip);
            if(type == "socket server")
            {
                Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                listener.Bind(new IPEndPoint(iPAddress, port));
                ISender sender = _senderFactory.CreateSender(type);
                IReceiver receiver = _receiverFactory.CreateReceiver(type);
                return new SocketServerStarter(sender, receiver, listener);
            }
            return null;
        }
    }
}
