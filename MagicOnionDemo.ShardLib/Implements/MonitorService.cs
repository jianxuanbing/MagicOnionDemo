using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicOnion;
using MagicOnion.Server;
using MagicOnionDemo.ShardLib.Definition;
using MagicOnionDemo.ShardLib.Model;

namespace MagicOnionDemo.ShardLib.Implements
{
    /// <summary>
    /// 监控服务
    /// </summary>
    public class MonitorService:ServiceBase<IMonitorService>,IMonitorService
    {
        private static ConcurrentDictionary<Guid, ConcurrentQueue<string>> _dictionary = new ConcurrentDictionary<Guid, ConcurrentQueue<string>>();

        public async UnaryResult<string> PublishAsync(PublishModel model)
        {
            if (!_dictionary.ContainsKey(model.ClientId))
            {
                _dictionary[model.ClientId] = new ConcurrentQueue<string>();
            }
            _dictionary[model.ClientId].Enqueue(model.OperationName);
            return "Success";
        }

        public async Task<ServerStreamingResult<string>> SubscribeAsync(Guid clientId)
        {
            var stream = GetServerStreamingContext<string>();
            if (_dictionary.ContainsKey(clientId))
            {
                if (_dictionary[clientId].TryDequeue(out var result))
                {
                    await stream.WriteAsync(result);
                }                
            }

            return stream.Result();
        }
    }
}
