using UnityLike.Entities.Compiler;

namespace UnityLike.Entities.Symbol
{
    public class FloatClass : Class
    {
        public static FloatClass Single => new();

        public override Instance GetInitalInstance()
        {
            return new IntInstance(0);
        }

        public override void TryMemberExists(string member, ColoredToken token)
        {
            throw new MemberNotExistException(member, token);
        }

        public override Instance ExecuteStaticFuction(string name, Instance[] args, ColoredToken nameToken, ColoredToken[] argTokens, ColoredToken rightParen = null)
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
                        throw new ArgumentInvalidTypeException(expected[i], argTokens[i]);
                    }
                }
            }

            switch (name)
            {
                case "Parse":
                    ArgCheck("string");
                    string value = ((StringInstance)args[0]).AsString();
                    if (float.TryParse(value, out float result))
                    {
                        return new FloatInstance(result);
                    }
                    else
                    {
                        throw new ParseFailedException(value, "float", nameToken);
                    }
                default:
                    throw new MemberNotExistException(name, nameToken);
            }
        }
    }
}
