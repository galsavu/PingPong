using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Send.Abstraction;
using System.Net;
using System.Net.Sockets;

namespace Common.Send
{
    public class SocketSender : ISender
    {

        public void Send(IDisposable sender, object message)
        {
            Socket socket = sender as Socket;
            string messageStr = message.ToString();
            socket.Send(Encoding.ASCII.GetBytes(messageStr));
        }
    }
}
