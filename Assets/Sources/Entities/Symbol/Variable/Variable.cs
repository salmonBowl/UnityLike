using System;
using UnityLike.Entities.Compiler;

namespace UnityLike.Entities.Symbol
{
    /// <summary>
    /// 変数を表す基底クラスです
    /// </summary>
    public abstract class Variable
    {
        public abstract string Name { get; }
        public abstract Class Type { get; }
        public abstract Instance Value { get; set; }

        public abstract void SetValue(Instance set, ColoredToken equal);

        // UnityVariableがUnityと同期させる際に使います
        public abstract void UpdateValue();
    }
}
