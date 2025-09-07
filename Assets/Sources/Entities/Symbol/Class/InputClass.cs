using System;
using UnityEngine;

using UnityLike.Entities.Compiler;

namespace UnityLike.Entities.Symbol
{
    public class InputClass : Class
    {
        public override string Name { get; } = "Input";
        public override Type Type => throw new NotImplementedException();
        public static InputClass Single => new();

        public override Instance GetInitalInstance()
        {
            throw new InvalidProgramException("InputƒNƒ‰ƒX‚ÌGetInitalInstance‚ªŒÄ‚Î‚ê‚Ü‚µ‚½");
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

            // ˆø”‚ðŠi”[‚·‚é•Ï”‚ðéŒ¾‚µ‚Ä‚¨‚«‚Ü‚·
            KeyCode arg0k;

            switch (name)
            {
                case "GetKey":
                    ArgCheck("KeyCode");
                    arg0k = ((KeyCodeInstance)args[0]).AsKeyCode();
                    return new BoolInstance(Input.GetKey(arg0k));
                case "GetKeyDown":
                    ArgCheck("KeyCode");
                    arg0k = ((KeyCodeInstance)args[0]).AsKeyCode();
                    return new BoolInstance(Input.GetKeyDown(arg0k));
                case "GetKeyUp":
                    ArgCheck("KeyCode");
                    arg0k = ((KeyCodeInstance)args[0]).AsKeyCode();
                    return new BoolInstance(Input.GetKeyUp(arg0k));
                case "GetMouseButtonDown":
                    ArgCheck("int");
                    int arg0i = ((IntInstance)args[0]).AsInt();
                    return new BoolInstance(Input.GetMouseButtonDown(arg0i));
                default:
                    throw new MemberNotExistException(name, nameToken);
            }
        }
    }
}
