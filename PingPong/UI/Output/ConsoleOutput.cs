using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Output.Abstraction;

namespace UI.Output
{
    public class ConsoleOutput : IOutput
    {
        public void Show(object obj)
        {
            Console.WriteLine(obj);
        }
    }
}
