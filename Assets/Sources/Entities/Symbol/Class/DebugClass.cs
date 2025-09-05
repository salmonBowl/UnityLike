using System;

using UnityLike.Entities.Compiler;
using UnityLike.FrameworkAndDrivers.LogUI;

namespace UnityLike.Entities.Symbol
{
    public class DebugClass : Class
    {
        public override string Name { get; } = "Vector3";
        public override Type Type => throw new NotImplementedException();
        public static DebugClass Single => new();

        public override Instance GetInitalInstance()
        {
            throw new InvalidProgramException("DebugƒNƒ‰ƒX‚ÌGetInitalInstance‚ªŒÄ‚Î‚ê‚Ü‚µ‚½");
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
                case "Log":
                    ArgCheck("string");
                    string message = ((StringInstance)args[0]).AsString();
                    DebugLog.Instance.AddLog(message);
                    return null;
                default:
                    throw new MemberNotExistException(name, nameToken);
            }
        }
    }
}
