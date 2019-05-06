//using System;
//using System.Threading.Tasks;
//using MagicOnion;
//using MagicOnionDemo.ShardLib.Model;

//namespace MagicOnionDemo.ShardLib.Definition
//{
//    /// <summary>
//    /// 游戏总线
//    /// </summary>
//    public interface IGamingHub : IStreamingHub<IGamingHub, IGamingHubReceiver>
//    {
//        /// <summary>
//        /// 获取聊天室列表
//        /// </summary>
//        /// <returns></returns>
//        Task<RoomInfo[]> GetRoomsAsync();

//        /// <summary>
//        /// 创建并加入聊天室
//        /// </summary>
//        /// <param name="userName">用户名</param>
//        /// <param name="name">聊天室名称</param>
//        /// <param name="isPublic">是否公开聊天室</param>
//        /// <returns></returns>
//        Task CreateRoomAndJoinAsync(string userName, string name, bool isPublic);

//        /// <summary>
//        /// 加入聊天室
//        /// </summary>
//        /// <param name="userName">用户名</param>
//        /// <returns></returns>
//        Task<int> JoinRoomAsync(string userName);

//        /// <summary>
//        /// 加入其它聊天室
//        /// </summary>
//        /// <param name="userName">用户名</param>
//        /// <param name="roomId">房间编号</param>
//        /// <returns></returns>
//        Task<int> JoinOtherRoomAsync(string userName, string roomId);

//        /// <summary>
//        /// 离开聊天室
//        /// </summary>
//        /// <returns></returns>
//        Task LeaveRoomAsync();

//        /// <summary>
//        /// 获取玩家列表
//        /// </summary>
//        /// <returns></returns>
//        Task<PlayerInfo[]> GetPlayersAsync();

//        /// <summary>
//        /// 加入游戏
//        /// </summary>
//        /// <param name="roomName">房间名</param>
//        /// <param name="userName">用户名</param>
//        /// <returns></returns>
//        Task<PlayerInfo[]> JoinAsync(string roomName, string userName);

//        /// <summary>
//        /// 离开游戏
//        /// </summary>
//        /// <returns></returns>
//        Task LeaveAsync();

//        /// <summary>
//        /// 移动
//        /// </summary>
//        /// <param name="position">位置</param>
//        /// <returns></returns>
//        Task MoveAsync(Tuple<int, int> position);
//    }
//}
