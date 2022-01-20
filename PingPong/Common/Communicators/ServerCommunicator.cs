﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Abstraction;
using System.Net;
using System.Net.Sockets;
using Common.Starters;
using UI.Output.Abstraction;
using UI.Input.Abstraction;

namespace Common.Communicators
{
    public class ServerCommunicator : ICommunicator
    {
        private ISender _sender;
        private IReceiver _receiver;
        private IDisposable _socket { get; set; }
        private readonly IOutput _output;
        private readonly IInput _input;

        public ServerCommunicator(SocketServerStarter socketServerStarter, IOutput output, IInput input, IDisposable socket)
        {
            _sender = socketServerStarter.Sender;
            _receiver = socketServerStarter.Receiver;
            _output = output;
            _input = input;
            _socket = socket;
        }

        public void communicate()
        {
            object receivedObject = _receiver.Receive(_socket);
            _output.Show(receivedObject);
            _sender.Send(_socket, receivedObject);
        }
    }
}