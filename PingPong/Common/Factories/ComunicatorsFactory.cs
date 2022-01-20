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
        private readonly OutputFactory _outputFactory;
        private readonly InputFactory _inputFactory;

        public ComunicatorsFactory()
        {
            _outputFactory = new OutputFactory();
            _inputFactory = new InputFactory();
        }

        public ICommunicator CreateComunicators(string communicatorType, ICommunicateStarter starter, string outputType, string inputType)
        {
            if(communicatorType == "socket server")
            {
                IOutput output = _outputFactory.CreateOutput(outputType);
                IInput input = _inputFactory.CreateInput(inputType);
                SocketServerStarter socketServerStarter = (SocketServerStarter)starter ;
                return new SocketServerCommunicator(socketServerStarter, output, input);
            }
            return null;
        }
    }
}
