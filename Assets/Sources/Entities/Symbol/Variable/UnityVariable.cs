using System;
using UnityLike.Entities.Compiler;

namespace UnityLike.Entities.Symbol
{
    /// <summary>
    /// Unityのコンポーネントが持つ変数を表します。値を同期します。
    /// </summary>
    public class UnityVariable : Variable
    {
        public override string Name { get; }
        public override Class Type { get; }
        public override Instance Value { get; set; }

        public UnityVariable(string name, Class type)
        {
            Name = name;
            Type = type;
        }
        public override void SetValue(Instance set, ColoredToken equal)
        {
            Type expectedType = Type.GetInitalInstance().GetType();
            bool castable = expectedType.IsAssignableFrom(set.GetType());

            if (!castable)
            {
                throw new AssignmentNotIncompatibleException(Type.Name, set.Type.Name, equal);
            }
            Value = set;

            // 未実装
        }
        public override void UpdateValue()
        {
            // 未実装
        }
    }
}
