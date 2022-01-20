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
            var bootstrapper = new Bootstrapper();
            bootstrapper.Run(args);
        }
    }
}