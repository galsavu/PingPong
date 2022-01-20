using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Abstraction;
using Common.Send;
using System.Runtime.Serialization;

namespace Common.Factories
{
    public class SenderFactory
    {
        public ISender CreateSender(string senderType)
        {
            if(senderType.Contains("socket"))
            {
                return new SocketSender();
            }
            else if (senderType.Contains("tcp"))
            {
                return new TcpClientSender();
            }
            return null;
        } 
    }
}
