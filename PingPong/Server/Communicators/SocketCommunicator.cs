using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Abstraction;
using Common.Receiver.Abstraction;
using Common.Send.Abstraction;
using System.Net;
using System.Net.Sockets;

namespace Server.Communicators
{
    public class SocketCommunicator : ICommunicator
    {
        private ISender _sender;
        private IReceiver _receiver;
        public Socket Listener { get; set; }

        public SocketCommunicator(ISender sender, IReceiver receiver, Socket listener)
        {
            _sender = sender;
            _receiver = receiver;
            Listener = listener;
        }

        public void communicate()
        {
            throw new NotImplementedException();
        }
    }
}
