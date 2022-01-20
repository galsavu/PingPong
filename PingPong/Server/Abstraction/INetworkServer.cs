namespace Server.Abstraction
{
    public interface INetworkServer
    {
        void Start();
        void Communicate();
    }
}