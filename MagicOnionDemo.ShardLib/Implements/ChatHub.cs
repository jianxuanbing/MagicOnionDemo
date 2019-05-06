using System;
using System.Threading.Tasks;
using MagicOnion.Server.Hubs;
using MagicOnionDemo.ShardLib.Definition;

namespace MagicOnionDemo.ShardLib.Implements
{
    public class ChatHub:StreamingHubBase<IChatHub,IChatHubReceiver>,IChatHub
    {
        private IGroup _room;
        private string _me;

        private const string roomName = "Chat Room";

        public async Task JoinAsync(string userName)
        {
            this._room = await this.Group.AddAsync(roomName);
            _me = userName;
            this.Broadcast(_room).OnJoin(userName);
            Console.WriteLine($"【{userName}】 加入房间了");
        }

        public async Task LeaveAsync()
        {

            await this._room.RemoveAsync(this.Context);
            this.Broadcast(_room).OnLeave(_me);
            Console.WriteLine($"{_me} 离开了房间");
        }

        public async Task SendMessageAsync(string message)
        {
            this.Broadcast(_room).OnSendMessage(_me, message);
            Console.WriteLine($"{_me} SendMessage : {message}");
        }

        protected override ValueTask OnDisconnected()
        {
            return CompletedTask;
        }
    }
}
