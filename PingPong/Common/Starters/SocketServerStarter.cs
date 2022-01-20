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

namespace Common.Starters
{
    public class SocketServerStarter : ICommunicateStarter
    {
        public ISender Sender { get; set; }
        public IReceiver Receiver { get; set; }
        public Socket Listener { get; set; }

        public SocketServerStarter(ISender sender, IReceiver receiver, Socket listener)
        {
            Sender = sender;
            Receiver = receiver;
            Listener = listener;
        }

        public void Start(Action communicate)
        {
            Listener.Listen();
            GetClientsConnections(communicate);   
           
        }

        public void GetClientsConnections(Action communicate)
        {
            while (true)
            {
                Task.Run(() => GetConnection(communicate));
            }
        }

        public async Task GetConnection(Action communicate)
        {
            Console.WriteLine("waiting for connection");
            Listener.Accept();
            await Task.Run(() => communicate?.Invoke());
        }

        
    }
}
