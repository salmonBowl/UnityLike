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

        public override Instance ExecuteMemberFuction(string name, Instance[] args, ColoredToken nameToken, ColoredToken rightParen)
        {
            void ArgCheck(params string[] expected)
            {
                int argCount = expected.Length;
                if (args.Length != argCount)
                {
                    throw new InvalidArgumentException(expected.Length, rightParen);
                }
                for (int i = 0; i < argCount; i++)
                {
                    if (!Castable(args[i], expected[i]))
                    {
                        throw new ArgumentInvalidTypeException(expected[i], nameToken);
                    }
                }
            }

            // ŠÖ”ŽÀs‚Ì‚½‚ß‚É’l‚ðŽæ“¾‚µ‚Ä‚¨‚«‚Ü‚·
            bool value = (bool)Value;

            switch (name)
            {
                case "ToString":
                    ArgCheck();
                    string message = value.ToString();
                    return new StringInstance(message);
                default:
                    throw new MemberNotExistException(name, nameToken);
            }
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
        public override Instance Comparison(Instance other, string @operator)
        {
            if (other is not BoolInstance otherBool)
            {
                throw new InvalidOperatorException();
            }

            bool result = @operator switch
            {
                "==" => AsBool() == otherBool.AsBool(),
                "!=" => AsBool() == otherBool.AsBool(),
                _ => throw new InvalidOperatorException()
            };
            return new BoolInstance(result);
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
