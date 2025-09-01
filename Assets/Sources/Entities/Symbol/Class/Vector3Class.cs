using UnityLike.Entities.Compiler;

namespace UnityLike.Entities.Symbol
{
    public class Vector3Class : Class
    {
        public static Vector3Class Single => new();

        public override Instance GetInitalInstance()
        {
            return new Vector3Instance(0, 0, 0);
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
                case "one":
                    ArgCheck();
                    return new Vector3Instance(1, 1, 1);
                case "right":
                    ArgCheck();
                    return new Vector3Instance(1, 0, 0);
                case "up":
                    ArgCheck();
                    return new Vector3Instance(0, 1, 0);
                case "forward":
                    ArgCheck();
                    return new Vector3Instance(0, 0, 1);
                case "zero":
                    ArgCheck();
                    return new Vector3Instance(0, 0, 0);
                default:
                    throw new MemberNotExistException(name, nameToken);
            }
        }
    }
}
