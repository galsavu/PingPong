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
        private ICommunicator _communicator;
        private string _communicatorType;
        
        public PingPongServer(string communicatorType, string ipAddress, int port, IOutput output)
        {            
            _communicatorType = communicatorType;
            var comunicatorsFactory = new ComunicatorsFactory();
            _communicator = comunicatorsFactory.CreateComunicators(_communicatorType, ipAddress, port);
            _output = output;
        }

        public void Communicate()
        {
            _communicator.communicate();
        }
    }
}