using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Input.Abstraction;
namespace UI.Input
{
    public class ConsoleInput : IInput
    {
        public string GetInput()
        {
            return Console.ReadLine();
        }
    }
}
