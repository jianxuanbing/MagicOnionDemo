using System.Collections.Concurrent;
using System.Threading.Tasks;
using MagicOnion;
using MagicOnion.Server;
using MessagePack;

namespace MagicOnionDemo.Core
{
    /// <summary>
    /// RPC事件订阅器
    /// </summary>
    public interface IRpcSubscriber:IService<IRpcSubscriber>
    {
        /// <summary>
        /// 订阅
        /// </summary>
        /// <returns></returns>
        Task<ServerStreamingResult<string>> SubscribeAsync();
    }

    public class RpcSubscriber : ServiceBase<IRpcSubscriber>, IRpcSubscriber
    {
        /// <summary>
        /// 订阅
        /// </summary>
        /// <returns></returns>
        public async Task<ServerStreamingResult<string>> SubscribeAsync()
        {
            var stream = GetServerStreamingContext<string>();
            if (InMemoryContext.Instance.Queue.TryDequeue(out var result))
            {
                await stream.WriteAsync(result);
            }
            return stream.Result();
        }
    }

    public class InMemoryContext
    {
        public static InMemoryContext Instance = new InMemoryContext();
        public ConcurrentQueue<string> Queue { get; set; } = new ConcurrentQueue<string>();
    }
}
