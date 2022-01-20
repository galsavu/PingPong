using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Receiver.Abstraction
{
    public interface IReceiver
    {
        object Receive(IDisposable receiver);
    }
}
