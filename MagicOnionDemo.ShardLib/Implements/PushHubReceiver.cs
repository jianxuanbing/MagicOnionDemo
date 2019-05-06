using System.Threading.Tasks;
using MagicOnion.Client;
using MagicOnionDemo.Core;
using MagicOnionDemo.ShardLib.Definition;

namespace MagicOnionDemo.ShardLib.Implements
{
    /// <summary>
    /// 推送总线接收器
    /// </summary>
    public class PushHubReceiver : IPushHubReceiver
    {
        /// <summary>
        /// 推送总线
        /// </summary>
        private IPushHub _hub;

        /// <summary>
        /// 是否已连接
        /// </summary>
        private bool _isConnection;

        /// <summary>
        /// 启动
        /// </summary>
        public void Start()
        {
            this._isConnection = false;
            this._hub = StreamingHubClient.Connect<IPushHub, IPushHubReceiver>(RpcClient.Instance.Channel, this);
        }

        /// <summary>
        /// 连接
        /// </summary>
        /// <param name="id">节点ID</param>
        /// <param name="isServer">是否服务器</param>
        /// <returns></returns>
        public async Task ConnectionAsync(string id, bool isServer)
        {
            if (!this._isConnection)
            {
                await this._hub.ConnectionAsync(id, isServer);
                this._isConnection = true;
            }
        }

        /// <summary>
        /// 释放连接
        /// </summary>
        /// <returns></returns>
        public async Task DisconnectionAsync()
        {
            if (this._isConnection)
            {
                await this._hub.DisconnectionAsync();
                this._isConnection = false;
            }
        }

        /// <summary>
        /// 发送事件
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="eventType">事件类型</param>
        /// <returns></returns>
        public async Task SendEventAsync(string content, EventType eventType)
        {
            if (!this._isConnection)
            {
                return;
            }

            await this._hub.SendEventAsync(content, eventType);
        }

        /// <summary>
        /// 监听连接
        /// </summary>
        /// <param name="id">节点ID</param>
        /// <param name="isServer">是否服务器</param>
        public void OnConnection(string id, bool isServer)
        {
            Screen.Success($"监听节点 : {(isServer ? "服务器" : "客户端")}【{id}】 打开推送管道!");
        }

        /// <summary>
        /// 监听释放连接
        /// </summary>
        /// <param name="id">节点ID</param>
        /// <param name="isServer">是否服务器</param>
        public void OnDisconnection(string id, bool isServer)
        {
            Screen.Error($"监听节点 : {(isServer ? "服务器" : "客户端")}【{id}】 关闭推送管道!");
        }

        /// <summary>
        /// 监听发送事件
        /// </summary>
        /// <param name="id">节点ID</param>
        /// <param name="content">内容</param>
        /// <param name="eventType">事件类型</param>
        public virtual void OnSendEvent(string id, string content, EventType eventType)
        {
            Screen.Info($"监听节点 : {id} 发送事件 {content}");
        }
    }
}
