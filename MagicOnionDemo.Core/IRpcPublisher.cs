using MagicOnion;
using MagicOnion.Server;

namespace MagicOnionDemo.Core
{
    /// <summary>
    /// RPC事件发布器
    /// </summary>
    public interface IRpcPublisher: IService<IRpcPublisher>
    {
        /// <summary>
        /// 发布事件
        /// </summary>
        /// <param name="name">消息名称</param>
        /// <param name="data">事件数据</param>
        /// <param name="callback">回调名称</param>
        /// <returns></returns>
        UnaryResult<string> PublishAsync(string name, string data, string callback);
    }

    /// <summary>
    /// RPC事件发布器
    /// </summary>
    public class RpcPublisher : ServiceBase<IRpcPublisher>, IRpcPublisher
    {
        /// <summary>
        /// 发布事件
        /// </summary>
        /// <param name="name">消息名称</param>
        /// <param name="data">事件数据</param>
        /// <param name="callback">回调名称</param>
        /// <returns></returns>
        public async UnaryResult<string> PublishAsync(string name, string data, string callback)
        {
            InMemoryContext.Instance.Queue.Enqueue(data);
            return "Success";
        }
    }
}
