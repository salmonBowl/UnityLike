using KeyCode = UnityEngine.KeyCode;

using UnityLike.Entities.Compiler;

namespace UnityLike.Entities.Symbol
{
    public class KeyCodeInstance : PrimitiveInstance
    {
        public override Class Type => KeyCodeClass.Single;

        public KeyCodeInstance(KeyCode value)
        {
            Value = value;
        }

        public KeyCode AsKeyCode()
        {
            return (KeyCode)Value;
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
            throw new InvalidOperatorException();
        }
    }
}
