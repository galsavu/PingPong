﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Abstraction;
using System.Net;
using System.Net.Sockets;
using Common.Starters;

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
