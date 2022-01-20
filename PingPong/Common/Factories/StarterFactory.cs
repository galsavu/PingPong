﻿using Common.Abstraction;
using Common.Starters;
using System.Net;
using System.Net.Sockets;
using UI.Input.Abstraction;
using UI.Output.Abstraction;

namespace Common.Factories
{
    public class StarterFactory
    {
        private readonly SenderFactory _senderFactory;
        private readonly ReceiverFactory _receiverFactory;
        private readonly OutputFactory _outputFactory;
        private readonly InputFactory _inputFactory;

        public StarterFactory()
        {
            _senderFactory = new SenderFactory();
            _receiverFactory = new ReceiverFactory();
        }

        public ICommunicateStarter CreateStarter(string type, string ip, int port, string outputType, string inputType)
        {
            IPAddress iPAddress = IPAddress.Parse(ip);
            ISender sender = _senderFactory.CreateSender(type);
            IReceiver receiver = _receiverFactory.CreateReceiver(type);
            IOutput output = _outputFactory.CreateOutput(outputType);
            IInput input = _inputFactory.CreateInput(inputType);

            if (type == "socket server")
            {
                Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ipEndPoint = new IPEndPoint(iPAddress, port);

                return new SocketServerStarter(sender, receiver, listener, ipEndPoint, output, input);
            }

            else if (type == "socket client")
            {
                Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint ipEndPoint = new IPEndPoint(iPAddress, port);
                return new SocketClientStarter(sender, receiver, listener, ipEndPoint, output, input);
            }

            return null;
        }
    }
}
