using MessagePack;

namespace MagicOnionDemo.ShardLib.Model
{
    /// <summary>
    /// 聊天室信息
    /// </summary>
    [MessagePackObject]
    public class RoomInfo
    {
        /// <summary>
        /// 系统编号
        /// </summary>
        [Key(0)]
        public string Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Key(1)]
        public string Name { get; set; }

        /// <summary>
        /// 拥有者名称
        /// </summary>
        [Key(2)]
        public string OwnerName { get; set; }

        /// <summary>
        /// 是否公开聊天室
        /// </summary>
        [Key(3)]
        public bool IsPublic { get; set; }
    }
}
