using System;
using MessagePack;

namespace MagicOnionDemo.ShardLib.Model
{
    /// <summary>
    /// 玩家信息
    /// </summary>
    [MessagePackObject]
    public class PlayerInfo
    {
        /// <summary>
        /// 编号
        /// </summary>
        [Key(0)]
        public string Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Key(1)]
        public string Name { get; set; }
    }
}
