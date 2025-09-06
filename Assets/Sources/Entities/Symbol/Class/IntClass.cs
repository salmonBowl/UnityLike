using UnityLike.Entities.Compiler;

namespace UnityLike.Entities.Symbol
{
    public class IntClass : Class
    {
        public override string Name { get; } = "int";
        public override System.Type Type => typeof(IntInstance);
        public static IntClass Single => new();

        public override Instance GetInitalInstance()
        {
            return new IntInstance(0);
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
                    ArgCheck("int");
                    string value = ((StringInstance)args[0]).AsString();
                    if (int.TryParse(value, out int result))
                    {
                        return new FloatInstance(result);
                    }
                    else
                    {
                        throw new ParseFailedException(value, "int", nameToken);
                    }
                default:
                    throw new MemberNotExistException(name, nameToken);
            }
        }
    }
}
