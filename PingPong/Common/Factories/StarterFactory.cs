using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Abstraction;

namespace Common.Factories
{
    public class StarterFactory
    {
        public ICommunicateStarter CreateStarter(string type, string ip, int port)
        {
            throw new NotImplementedException();
        }
    }
}
