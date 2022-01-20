using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Abstraction
{
    public interface IReceiver
    {
        object Receive(IDisposable receiver);
    }
}
