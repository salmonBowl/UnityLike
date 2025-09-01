using System;

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
        /// メンバー変数を保持するテーブルです
        /// </summary>
        protected VariableTable Member { get; } = new(null);

        /// <summary>
        /// メンバー変数へアクセスします
        /// </summary>
        /// <param name="name">メンバー名</param>
        /// <param name="token">メンバー名のトークン</param>
        /// <returns>メンバー変数を返します</returns>
        public Variable GetMember(string name, ColoredToken token)
        {
            return Member.LookUpVariable(name) ?? throw new MemberNotExistException(name, token);
        }

        /// <summary>
        /// メンバー関数を実行します
        /// </summary>
        /// <param name="name">関数名</param>
        /// <param name="args">引数</param>
        /// <returns>関数の返り値</returns>
        public abstract Instance ExecuteMemberFuction(string name, Instance[] args, ColoredToken nameToken, ColoredToken[] argTokens, ColoredToken rightParen = null);

        /// <summary>
        /// Instanceがある型にキャストできるかを判定する補助メソッドです
        /// </summary>
        /// <param name="instance">判定したいしたいインスタンス</param>
        /// <param name="typeName">キャストしたい型の名前</param>
        /// <returns></returns>
        protected bool Castable(Instance instance, string typeName)
        {
            Type expectedType = TypeCastConstants.TypeOf(typeName);
            bool castable = instance.GetType().IsSubclassOf(expectedType);
            return castable;
        }
        /// <summary>
        /// メンバー変数の値を取得する補助メソッドです
        /// </summary>
        /// <param name="name">メンバー名</param>
        /// <param name="token">メンバー名のトークン</param>
        /// <returns>メンバー変数を返します</returns>
        protected Instance GetMember(string name)
        {
            return Member.LookUpVariable(name).Value ??
                throw new NotSupportedException($"メンバー変数'{name}'は存在しません");
        }
    }
}
