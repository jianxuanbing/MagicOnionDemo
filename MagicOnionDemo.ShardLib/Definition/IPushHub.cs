using System.Threading.Tasks;
using MagicOnion;

namespace MagicOnionDemo.ShardLib.Definition
{
    /// <summary>
    /// 推送总线
    /// </summary>
    public interface IPushHub : IStreamingHub<IPushHub, IPushHubReceiver>
    {
        /// <summary>
        /// 连接
        /// </summary>
        /// <param name="id">节点ID</param>
        /// <param name="isServer">是否服务器</param>
        /// <returns></returns>
        Task ConnectionAsync(string id, bool isServer);

        /// <summary>
        /// 释放连接
        /// </summary>
        /// <returns></returns>
        Task DisconnectionAsync();

        /// <summary>
        /// 发送事件
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="eventType">事件类型</param>
        /// <returns></returns>
        Task SendEventAsync(string content, EventType eventType);
    }
}
