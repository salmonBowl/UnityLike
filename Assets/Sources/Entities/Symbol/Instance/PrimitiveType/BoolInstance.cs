using UnityLike.Entities.Compiler;

namespace UnityLike.Entities.Symbol
{
    public class BoolInstance : PrimitiveInstance
    {
        public override Class Type => BoolClass.Single;

        public BoolInstance(bool value)
        {
            Value = value;
        }

        public bool AsBool()
        {
            return (bool)Value;
        }

        public override Instance ExecuteMemberFuction(string name, Instance[] args, ColoredToken nameToken, ColoredToken rightParen = null)
        {
            throw new MemberNotExistException(name, nameToken);
        }

        public override Instance Add(Instance other)
        {
            throw new InvalidOperatorException();
        }
        public override Instance Subtract(Instance other)
        {
            throw new InvalidOperatorException();
        }
        public override Instance Multiply(Instance other)
        {
            throw new InvalidOperatorException();
        }
        public override Instance Divide(Instance other)
        {
            throw new InvalidOperatorException();
        }
        public override Instance Modulo(Instance other)
        {
            throw new InvalidOperatorException();
        }
        public override Instance Minus()
        {
            throw new InvalidOperatorException();
        }
        public override Instance Denial()
        {
            bool retval = !AsBool();
            return new BoolInstance(retval);
        }
    }
}
