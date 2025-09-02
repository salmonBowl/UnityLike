using System;
using UnityLike.Entities.Compiler;

namespace UnityLike.Entities.Symbol
{
    /// <summary>
    /// 変数を表します。インスタンスを情報として格納します。
    /// </summary>
    public class StandardVariable : Variable
    {
        public override string Name { get; }
        public override Class Type { get; }
        public override Instance Value { get; set; }

        public StandardVariable(string name, Class type)
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
        }

        // UnityVariableがUnityと同期させる際に使います
        public override void UpdateValue() { }
    }
}
