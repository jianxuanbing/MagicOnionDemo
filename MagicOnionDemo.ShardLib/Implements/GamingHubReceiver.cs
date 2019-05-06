//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using Grpc.Core;
//using MagicOnion.Client;
//using MagicOnionDemo.ShardLib.Definition;
//using MagicOnionDemo.ShardLib.Model;

//namespace MagicOnionDemo.ShardLib.Implements
//{
//    /// <summary>
//    /// 游戏总线接收器
//    /// </summary>
//    public class GamingHubReceiver:IGamingHubReceiver
//    {
//        /// <summary>
//        /// 玩家字典
//        /// </summary>
//        private Dictionary<string, PlayerInfo> _players = new Dictionary<string, PlayerInfo>();

//        /// <summary>
//        /// 客户端
//        /// </summary>
//        private IGamingHub _client;

//        /// <summary>
//        /// 连接
//        /// </summary>
//        /// <param name="channel">通道</param>
//        /// <param name="roomName">房间名</param>
//        /// <param name="playerName">玩家名</param>
//        /// <returns></returns>
//        public async Task<PlayerInfo> ConnectAsync(Channel channel, string roomName, string playerName)
//        {
//            var client = StreamingHubClient.Connect<IGamingHub, IGamingHubReceiver>(channel, this);
//            _client = client;
//            //var roomPlayers = await client.JoinAsync(roomName, playerName, 10, new Tuple<int, int>(0, 0));
//            //foreach (var player in roomPlayers)
//            //{
//            //    (this as IGamingHubReceiver).OnJoin(player);
//            //}

//            return _players[playerName];
//        }

//        /// <summary>
//        /// 离开
//        /// </summary>
//        /// <returns></returns>
//        public Task LeaveAsync()
//        {
//            return _client.LeaveAsync();
//        }

//        /// <summary>
//        /// 移动
//        /// </summary>
//        /// <param name="position">位置</param>
//        /// <returns></returns>
//        public Task MoveAsync(Tuple<int, int> position)
//        {
//            return _client.MoveAsync(position);
//        }

//        /// <summary>
//        /// 释放资源
//        /// </summary>
//        /// <returns></returns>
//        public Task DisposeAsync()
//        {
//            return _client.DisposeAsync();
//        }

//        /// <summary>
//        /// 等待断开连接
//        /// </summary>
//        /// <returns></returns>
//        public Task WaitForDisconnect()
//        {
//            return _client.WaitForDisconnect();
//        }

//        /// <summary>
//        /// 连接
//        /// </summary>
//        /// <param name="channel">通道</param>
//        /// <returns></returns>
//        public async Task<IGamingHub> ConnectAsync(Channel channel)
//        {
//            return StreamingHubClient.Connect<IGamingHub, IGamingHubReceiver>(channel, this);
//        }

//        /// <summary>
//        /// 加入游戏
//        /// </summary>
//        /// <param name="player">玩家</param>
//        public void OnJoin(PlayerInfo player)
//        {
//            Console.WriteLine($"Join Player: {player.Name}");
//            _players[player.Name] = player;
//        }

//        public void OnLeave(PlayerInfo player)
//        {
//            Console.WriteLine($"Leave Player: {player.Name}");
//            if (_players.TryGetValue(player.Name, out var _))
//            {
//            }
//        }

//        /// <summary>
//        /// 移动
//        /// </summary>
//        /// <param name="player">玩家</param>
//        /// <returns></returns>
//        public void OnMove(PlayerInfo player)
//        {
//            Console.WriteLine($"Leave Player: {player.Name}");
//            if (_players.TryGetValue(player.Name, out var _))
//            {
//            }
//        }
//    }
//}
