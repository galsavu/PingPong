using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.Abstraction
{
    public interface ISender
    {
        void Send<T>(IDisposable sender ,T message) where T : ISerializable;
    }
}
