
using UnityLike.Entities.Compiler;

namespace UnityLike.Entities.Symbol
{
    public abstract class Class
    {
        public abstract string Name { get; }

        /// <summary>
        /// インスタンスの初期値を定義します。変数宣言の際などに使用してください。
        /// </summary>
        /// <returns>生成したインスタンスを返します</returns>
        public abstract Instance GetInitalInstance();
        public abstract void TryMemberExists(string member, ColoredToken token);
    }
}
