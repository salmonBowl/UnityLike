using UnityLike.Entities.Compiler;

namespace UnityLike.Entities.Symbol
{
    public class IntInstance : NumberInstance
    {
        public override Class Type => IntClass.Single;

        public IntInstance(int value)
        {
            Value = value;
        }

        public override float AsFloat()
        {
            return (int)Value;
        }
        public int AsInt()
        {
            return (int)Value;
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
            int value = (int)Value;

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
            if (Castable(other, "int"))
            {
                int value1 = AsInt();
                int value2 = ((IntInstance)other).AsInt();

                return new IntInstance(value1 + value2);
            }
            else if (Castable(other, "float"))
            {
                float value1 = AsFloat();
                float value2 = ((NumberInstance)other).AsFloat();

                return new FloatInstance(value1 + value2);
            }
            throw new InvalidOperatorException();
        }
        public override Instance Subtract(Instance other)
        {
            if (Castable(other, "int"))
            {
                int value1 = AsInt();
                int value2 = ((IntInstance)other).AsInt();

                return new IntInstance(value1 - value2);
            }
            else if (Castable(other, "float"))
            {
                float value1 = AsFloat();
                float value2 = ((NumberInstance)other).AsFloat();

                return new FloatInstance(value1 - value2);
            }
            throw new InvalidOperatorException();
        }
        public override Instance Multiply(Instance other)
        {
            if (Castable(other, "int"))
            {
                int value1 = AsInt();
                int value2 = ((IntInstance)other).AsInt();

                return new IntInstance(value1 * value2);
            }
            else if (Castable(other, "float"))
            {
                float value1 = AsFloat();
                float value2 = ((NumberInstance)other).AsFloat();

                return new FloatInstance(value1 * value2);
            }
            else if (Castable(other, "Vector3"))
            {
                float scalar = AsFloat();
                float x = ((NumberInstance)other.GetMember("x")).AsFloat();
                float y = ((NumberInstance)other.GetMember("y")).AsFloat();
                float z = ((NumberInstance)other.GetMember("z")).AsFloat();

                return new Vector3Instance(scalar * x, scalar * y, scalar * z);
            }
            throw new InvalidOperatorException();
        }
        public override Instance Divide(Instance other)
        {
            if (Castable(other, "int"))
            {
                int value1 = AsInt();
                int value2 = ((IntInstance)other).AsInt();

                if (value2 == 0)
                    throw new System.DivideByZeroException();
                return new IntInstance(value1 / value2);
            }
            else if (Castable(other, "float"))
            {
                float value1 = AsFloat();
                float value2 = ((NumberInstance)other).AsFloat();

                if (value2 == 0)
                    throw new System.DivideByZeroException();
                return new FloatInstance(value1 / value2);
            }
            throw new InvalidOperatorException();
        }
        public override Instance Modulo(Instance other)
        {
            if (Castable(other, "int"))
            {
                int value1 = AsInt();
                int value2 = ((IntInstance)other).AsInt();

                if (value2 == 0)
                    throw new System.DivideByZeroException();
                return new IntInstance(value1 % value2);
            }
            else if (Castable(other, "float"))
            {
                float value1 = AsFloat();
                float value2 = ((NumberInstance)other).AsFloat();

                if (value2 == 0)
                    throw new System.DivideByZeroException();
                return new FloatInstance(value1 % value2);
            }
            throw new InvalidOperatorException();
        }
        public override Instance Minus()
        {
            return new IntInstance(-AsInt());
        }
        public override Instance Denial()
        {
            throw new InvalidOperatorException();
        }
    }
}
