using System;
using Bing.Reflections;
using Grpc.Core;
using MagicOnion.Server;
using MagicOnionDemo.Core;

namespace MagicOnionDemo.RpcService
{    
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "RpcServer";
            var server = new RpcServer();
            server.Start();
            Console.WriteLine("服务器启动成功");
            Console.ReadLine();
            server.Close();
        }
    }
}
