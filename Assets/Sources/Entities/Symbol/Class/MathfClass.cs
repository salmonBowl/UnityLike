using System;
using Mathf = UnityEngine.Mathf;

using UnityLike.Entities.Compiler;

namespace UnityLike.Entities.Symbol
{
    public class MathfClass : Class
    {
        public override string Name { get; } = "Mathf";
        public override Type Type => throw new NotImplementedException();
        public static MathfClass Single => new();

        public override Instance GetInitalInstance()
        {
            throw new InvalidProgramException("MathfƒNƒ‰ƒX‚ÌGetInitalInstance‚ªŒÄ‚Î‚ê‚Ü‚µ‚½");
        }

        public override Instance ExecuteStaticFuction(string name, Instance[] args, ColoredToken nameToken, ColoredToken rightParen = null)
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
            bool IsMatchArg(params string[] expected)
            {
                int argCount = expected.Length;
                if (args.Length != argCount)
                {
                    return false;
                }
                for (int i = 0; i < argCount; i++)
                {
                    if (!Castable(args[i], expected[i]))
                    {
                        return false;
                    }
                }
                return true;
            }

            // ˆø”‚ðŠi”[‚·‚é•Ï”‚ðéŒ¾‚µ‚Ä‚¨‚«‚Ü‚·
            float arg0f;
            float arg1f;
            float arg2f;
            float arg3f;
            float arg4f;

            switch (name)
            {
                case "Sin":
                    ArgCheck("float");
                    arg0f = ((NumberInstance)args[0]).AsFloat();
                    return new FloatInstance(Mathf.Sin(arg0f));
                case "Cos":
                    ArgCheck("float");
                    arg0f = ((NumberInstance)args[0]).AsFloat();
                    return new FloatInstance(Mathf.Cos(arg0f));
                case "Tan":
                    ArgCheck("float");
                    arg0f = ((NumberInstance)args[0]).AsFloat();
                    return new FloatInstance(Mathf.Tan(arg0f));
                case "Asin":
                    ArgCheck("float");
                    arg0f = ((NumberInstance)args[0]).AsFloat();
                    return new FloatInstance(Mathf.Asin(arg0f));
                case "Acos":
                    ArgCheck("float");
                    arg0f = ((NumberInstance)args[0]).AsFloat();
                    return new FloatInstance(Mathf.Acos(arg0f));
                case "Atan":
                    ArgCheck("float");
                    arg0f = ((NumberInstance)args[0]).AsFloat();
                    return new FloatInstance(Mathf.Atan(arg0f));
                case "Atan2":
                    ArgCheck("float");
                    arg0f = ((NumberInstance)args[0]).AsFloat();
                    arg1f = ((NumberInstance)args[1]).AsFloat();
                    return new FloatInstance(Mathf.Atan2(arg0f, arg1f));
                case "Abs":
                    ArgCheck("float");
                    arg0f = ((NumberInstance)args[0]).AsFloat();
                    return new FloatInstance(Mathf.Abs(arg0f));
                case "Sqrt":
                    ArgCheck("float");
                    arg0f = ((NumberInstance)args[0]).AsFloat();
                    return new FloatInstance(Mathf.Sqrt(arg0f));
                case "Max":
                    if (IsMatchArg("float", "float"))
                    {
                        arg0f = ((NumberInstance)args[0]).AsFloat();
                        arg1f = ((NumberInstance)args[1]).AsFloat();
                        return new FloatInstance(Mathf.Max(arg0f, arg1f));
                    }
                    if (IsMatchArg("float", "float", "float"))
                    {
                        arg0f = ((NumberInstance)args[0]).AsFloat();
                        arg1f = ((NumberInstance)args[1]).AsFloat();
                        arg2f = ((NumberInstance)args[2]).AsFloat();
                        return new FloatInstance(Mathf.Max(arg0f, arg1f, arg2f));
                    }
                    if (IsMatchArg("float", "float", "float", "float"))
                    {
                        arg0f = ((NumberInstance)args[0]).AsFloat();
                        arg1f = ((NumberInstance)args[1]).AsFloat();
                        arg2f = ((NumberInstance)args[2]).AsFloat();
                        arg3f = ((NumberInstance)args[3]).AsFloat();
                        return new FloatInstance(Mathf.Max(arg0f, arg1f, arg2f, arg3f));
                    }
                    if (IsMatchArg("float", "float", "float", "float", "float"))
                    {
                        arg0f = ((NumberInstance)args[0]).AsFloat();
                        arg1f = ((NumberInstance)args[1]).AsFloat();
                        arg2f = ((NumberInstance)args[2]).AsFloat();
                        arg3f = ((NumberInstance)args[3]).AsFloat();
                        arg4f = ((NumberInstance)args[4]).AsFloat();
                        return new FloatInstance(Mathf.Max(arg0f, arg1f, arg2f, arg3f, arg4f));
                    }
                    throw new InvalidArgumentException(2, rightParen);
                case "Min":
                    if (IsMatchArg("float", "float"))
                    {
                        arg0f = ((NumberInstance)args[0]).AsFloat();
                        arg1f = ((NumberInstance)args[1]).AsFloat();
                        return new FloatInstance(Mathf.Min(arg0f, arg1f));
                    }
                    if (IsMatchArg("float", "float", "float"))
                    {
                        arg0f = ((NumberInstance)args[0]).AsFloat();
                        arg1f = ((NumberInstance)args[1]).AsFloat();
                        arg2f = ((NumberInstance)args[2]).AsFloat();
                        return new FloatInstance(Mathf.Min(arg0f, arg1f, arg2f));
                    }
                    if (IsMatchArg("float", "float", "float", "float"))
                    {
                        arg0f = ((NumberInstance)args[0]).AsFloat();
                        arg1f = ((NumberInstance)args[1]).AsFloat();
                        arg2f = ((NumberInstance)args[2]).AsFloat();
                        arg3f = ((NumberInstance)args[3]).AsFloat();
                        return new FloatInstance(Mathf.Min(arg0f, arg1f, arg2f, arg3f));
                    }
                    if (IsMatchArg("float", "float", "float", "float", "float"))
                    {
                        arg0f = ((NumberInstance)args[0]).AsFloat();
                        arg1f = ((NumberInstance)args[1]).AsFloat();
                        arg2f = ((NumberInstance)args[2]).AsFloat();
                        arg3f = ((NumberInstance)args[3]).AsFloat();
                        arg4f = ((NumberInstance)args[4]).AsFloat();
                        return new FloatInstance(Mathf.Min(arg0f, arg1f, arg2f, arg3f, arg4f));
                    }
                    throw new InvalidArgumentException(2, rightParen);
                case "Clamp":
                    ArgCheck("float", "float", "float");
                    arg0f = ((NumberInstance)args[0]).AsFloat();
                    arg1f = ((NumberInstance)args[1]).AsFloat();
                    arg2f = ((NumberInstance)args[2]).AsFloat();
                    return new FloatInstance(Mathf.Clamp(arg0f, arg1f, arg2f));
                case "Clamp01":
                    ArgCheck("float");
                    arg0f = ((NumberInstance)args[0]).AsFloat();
                    return new FloatInstance(Mathf.Clamp01(arg0f));
                case "DeltaAngle":
                    ArgCheck("float", "float");
                    arg0f = ((NumberInstance)args[0]).AsFloat();
                    arg1f = ((NumberInstance)args[1]).AsFloat();
                    return new FloatInstance(Mathf.DeltaAngle(arg0f, arg1f));
                case "Exp":
                    ArgCheck("float");
                    arg0f = ((NumberInstance)args[0]).AsFloat();
                    return new FloatInstance(Mathf.Exp(arg0f));
                case "Floor":
                    ArgCheck("float");
                    arg0f = ((NumberInstance)args[0]).AsFloat();
                    return new FloatInstance(Mathf.Floor(arg0f));
                case "FloorToInt":
                    ArgCheck("float");
                    arg0f = ((NumberInstance)args[0]).AsFloat();
                    return new IntInstance(Mathf.FloorToInt(arg0f));
                case "Ceil":
                    ArgCheck("float");
                    arg0f = ((NumberInstance)args[0]).AsFloat();
                    return new FloatInstance(Mathf.Ceil(arg0f));
                case "CeilToInt":
                    ArgCheck("float");
                    arg0f = ((NumberInstance)args[0]).AsFloat();
                    return new IntInstance(Mathf.CeilToInt(arg0f));
                case "Rount":
                    ArgCheck("float");
                    arg0f = ((NumberInstance)args[0]).AsFloat();
                    return new FloatInstance(Mathf.Round(arg0f));
                case "RoundToInt":
                    ArgCheck("float");
                    arg0f = ((NumberInstance)args[0]).AsFloat();
                    return new IntInstance(Mathf.RoundToInt(arg0f));
                case "Pow":
                    ArgCheck("float", "float");
                    arg0f = ((NumberInstance)args[0]).AsFloat();
                    arg1f = ((NumberInstance)args[1]).AsFloat();
                    return new FloatInstance(Mathf.Pow(arg0f, arg1f));
                case "Repeat":
                    ArgCheck("float", "float");
                    arg0f = ((NumberInstance)args[0]).AsFloat();
                    arg1f = ((NumberInstance)args[1]).AsFloat();
                    return new FloatInstance(Mathf.Repeat(arg0f, arg1f));
                case "Sign":
                    ArgCheck("float");
                    arg0f = ((NumberInstance)args[0]).AsFloat();
                    return new FloatInstance(Mathf.Sign(arg0f));
                case "Deg2Rad":
                    ArgCheck("float");
                    arg0f = ((NumberInstance)args[0]).AsFloat();
                    return new FloatInstance(Mathf.Deg2Rad * arg0f);
                case "Rad2Deg":
                    ArgCheck("float");
                    arg0f = ((NumberInstance)args[0]).AsFloat();
                    return new FloatInstance(Mathf.Rad2Deg * arg0f);
                default:
                    throw new MemberNotExistException(name, nameToken);
            }
        }
    }
}
