
using UnityLike.Entities.Compiler;

namespace UnityLike.Entities.Symbol
{
    public abstract class Class
    {
        public abstract string Name { get; }

        /// <summary>
        /// 新しいインスタンスを初期値で生成します
        /// </summary>
        /// <param name="args">インスタンス生成時の引数</param>
        /// <returns>生成したインスタンスを返します</returns>
        public abstract Instance NewInstance(Instance[] args, ColoredToken[] argTokens, ColoredToken rightParen = null);
        public abstract void TryMemberExists(string member, ColoredToken token);
    }
}
