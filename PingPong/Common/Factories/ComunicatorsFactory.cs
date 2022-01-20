using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Abstraction;

namespace Common.Factories
{
    public class ComunicatorsFactory
    {


        public ICommunicator CreateComunicators(string communicatorType, ICommunicateStarter starter, string outputType)
        {
            throw new NotImplementedException(); //create communicator according to the starter type
        }
    }
}
