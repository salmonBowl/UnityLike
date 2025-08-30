
namespace UnityLike.Entities.Symbol
{
    public abstract class Class
    {
        public string Name { get; }

        /// <summary>
        /// 新しいインスタンスを生成します
        /// </summary>
        /// <param name="args">インスタンス生成時の引数</param>
        /// <returns>生成したインスタンスを返します</returns>
        public abstract Instance NewInstance(params Instance[] args);
    }
}
