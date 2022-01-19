using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Output.Abstraction
{
    public  interface IOutput<T>
    {
        void Show(T obj);
    }
}
