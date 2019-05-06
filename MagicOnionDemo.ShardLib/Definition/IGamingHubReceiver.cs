//using System.Threading.Tasks;
//using Grpc.Core;
//using MagicOnionDemo.ShardLib.Model;

//namespace MagicOnionDemo.ShardLib.Definition
//{
//    /// <summary>
//    /// 游戏总线接收器
//    /// </summary>
//    public interface IGamingHubReceiver
//    {
//        /// <summary>
//        /// 连接
//        /// </summary>
//        /// <param name="channel"></param>
//        /// <returns></returns>
//        Task<IGamingHub> ConnectAsync(Channel channel);

//        /// <summary>
//        /// 加入游戏
//        /// </summary>
//        /// <param name="player">玩家</param>
//        void OnJoin(PlayerInfo player);

//        /// <summary>
//        /// 离开游戏
//        /// </summary>
//        /// <param name="player">玩家</param>
//        void OnLeave(PlayerInfo player);

//        /// <summary>
//        /// 移动
//        /// </summary>
//        /// <param name="player">玩家</param>
//        void OnMove(PlayerInfo player);
//    }
//}
