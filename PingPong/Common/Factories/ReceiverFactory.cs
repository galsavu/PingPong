using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Abstraction;
using Common.Receiver;

namespace Common.Factories
{
    public class ReceiverFactory
    {
        private readonly byte[] _buffer;

        public ReceiverFactory()
        {
            _buffer = new byte[1024];
        }

        public IReceiver CreateReceiver(string senderType)
        {
            if (senderType == "socket sender")
            {
                return new SocketReceiver(_buffer);
            }
            return null;
        }
    }
}
