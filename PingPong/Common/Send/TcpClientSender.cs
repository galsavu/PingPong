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

namespace Common.Send
{
    public class TcpClientSender : ISender
    {
        private readonly IFormatter _formatter;

        public TcpClientSender()
        {
            _formatter = new BinaryFormatter();
        }
        public void Send<T>(IDisposable sender, T message) where T : ISerializable
        {
            TcpClient tcpClient = (TcpClient)sender;
            NetworkStream strm = tcpClient.GetStream();
            _formatter.Serialize(strm, message);
        }
    }
}
