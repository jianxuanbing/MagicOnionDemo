using System;
using MessagePack;

namespace MagicOnionDemo.ShardLib.Model
{
    /// <summary>
    /// 发布实体
    /// </summary>
    [MessagePackObject()]
    public class PublishModel
    {
        /// <summary>
        /// 客户端编号
        /// </summary>
        [Key(0)]
        public Guid ClientId { get; set; }

        /// <summary>
        /// 操作名称
        /// </summary>
        [Key(1)]
        public string OperationName { get; set; }
    }
}
