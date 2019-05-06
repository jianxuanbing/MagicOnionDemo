using System;
using System.Threading;
using System.Threading.Tasks;
using MagicOnionDemo.Core;
using MagicOnionDemo.ShardLib.Definition;
using MagicOnionDemo.ShardLib.Implements;

namespace MagicOnionDemo.Client2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("准备启动订阅器");
            Console.Title = "RPC - Subscribe 1";
            await Task.Delay(3000);
            //await Subscriber();
            //await CustomClientId();
            //RandomMessage();
            RejectMessage().Wait();
            Console.WriteLine("结束");
            Console.ReadLine();
        }

        /// <summary>
        /// 接收消息
        /// </summary>
        /// <returns></returns>
        static async Task RejectMessage()
        {
            var receiver = new PushHubReceiver();
            receiver.Start();
            await receiver.ConnectionAsync("002", false);
        }

        static async Task CustomClientId()
        {
            var client = RpcClient.Instance.Create<IMonitorService>();
            var tokenSource = new CancellationTokenSource();

            while (!tokenSource.IsCancellationRequested)
            {
                var stream = await client.SubscribeAsync(new Guid("7f9eda52-30e9-4e96-9dfc-a64ce417e7db"));
                var responseStream = stream.ResponseStream;

                while (await responseStream.MoveNext(tokenSource.Token))
                {
                    var filename = responseStream.Current;

                    Console.WriteLine($"{filename}");
                }

                await Task.Delay(500, tokenSource.Token);
            }
        }

        static async Task Subscriber()
        {
            var client = RpcClient.Instance.Create<IRpcSubscriber>();
            var tokenSource = new CancellationTokenSource();

            while (!tokenSource.IsCancellationRequested)
            {
                var stream = await client.SubscribeAsync();
                var responseStream = stream.ResponseStream;

                while (await responseStream.MoveNext(tokenSource.Token))
                {
                    var filename = responseStream.Current;

                    Console.WriteLine($"{filename}");
                }

                await Task.Delay(500, tokenSource.Token);
            }
        }

        private static void RandomMessage()
        {
            var receiver = new ChatHubReceiver();
            receiver.Start();
            receiver.JoinOrLeave();            
        }
    }
}
