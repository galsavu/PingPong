using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Factories;
using Server.Abstraction;

namespace Server
{
    public class Bootstrapper
    {
        public void Run(string[] args)
        {
            string communicatorType = "socket server";
            string ipAddress = args[0];
            int port;
            int.TryParse(args[1], out port);
            string outputType = "console";
            string inputType = "console";
            var starterFactory = new StarterFactory();
            var communicatorFactory = new CommunicatorsFactory();

            var server = new PingPongServer(communicatorType, ipAddress, port, outputType, inputType, starterFactory, communicatorFactory);

            server.Start();
        }
    }
}
