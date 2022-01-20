using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Abstraction;
using Common.Receiver.Abstraction;
using Common.Send.Abstraction;
using System.Net;
using System.Net.Sockets;
using Common.Starters;

namespace Server.Communicators
{
    public class SocketCommunicator : ICommunicator
    {
        private ISender _sender;
        private IReceiver _receiver;
        private Socket _listener { get; set; }

        public SocketCommunicator(SocketServerStarter socketServerStarter)
        {
            _sender = socketServerStarter.Sender;
            _receiver = socketServerStarter.Receiver;
            _listener = socketServerStarter.Listener;
        }

        public void communicate()
        {
            throw new NotImplementedException();
        }
    }
}
