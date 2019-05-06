//using System;
//using System.Threading.Tasks;
//using Grpc.Core;
//using MagicOnionDemo.Core;
//using MagicOnionDemo.ShardLib.Definition;
//using MagicOnionDemo.ShardLib.Implements;

//namespace MagicOnionDemo.ShardLib
//{
//    /// <summary>
//    /// 游戏客户端
//    /// </summary>
//    public class GameClient
//    {
//        /// <summary>
//        /// 接收器
//        /// </summary>
//        private IGamingHubReceiver _receiver;

//        /// <summary>
//        /// 总线
//        /// </summary>
//        private IGamingHub _hub;

//        /// <summary>
//        /// 管道
//        /// </summary>
//        private Channel _channel;

//        /// <summary>
//        /// 自己ID
//        /// </summary>
//        private int _selfId;

//        public GameClient()
//        {
//            _receiver = new GamingHubReceiver();
//        }

//        public async Task JoinRoom(string userName)
//        {
//            try
//            {
//                _channel = RpcClient.Instance.Channel;
//                _hub = await _receiver.ConnectAsync(_channel);

//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e);
//                throw;
//            }
//        }
//    }
//}
