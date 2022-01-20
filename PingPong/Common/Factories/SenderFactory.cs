using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Abstraction;
using Common.Send;

namespace Common.Factories
{
    public class SenderFactory
    {
        public ISender CreateSender(string senderType)
        {
            if(senderType == "socket sender")
            {
                return new SocketSender();
            }
            return null;
        } 
    }
}
