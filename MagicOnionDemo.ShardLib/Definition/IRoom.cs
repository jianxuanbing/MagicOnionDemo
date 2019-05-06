namespace MagicOnionDemo.ShardLib.Definition
{
    /// <summary>
    /// 房间
    /// </summary>
    public interface IRoom
    {
        /// <summary>
        /// 监听加入房间
        /// </summary>
        /// <param name="name">名称</param>
        void OnJoin(string name);

        /// <summary>
        /// 监听离开房间
        /// </summary>
        /// <param name="name">名称</param>
        void OnLeave(string name);
    }
}
