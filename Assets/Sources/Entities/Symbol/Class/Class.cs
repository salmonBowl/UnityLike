using System;

using UnityLike.Entities.Compiler;

namespace UnityLike.Entities.Symbol
{
    public abstract class Class
    {
        public abstract string Name { get; }
        public abstract Type Type { get; }

        /// <summary>
        /// インスタンスの初期値を定義します。変数宣言の際などに使用してください。
        /// </summary>
        /// <returns>生成したインスタンスを返します</returns>
        public abstract Instance GetInitalInstance();

        /// <summary>
        /// 静的メソッドを実行します
        /// </summary>
        /// <param name="name">関数名</param>
        /// <param name="args">引数</param>
        /// <returns>Instance型の返り値</returns>
        public abstract Instance ExecuteStaticFuction(string name, Instance[] args, ColoredToken nameToken, ColoredToken rightParen = null);
        
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
    }
}
