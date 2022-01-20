using System.Threading.Tasks;
using Common.Abstraction;
using System.Net;
using System.Net.Sockets;
using Common.Starters;
using UI.Output.Abstraction;
using UI.Input.Abstraction;

namespace Common.Communicators
{
    public class SocketClientCommunicator : ICommunicator
    {
        private ISender _sender;
        private IReceiver _receiver;
        private Socket _socket { get; set; }
        private readonly IOutput _output;
        private readonly IInput _input;

        public SocketClientCommunicator(SocketClientStarter socketClientStarter, IOutput output, IInput input)
        {
            _sender = socketClientStarter.Sender;
            _receiver = socketClientStarter.Receiver;
            _socket = socketClientStarter.ClientSocket;
            _output = output;
            _input = input;
        }

        public void communicate()
        {
            _output.Show("enter text: ");
            var input = _input.GetInput();
            _sender.Send(_socket, input);
            object objectReceived = _receiver.Receive(_socket);
            _output.Show(objectReceived);
        }
    }
}
