using Server.Abstraction;
using System.Net.Sockets;
using System.Net;
using System.Text;
using UI.Output.Abstraction;
namespace Server
{
    public class PingPongServer : INetworkServer
    {
        private IOutput output;
        public IPEndPoint ipEndPoint { get; set; }
        public Socket Listener { get; set; }

        public PingPongServer(IPAddress ipAddress, int port)
        {
            ipEndPoint = new IPEndPoint(ipAddress, port);
            Listener = new Socket(ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            Listener.Bind(ipEndPoint);
        }

        public void StartSocket()
        {     
            while (true)
            {
                Listener.Listen();
                Listener.Accept();
                Task.Run(() => Communicate());
            }
        }

        public async void Communicate()
        {
            byte[] buffer = new byte[1024];
            int bytesRead = Listener.Receive(buffer);
            string data = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            output.Show(data);
            Listener.Send(Encoding.ASCII.GetBytes(data));
        }
    }
}