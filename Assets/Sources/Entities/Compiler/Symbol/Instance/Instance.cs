
namespace UnityLike.Entities.Symbol
{
    public abstract class Instance
    {
        /// <summary>
        /// このインスタンスが属するクラス
        /// </summary>
        public Class Class { get; }

        // メンバーへのアクセス
        public abstract Instance GetMember(string name);
        public abstract void SetMember(string name, Instance value);
    }
}
