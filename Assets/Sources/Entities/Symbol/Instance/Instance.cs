
using UnityLike.Entities.Compiler;

namespace UnityLike.Entities.Symbol
{
    public abstract class Instance
    {
        /// <summary>
        /// このインスタンスが属するクラス
        /// </summary>
        public abstract Class Type { get; }

        /// <summary>
        /// メンバー変数へのアクセス
        /// </summary>
        /// <param name="name">メンバー名</param>
        /// <param name="token">メンバー名のトークン</param>
        /// <returns>メンバー変数を返します</returns>
        public abstract Variable GetMember(string name, ColoredToken token);

        /// <summary>
        /// メンバー関数を実行します
        /// </summary>
        /// <param name="name">関数名</param>
        /// <param name="args">引数</param>
        /// <returns>関数の返り値</returns>
        public abstract Instance ExecuteMemberFuction(string name, Instance[] args, ColoredToken nameToken, ColoredToken[] argTokens, ColoredToken rightParen = null);
    }
}
