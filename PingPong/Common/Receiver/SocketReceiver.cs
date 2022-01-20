using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Abstraction;
using System.Net;
using System.Net.Sockets;
namespace Common.Receiver
{
    public class SocketReceiver:IReceiver
    {
        private readonly byte[] _buffer;

        public SocketReceiver(byte[] buffer)
        {
            _buffer = buffer;
        }

        public object Receive(IDisposable receiver)
        {
            Socket socket = receiver as Socket;
            int bytesReceived = socket.Receive(_buffer);
            string data = Encoding.ASCII.GetString(_buffer, 0, bytesReceived);
            return data;
        }
    }
}
