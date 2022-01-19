using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Output.Abstraction;

namespace UI.Output
{
    public class ConsoleOutput<T> : IOutput<T>
    {
        public void Show(T obj)
        {
            Console.WriteLine(obj);
        }
    }
}
