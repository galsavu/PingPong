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
    public class SocketServerCommunicator : ICommunicator
    {
        private ISender _sender;
        private IReceiver _receiver;
        private Socket _socket { get; set; }
        private readonly IOutput _output;
        private readonly IInput _input;

        public SocketServerCommunicator(SocketServerStarter socketServerStarter, IOutput output, IInput input)
        {
            _sender = socketServerStarter.Sender;
            _receiver = socketServerStarter.Receiver;
            _socket = socketServerStarter.Listener;
            _output = output;
            _input = input;
        }

        public void communicate()
        {
            _receiver.Receive(_socket);

        }
    }
}
