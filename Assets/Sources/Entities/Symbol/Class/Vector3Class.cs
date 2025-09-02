using System;
using UnityLike.Entities.Compiler;

namespace UnityLike.Entities.Symbol
{
    public class Vector3Class : Class
    {
        public override string Name { get; } = "Vector3";
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
                case "Distance":
                    ArgCheck("Vector3", "Vector3");
                    Vector3Instance vec1 = (Vector3Instance)args[0];
                    Vector3Instance vec2 = (Vector3Instance)args[1];
                    float x1 = ((NumberInstance)vec1.GetMember("x")).AsFloat();
                    float y1 = ((NumberInstance)vec1.GetMember("y")).AsFloat();
                    float z1 = ((NumberInstance)vec1.GetMember("z")).AsFloat();
                    float x2 = ((NumberInstance)vec2.GetMember("x")).AsFloat();
                    float y2 = ((NumberInstance)vec2.GetMember("y")).AsFloat();
                    float z2 = ((NumberInstance)vec2.GetMember("z")).AsFloat();

                    float dx = x1 - x2;
                    float dy = y1 - y2;
                    float dz = z1 - z2;
                    float distance = (float)Math.Sqrt(dx*dx + dy*dy + dz*dz);
                    return new FloatInstance(distance);
                default:
                    throw new MemberNotExistException(name, nameToken);
            }
        }
    }
}
