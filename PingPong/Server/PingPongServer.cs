using Server.Abstraction;
using System.Net.Sockets;
using System.Net;
using System.Text;
using UI.Output.Abstraction;
using Common.Factories;
using Common.Abstraction;

namespace Server
{
    public class PingPongServer : INetworkServer
    {
        private ICommunicateStarter _communicateStarter;
        private string _communicatorType;
        
        public PingPongServer(string communicatorType, string ipAddress, int port, string outputType, string inputType, StarterFactory starterFactory, ComunicatorsFactory comunicatorsFactory)
        {            
            _communicatorType = communicatorType;
            _communicateStarter = starterFactory.CreateStarter(_communicatorType, ipAddress, port, outputType, inputType, comunicatorsFactory); 
        }

        public void Start()
        {
            _communicateStarter.Start();
        }

        
    }
}