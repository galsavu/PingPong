﻿using Client.Abstraction;
using System.Net.Sockets;
using System.Net;
using System.Text;
using UI.Output.Abstraction;
using Common.Factories;
using Common.Abstraction;

namespace Client
{
    public class PingPongClient : INetworkClient
    {
        private ICommunicateStarter _communicateStarter;
        private ICommunicator _communicator;
        private string _communicatorType;

        public PingPongClient(string communicatorType, string ipAddress, int port, string outputType, string inputType, StarterFactory starterFactory, ComunicatorsFactory comunicatorsFactory)
        {
            _communicatorType = communicatorType;
            _communicateStarter = starterFactory.CreateStarter(_communicatorType, ipAddress, port);
            _communicator = comunicatorsFactory.CreateComunicators(_communicatorType, _communicateStarter, outputType, inputType);
        }

        public void Start()
        {
            _communicateStarter.Start();
        }

    }
}