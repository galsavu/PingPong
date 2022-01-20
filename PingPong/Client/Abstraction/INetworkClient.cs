namespace Client.Abstraction
{
    public interface INetworkClient
    {
        void StartSocket();
        void Communicate();
    }
}