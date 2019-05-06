//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using MagicOnion.Server.Hubs;
//using MagicOnionDemo.ShardLib.Definition;
//using MagicOnionDemo.ShardLib.Model;

//namespace MagicOnionDemo.ShardLib.Implements
//{
//    /// <summary>
//    /// 游戏总线
//    /// </summary>
//    public class GamingHub:StreamingHubBase<IGamingHub,IGamingHubReceiver>,IGamingHub
//    {
//        /// <summary>
//        /// 房间
//        /// </summary>
//        private IGroup _room;

//        /// <summary>
//        /// 当前玩家
//        /// </summary>
//        private PlayerInfo _self;

//        /// <summary>
//        /// 玩家内存存储
//        /// </summary>
//        private IInMemoryStorage<PlayerInfo> _storage;

//        /// <summary>
//        /// 聊天室存储
//        /// </summary>
//        private IInMemoryStorage<RoomInfo> _roomStorage;

//        /// <summary>
//        /// 当前聊天室
//        /// </summary>
//        private RoomInfo _selfRoom;

//        /// <summary>
//        /// 获取聊天室列表
//        /// </summary>
//        /// <returns></returns>
//        public Task<RoomInfo[]> GetRoomsAsync()
//        {
//            return Task.FromResult(_roomStorage.AllValues.ToArray());
//        }

//        public async Task CreateRoomAndJoinAsync(string userName, string name, bool isPublic)
//        {
//            if (_self == null)
//            {
//                _self = new PlayerInfo() {Id = Guid.NewGuid().ToString(), Name = userName};
//            }
//            _selfRoom = new RoomInfo()
//            {
//                Id = Guid.NewGuid().ToString(),
//                Name = name,
//                IsPublic = isPublic,
//                OwnerName = userName
//            };
//            _roomStorage.Set(this.Context.ContextId, _selfRoom);
//            (_room, _storage) = await Group.AddAsync(name, _self);
//        }

//        public Task<int> JoinRoomAsync(string userName)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<int> JoinOtherRoomAsync(string userName, string roomId)
//        {
//            throw new NotImplementedException();
//        }

//        public Task LeaveRoomAsync()
//        {
//            throw new NotImplementedException();
//        }

//        public Task<PlayerInfo[]> GetPlayersAsync()
//        {
//            throw new NotImplementedException();
//        }

//        /// <summary>
//        /// 加入游戏
//        /// </summary>
//        /// <param name="roomName">房间名</param>
//        /// <param name="userName">用户名</param>
//        /// <returns></returns>
//        public async Task<PlayerInfo[]> JoinAsync(string roomName, string userName)
//        {
//            _self = new PlayerInfo() {Name = userName};

//            (_room, _storage) = await Group.AddAsync(roomName, _self);

//            Broadcast(_room).OnJoin(_self);

//            return _storage.AllValues.ToArray();
//        }

//        /// <summary>
//        /// 离开游戏
//        /// </summary>
//        /// <returns></returns>
//        public async Task LeaveAsync()
//        {
//            await _room.RemoveAsync(this.Context);
//            Broadcast(_room).OnLeave(_self);
//        }

//        /// <summary>
//        /// 移动
//        /// </summary>
//        /// <param name="position">位置</param>
//        /// <returns></returns>
//        public Task MoveAsync(Tuple<int, int> position)
//        {
//            Broadcast(_room).OnMove(_self);
//            return Task.CompletedTask;
//        }
//    }
//}
