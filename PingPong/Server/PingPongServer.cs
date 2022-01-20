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
        private IOutput _output;
        private ICommunicateStarter _communicateStarter;
        private ICommunicator _communicator;
        private string _communicatorType;
        
        public PingPongServer(string communicatorType, string ipAddress, int port, IOutput output, StarterFactory starterFactory, ComunicatorsFactory comunicatorsFactory)
        {            
            _communicatorType = communicatorType;
            _communicateStarter = starterFactory.CreateStarter(_communicatorType, ipAddress, port); 
            _communicator = comunicatorsFactory.CreateComunicators(_communicatorType, _communicateStarter);
            _output = output;
        }

        public void Communicate()
        {
            _communicator.communicate();
        }
    }
}