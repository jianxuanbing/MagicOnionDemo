using System;
using System.Threading;
using System.Threading.Tasks;
using MagicOnionDemo.Core;
using MagicOnionDemo.Core.Events.Rpc;
using MagicOnionDemo.ShardLib.Definition;
using MagicOnionDemo.ShardLib.Implements;
using MagicOnionDemo.ShardLib.Model;

namespace MagicOnionDemo.Client
{
    class Program
    {        

        static async Task Main(string[] args)
        {            
            Console.WriteLine("准备启动发布器");            
            Console.Title = "RPC - Publish";
            await Task.Delay(3000);
            //await CommonPublish();
            //RandomMessage();
            await WriteMessage();
            Console.WriteLine("结束");
            Console.ReadLine();
        }

        static async Task WriteMessage()
        {
            var receiver = new PushHubReceiver();
            receiver.Start();
            await receiver.ConnectionAsync("001", true);
            bool exit = false;            
            while (!exit)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        await receiver.SendEventAsync("001,002,003,004,005", EventType.Common);
                        break;
                    case "2":
                        await receiver.SendEventAsync("a,b,c,d,e,f,g", EventType.Queue);
                        break;
                    case "3":
                        exit = true;
                        break;
                }
            }

            await receiver.DisconnectionAsync();
        }

        static async Task CommonPublish()
        {
            var eventBus = new MessageEventBus();
            var tokenSource = new CancellationTokenSource();
            var i = 0;
            while (!tokenSource.IsCancellationRequested)
            {
                await eventBus.PublishAsync("test", new {Time = DateTime.Now, Index = i}, "");
                i++;
            }
        }

        static async Task Publish()
        {
            var client = RpcClient.Instance.Create<IMonitorService>();

            var clientIds = new Guid[]
            {
                new Guid("7f9eda52-30e9-4e96-9dfc-a64ce417e7db"),
                new Guid("4ad32a5e-17f6-404d-a477-285f6dca8e59"),
            };
            var tokenSource = new CancellationTokenSource();
            var i = 0;
            while (!tokenSource.IsCancellationRequested)
            {
                var clientId = RandomClientId(clientIds);
                Console.WriteLine($"客户端{clientId},发布消息:{i},连接状态:{RpcClient.Instance.Channel.State}");
                await client.PublishAsync(new PublishModel()
                {
                    ClientId = clientId,
                    OperationName = $"ClientId:{clientId},发布操作功能,当前索引值:{i}"
                });
                await Task.Delay(200, tokenSource.Token);
                i++;
            }
        }
        
        private static Guid RandomClientId(Guid[] clientIds)
        {
            var index = new Random().Next(0, clientIds.Length);

            return clientIds[index];
        }

        private static void RandomMessage()
        {
            var receiver = new ChatHubReceiver();
            receiver.Start();
            receiver.JoinOrLeave();
            while (true)
            {
                receiver.SendMessage();
                Thread.Sleep(400);
            }
        }
    }
}
