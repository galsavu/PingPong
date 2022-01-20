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
        private ICommunicator _communicator;
        private string _communicatorType;
        
        public PingPongServer(string communicatorType, string ipAddress, int port, string outputType, StarterFactory starterFactory, ComunicatorsFactory comunicatorsFactory)
        {            
            _communicatorType = communicatorType;
            _communicateStarter = starterFactory.CreateStarter(_communicatorType, ipAddress, port); 
            _communicator = comunicatorsFactory.CreateComunicators(_communicatorType, _communicateStarter, outputType);
        }

        public void Start()
        {
            _communicateStarter.Start(Communicate);
        }

        public void Communicate()
        {
            _communicator.communicate();
        }
    }
}