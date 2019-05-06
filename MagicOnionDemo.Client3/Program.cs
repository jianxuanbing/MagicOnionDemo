using System;
using System.Threading;
using System.Threading.Tasks;
using MagicOnionDemo.Core;
using MagicOnionDemo.ShardLib.Definition;

namespace MagicOnionDemo.Client3
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("准备启动订阅器");
            Console.Title = "RPC - Subscribe 2";
            await Task.Delay(3000);
            //await Subscriber();
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
            var receiver = new ClientPushHubReceiver3();
            receiver.Start();
            await receiver.ConnectionAsync("003",false);
        }

        static async Task CustomClientId()
        {
            var client = RpcClient.Instance.Create<IMonitorService>();
            var tokenSource = new CancellationTokenSource();

            while (!tokenSource.IsCancellationRequested)
            {
                var stream = await client.SubscribeAsync(new Guid("4ad32a5e-17f6-404d-a477-285f6dca8e59"));
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
    }
}
