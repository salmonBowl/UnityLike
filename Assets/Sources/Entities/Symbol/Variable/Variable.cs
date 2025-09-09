using System;

using UnityLike.Entities.Compiler;

namespace UnityLike.Entities.Symbol
{
    /// <summary>
    /// 変数を表します。インスタンスを情報として格納します。
    /// </summary>
    public class Variable
    {
        public string Name { get; }
        public Class Type { get; }
        public Instance Value { get; set; }

        public Variable(string name, Class type)
        {
            Name = name;
            Type = type;
        }

        public void AssignmentValue(Instance set, ColoredToken equal)
        {
            if (!TypeCastConstants.TypeContains(Type.Name))
            {
                throw new NotAssignableTypeException(Type.Name, equal);
            }

            Type expectedType = TypeCastConstants.TypeOf(Type.Name);
            bool castable = expectedType.IsAssignableFrom(set.GetType());

            if (!castable)
            {
                throw new AssignmentNotIncompatibleException(Type.Name, set.Type.Name, equal);
            }
            Value = set;
        }
    }
}
