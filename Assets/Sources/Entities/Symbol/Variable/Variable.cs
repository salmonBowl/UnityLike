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
            Type expectedType = Type.GetInitalInstance().GetType();
            bool castable = expectedType.IsAssignableFrom(set.GetType());

            if (!castable)
            {
                throw new AssignmentNotIncompatibleException(Type.Name, set.Type.Name, equal);
            }

            if (Value.GetType() == typeof(Vector3Instance))
                UnityEngine.Debug.Log("value : " + ((Vector3Instance)Value).AsVector3());
            if (set.GetType() == typeof(Vector3Instance))
                UnityEngine.Debug.Log("set : " + ((Vector3Instance)set).AsVector3());
            Value = set;
        }
    }
}
