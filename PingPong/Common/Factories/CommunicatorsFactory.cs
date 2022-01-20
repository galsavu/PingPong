using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Abstraction;
using Common.Communicators;
using UI.Output;
using UI.Input;
using UI.Output.Abstraction;
using UI.Input.Abstraction;
using Common.Starters;
using System.Net.Sockets;

namespace Common.Factories
{
    public class CommunicatorsFactory
    {
        
        public ICommunicator CreateCommunicators(string communicatorType, ICommunicateStarter starter, IOutput output, IInput input, IDisposable disposable)
        {
            if(communicatorType == "socket server")
            {
                var socket = (Socket)disposable;
                SocketServerStarter socketServerStarter = (SocketServerStarter)starter ;
                return new SocketServerCommunicator(socketServerStarter, output, input, socket);
            }
            return null;
        }
    }
}
