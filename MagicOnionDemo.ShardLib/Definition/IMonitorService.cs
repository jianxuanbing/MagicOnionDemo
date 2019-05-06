using System;
using System.Threading.Tasks;
using MagicOnion;
using MagicOnionDemo.ShardLib.Model;

namespace MagicOnionDemo.ShardLib.Definition
{
    /// <summary>
    /// 监控服务
    /// </summary>
    public interface IMonitorService:IService<IMonitorService>
    {
        /// <summary>
        /// 发布
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        UnaryResult<string> PublishAsync(PublishModel model);

        /// <summary>
        /// 订阅
        /// </summary>
        /// <param name="clientId">客户端编号</param>
        /// <returns></returns>
        Task<ServerStreamingResult<string>> SubscribeAsync(Guid clientId);
    }
}
