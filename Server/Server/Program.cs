using System;
using System.Net;
using System.Net.Sockets;
using UI.Output;
namespace Server
{
    public class Program
    {
        static void Main(string[] args)
        {
            var consoleOutput = new ConsoleOutput();
            IPAddress iPAddress = IPAddress.Parse("127.0.0.1");
            PingPongServer pingPongServer = new PingPongServer(iPAddress, 2345, consoleOutput);
            pingPongServer.StartSocket();

        }
    }
}