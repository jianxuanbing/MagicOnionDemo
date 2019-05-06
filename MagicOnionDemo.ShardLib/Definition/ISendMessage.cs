namespace MagicOnionDemo.ShardLib.Definition
{
    /// <summary>
    /// 发送消息
    /// </summary>
    public interface ISendMessage
    {
        /// <summary>
        /// 监听发送消息
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="message">消息</param>
        void OnSendMessage(string name, string message);
    }
}
