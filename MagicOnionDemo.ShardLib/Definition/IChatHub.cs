using System.Threading.Tasks;
using MagicOnion;

namespace MagicOnionDemo.ShardLib.Definition
{
    /// <summary>
    /// 聊天总线
    /// </summary>
    public interface IChatHub : IStreamingHub<IChatHub, IChatHubReceiver>
    {
        /// <summary>
        /// 加入房间
        /// </summary>
        /// <param name="userName">名字</param>
        /// <returns></returns>
        Task JoinAsync(string userName);

        /// <summary>
        /// 退出房间
        /// </summary>
        /// <returns></returns>
        Task LeaveAsync();

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="message">消息</param>
        /// <returns></returns>
        Task SendMessageAsync(string message);
    }
}
