
using UnityLike.Entities.Compiler;

namespace UnityLike.Entities.Symbol
{
    public class IntInstance : NumberInstance
    {
        public override Class Type => IntClass.Instance;
        
        public int Value { get; set; }

        public IntInstance(int value)
        {
            Value = value;
        }

        public override float AsFloat()
        {
            return Value;
        }
    }
}
