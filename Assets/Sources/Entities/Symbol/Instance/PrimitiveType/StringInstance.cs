using UnityLike.Entities.Compiler;

namespace UnityLike.Entities.Symbol
{
    public class StringInstance : PrimitiveInstance
    {
        public override Class Type => IntClass.Single;

        public StringInstance(string value)
        {
            Value = value;

            // ÉÅÉìÉoÅ[ïœêîlengthÇíËã`ÇµÇ‹Ç∑
            StandardVariable Length = new("length", Type);
            Member.AddMember(Length);

            Length.Value = new IntInstance(value.Length);
        }

        public string AsString()
        {
            return (string)Value;
        }

        public override Instance ExecuteMemberFuction(string name, Instance[] args, ColoredToken nameToken, ColoredToken rightParen = null)
        {
            throw new MemberNotExistException(name, nameToken);
        }

        public override Instance Add(Instance other)
        {
            if (!Castable(other, "string"))
            {
                string value1 = AsString();
                string value2 = ((StringInstance)other).AsString();

                return new StringInstance(value1 + value2);
            }
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
