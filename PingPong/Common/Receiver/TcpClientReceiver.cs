using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Abstraction;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Common.Receiver
{
    public class TcpClientReceiver : IReceiver
    {
        private readonly IFormatter _formatter;

        public TcpClientReceiver()
        {
            _formatter = new BinaryFormatter(); ;
        }

        public T Receive<T>(IDisposable receiver)
        {
            TcpClient tcpClient = (TcpClient)receiver;
            NetworkStream strm = tcpClient.GetStream();
            var objectReceived = (T)_formatter.Deserialize(strm);
            return objectReceived;
        }
    }
}
