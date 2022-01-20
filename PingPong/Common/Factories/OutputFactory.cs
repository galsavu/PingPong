using UI.Output;
using UI.Output.Abstraction;

namespace Common.Factories
{
    public class OutputFactory
    {
        public IOutput CreateOutput(string outputType)
        {
            if(outputType == "console")
            {
                return new ConsoleOutput();
            }
            return null;
        }
    }
}
