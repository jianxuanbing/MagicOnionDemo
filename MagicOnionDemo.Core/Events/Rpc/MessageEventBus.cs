using System.Threading.Tasks;
using Bing.Utils.Json;
using MagicOnionDemo.Core.Events.Messages;

namespace MagicOnionDemo.Core.Events.Rpc
{
    /// <summary>
    /// RPC消息事件总线
    /// </summary>
    public class MessageEventBus:IMessageEventBus
    {
        private readonly IRpcPublisher _publisher = RpcClient.Instance.Create<IRpcPublisher>();

        public Task PublishAsync<TEvent>(TEvent @event) where TEvent : IMessageEvent
        {
            return PublishAsync(@event.Name, @event.Data, @event.Callback);
        }

        public async Task PublishAsync(string name, object data, string callback, bool send = false)
        {
            await _publisher.PublishAsync(name, data.ToJson(), callback);
        }
    }
}
