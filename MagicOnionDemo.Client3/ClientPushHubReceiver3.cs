using MagicOnionDemo.Core;
using MagicOnionDemo.ShardLib.Definition;
using MagicOnionDemo.ShardLib.Implements;

namespace MagicOnionDemo.Client3
{
    public class ClientPushHubReceiver3: PushHubReceiver
    {        
        /// <summary>
        /// 监听发送事件
        /// </summary>
        /// <param name="id">节点ID</param>
        /// <param name="content">内容</param>
        /// <param name="eventType">事件类型</param>
        public override void OnSendEvent(string id, string content, EventType eventType)
        {
            Screen.Error("不行混了");
            Screen.Info($"监听节点 : {id} 发送事件 {content}");
        }
    }
}
