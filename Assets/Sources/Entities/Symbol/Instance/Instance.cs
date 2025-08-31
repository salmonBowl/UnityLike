
using UnityLike.Entities.Compiler;

namespace UnityLike.Entities.Symbol
{
    public abstract class Instance
    {
        /// <summary>
        /// このインスタンスが属するクラス
        /// </summary>
        public abstract Class Type { get; }

        // メンバーへのアクセス
        public abstract Instance GetMember(string name, ColoredToken token);
        public abstract void SetMember(string name, Instance value, ColoredToken token);
    }
}
