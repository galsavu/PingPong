using UI.Input;
using UI.Input.Abstraction;

namespace Common.Factories
{
    public class InputFactory
    {
        public IInput CreateInput(string inputType)
        {
            if (inputType == "console")
            {
                return new ConsoleInput();
            }
            return null;
        }
    }
}
