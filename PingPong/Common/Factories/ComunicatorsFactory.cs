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
namespace Common.Factories
{
    public class ComunicatorsFactory
    {
        
        public ICommunicator CreateComunicators(string communicatorType, ICommunicateStarter starter, IOutput output, IInput input)
        {
            if(communicatorType == "socket server")
            {             
                SocketServerStarter socketServerStarter = (SocketServerStarter)starter ;
                return new SocketServerCommunicator(socketServerStarter, output, input);
            }
            return null;
        }
    }
}
