using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Send.Abstraction
{
    public interface ISender
    {
        void Send(IDisposable sender ,object message);
    }
}
