using System;
using UnityLike.Entities.Compiler;

namespace UnityLike.Entities.Symbol
{
    public class Vector3Instance : Instance
    {
        public override Class Type => Vector3Class.Single;

        public Vector3Instance(float x, float y, float z)
        {
            Class Float = FloatClass.Single;

            Variable X = new("x", Float);
            Variable Y = new("y", Float);
            Variable Z = new("z", Float);

            Variable magnitude = new("magnitude", Float);
            Variable normalized = new("normalized", Vector3Class.Single);


            Member.AddMember(X, Y, Z, magnitude, normalized);

            X.Value = new FloatInstance(x);
            Y.Value = new FloatInstance(y);
            Z.Value = new FloatInstance(z);

            float magnitudeValue = (float)Math.Sqrt(x * x + y * y + z * z);
            magnitude.Value = new FloatInstance(magnitudeValue);

            // normalizedはVector3を格納する必要があります
            // そうすると無限ループとなってしまうため一旦見送り
        }

        public override Instance ExecuteMemberFuction(string name, Instance[] args, ColoredToken nameToken, ColoredToken[] argTokens, ColoredToken rightParen)
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

            // 関数実行のためにメンバー変数を取得しておきます
            float x = ((NumberInstance)GetMember("x")).AsFloat();
            float y = ((NumberInstance)GetMember("y")).AsFloat();
            float z = ((NumberInstance)GetMember("z")).AsFloat();

            switch (name)
            {
                case "ToString":
                    ArgCheck();
                    string message = $"Vector3({x}, {y}, {z})";
                    return new StringInstance(message);
                default:
                    throw new MemberNotExistException(name, nameToken);
            }
        }
    }
}
