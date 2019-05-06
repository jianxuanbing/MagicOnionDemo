namespace MagicOnionDemo.ShardLib.Definition
{
    /// <summary>
    /// 推送总线接收器
    /// </summary>
    public interface IPushHubReceiver
    {
        /// <summary>
        /// 监听连接
        /// </summary>
        /// <param name="id">节点ID</param>
        /// <param name="isServer">是否服务器</param>
        void OnConnection(string id, bool isServer);

        /// <summary>
        /// 监听释放连接
        /// </summary>
        /// <param name="id">节点ID</param>
        /// <param name="isServer">是否服务器</param>
        void OnDisconnection(string id, bool isServer);

        /// <summary>
        /// 监听发送事件
        /// </summary>
        /// <param name="id">节点ID</param>
        /// <param name="content">内容</param>
        /// <param name="eventType">事件类型</param>
        void OnSendEvent(string id, string content, EventType eventType);
    }
}
