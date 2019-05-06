using Grpc.Core;
using MagicOnion;
using MagicOnion.Client;

namespace MagicOnionDemo.Core
{
    /// <summary>
    /// RPC客户端
    /// </summary>
    public class RpcClient
    {
        public static RpcClient Instance => new RpcClient();

        /// <summary>
        /// 管道
        /// </summary>
        public Channel Channel { get; }

        public RpcClient()
        {
            Channel = new Channel("localhost", 8700, ChannelCredentials.Insecure);
        }

        /// <summary>
        /// 创建服务
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <returns></returns>
        public T Create<T>() where T : IService<T>
        {
            return MagicOnionClient.Create<T>(Channel);
        }
    }
}
