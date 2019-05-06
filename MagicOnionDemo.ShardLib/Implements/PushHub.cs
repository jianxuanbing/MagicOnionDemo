using System.Threading.Tasks;
using MagicOnion.Server.Hubs;
using MagicOnionDemo.Core;
using MagicOnionDemo.ShardLib.Definition;

namespace MagicOnionDemo.ShardLib.Implements
{
    /// <summary>
    /// 推送总线
    /// </summary>
    public class PushHub : StreamingHubBase<IPushHub, IPushHubReceiver>, IPushHub
    {
        /// <summary>
        /// 当前节点ID
        /// </summary>
        private string _nodeId;

        /// <summary>
        /// 是否服务器
        /// </summary>
        private bool _isServer;

        /// <summary>
        /// 管道名称
        /// </summary>
        private const string ChannelName = nameof(PushHub);

        /// <summary>
        /// 服务器管道名称
        /// </summary>
        private const string ServerChannelName = "Server" + ChannelName;

        /// <summary>
        /// 客户端管道名称
        /// </summary>
        private const string ClientChannelName = "Client" + ChannelName;

        /// <summary>
        /// 服务器分组
        /// </summary>
        public IGroup ServerGroup
        {
            get
            {
                this.Group.RawGroupRepository.TryGet(ServerChannelName, out _serverGroup);
                return _serverGroup;
            }
        }

        /// <summary>
        /// 客户端分组
        /// </summary>
        public IGroup ClientGroup
        {
            get
            {
                this.Group.RawGroupRepository.TryGet(ClientChannelName, out _clientGroup);
                return _clientGroup;
            }
        }

        /// <summary>
        /// 服务器分组
        /// </summary>
        private IGroup _serverGroup;

        /// <summary>
        /// 客户端分组
        /// </summary>
        private IGroup _clientGroup;

        /// <summary>
        /// 连接
        /// </summary>
        /// <param name="id">节点ID</param>
        /// <param name="isServer">是否服务器</param>
        /// <returns></returns>
        public async Task ConnectionAsync(string id, bool isServer)
        {
            this._isServer = isServer;
            this._nodeId = id;
            if (isServer)
            {
                await ServerConnectionAsync(id);
            }
            else
            {
                await ClientConnectionAsync(id);
            }

            Screen.Success($"节点 : {id} 打开推送管道!");
        }

        /// <summary>
        /// 服务器连接
        /// </summary>
        /// <param name="id">节点ID</param>
        /// <returns></returns>
        private async Task ServerConnectionAsync(string id)
        {
            await this.Group.AddAsync(ServerChannelName);
            if (this.ClientGroup != null)
            {
                this.Broadcast(this.ClientGroup).OnConnection(id, _isServer);
            }
        }

        /// <summary>
        /// 客户端连接
        /// </summary>
        /// <param name="id">节点ID</param>
        /// <returns></returns>
        private async Task ClientConnectionAsync(string id)
        {
            await this.Group.AddAsync(ClientChannelName);
            if (this.ServerGroup != null)
            {
                this.Broadcast(this.ServerGroup).OnConnection(id, _isServer);
            }
        }

        /// <summary>
        /// 释放连接
        /// </summary>
        /// <returns></returns>
        public async Task DisconnectionAsync()
        {
            if (_isServer)
            {
                await ServerDisconnectionAsync();
            }
            else
            {
                await ClientDisconnectionAsync();
            }
            Screen.Error($"节点 : {this._nodeId} 关闭推送管道!");
        }

        /// <summary>
        /// 服务端释放连接
        /// </summary>
        /// <returns></returns>
        private async Task ServerDisconnectionAsync()
        {
            await this.ServerGroup.RemoveAsync(this.Context);
            if (this.ClientGroup == null)
            {
                return;
            }
            this.BroadcastExceptSelf(this.ClientGroup).OnDisconnection(this._nodeId, _isServer);
        }

        /// <summary>
        /// 客户端释放连接
        /// </summary>
        /// <returns></returns>
        private async Task ClientDisconnectionAsync()
        {
            await this.ClientGroup.RemoveAsync(this.Context);
            if (this.ServerGroup == null)
            {
                return;
            }
            this.BroadcastExceptSelf(this.ServerGroup).OnDisconnection(this._nodeId, _isServer);
        }

        /// <summary>
        /// 发送事件
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="eventType">事件类型</param>
        /// <returns></returns>
        public async Task SendEventAsync(string content, EventType eventType)
        {
            if (_isServer)
            {
                await ClientSendEventAsync(content, eventType);
            }
            else
            {
                await ServerSendEventAsync(content, eventType);
            }

            Screen.Info($"节点 : {this._nodeId} 发送事件 {content}");
            await Task.CompletedTask;
        }

        /// <summary>
        /// 服务器发送事件
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="eventType">事件类型</param>
        /// <returns></returns>
        public async Task ServerSendEventAsync(string content, EventType eventType)
        {
            if (this.ServerGroup == null)
            {
                return;
            }
            this.BroadcastExceptSelf(this.ServerGroup).OnSendEvent(this._nodeId, content, eventType);
            await Task.CompletedTask;
        }

        /// <summary>
        /// 客户端发送事件
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="eventType">事件类型</param>
        /// <returns></returns>
        public async Task ClientSendEventAsync(string content, EventType eventType)
        {
            if (this.ClientGroup == null)
            {
                return;
            }

            this.BroadcastExceptSelf(this.ClientGroup).OnSendEvent(this._nodeId, content, eventType);
            await Task.CompletedTask;
        }

        protected override async ValueTask OnDisconnected()
        {
            await DisconnectionAsync();
        }
    }
}
