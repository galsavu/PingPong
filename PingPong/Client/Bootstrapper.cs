using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Factories;
using Client.Abstraction;

namespace Client
{
    public class Bootstrapper
    {
        public void Run(string[] args)
        {
            string communicatorType = "tcp client";
            string ipAddress = "127.0.0.1"; //args[0];
            int port = 2345;
            //int.TryParse(args[1], out port);
            string outputType = "console";
            string inputType = "console";
            var starterFactory = new StarterFactory();
            var communicatorFactory = new CommunicatorsFactory();

            var server = new PingPongClient(communicatorType, ipAddress, port, outputType, inputType, starterFactory, communicatorFactory);

            server.Start();
        }
    }
}
