using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Abstraction;
using Common.Receiver.Abstraction;
using Common.Send.Abstraction;

namespace Server.Communicators
{
    public class SocketCommunicator : ICommunicator
    {
        private ISender _sender;
        private IReceiver _receiver;
        private IDisposable _socket;

        public SocketCommunicator(ISender sender, IReceiver receiver, IDisposable socket)
        {
            _sender = sender;
            _receiver = receiver;
            _socket = socket;
        }

        public void communicate()
        {
            throw new NotImplementedException();
        }
    }
}
