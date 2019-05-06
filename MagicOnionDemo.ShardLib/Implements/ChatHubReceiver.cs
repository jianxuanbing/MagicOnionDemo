using System;
using Grpc.Core;
using MagicOnion.Client;
using MagicOnionDemo.ShardLib.Definition;

namespace MagicOnionDemo.ShardLib.Implements
{
    /// <summary>
    /// 聊天室总线接收器
    /// </summary>
    public class ChatHubReceiver:IChatHubReceiver
    {
        /// <summary>
        /// 总线
        /// </summary>
        private IChatHub _hub;

        /// <summary>
        /// 是否已加入
        /// </summary>
        private bool _isJoin;

        public void Start()
        {
            this._isJoin = false;
            var channel = new Channel("localhost:8700", ChannelCredentials.Insecure);
            this._hub = StreamingHubClient.Connect<IChatHub, IChatHubReceiver>(channel, this);            
        }

        public async void JoinOrLeave()
        {
            if (this._isJoin)
            {
                await this._hub.LeaveAsync();
                this._isJoin = false;                
            }
            else
            {
                await this._hub.JoinAsync($"随机用户 {DateTime.Now.Ticks}");
                this._isJoin = true;
            }
        }

        public async void SendMessage()
        {
            if (!this._isJoin)
            {
                return;
            }

            await this._hub.SendMessageAsync($"随机消息 {DateTime.Now.Ticks}");
        }

        public void OnJoin(string name)
        {
            Console.WriteLine($"{DateTime.Now} -【{name}】加入聊天室");
        }

        public void OnLeave(string name)
        {
            Console.WriteLine($"{DateTime.Now} -【{name}】离开了聊天室");
        }

        public void OnSendMessage(string name, string message)
        {
            Console.WriteLine($"{DateTime.Now} - 【{name}】发送【{message}】");
        }
    }
}
