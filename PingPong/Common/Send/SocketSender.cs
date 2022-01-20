using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Abstraction;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;

namespace Common.Send
{
    public class SocketSender : ISender
    {

        public void Send(IDisposable sender, object message)
        {
            Socket socket = (Socket)sender;
            string messageStr = message as string;
            socket.Send(Encoding.ASCII.GetBytes(messageStr));
        }
    }
}
