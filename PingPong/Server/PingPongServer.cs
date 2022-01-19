using Server.Abstraction;
using Common.DTOS;
namespace Server
{
    public class PingPongServer : INetworkServer
    {
        private AddressDTO _address;

        public PingPongServer(AddressDTO address)
        {
            _address = address;
        }

        public void Communicate()
        {
            throw new NotImplementedException();
        }
    }
}