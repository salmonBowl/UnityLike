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

            float magnitudeValue = (float)System.Math.Sqrt(x * x + y * y + z * z);
            magnitude.Value = new FloatInstance(magnitudeValue);

            // normalizedはVector3を格納する必要があります
            // そうすると無限ループとなってしまうため一旦見送り
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

        public override Instance Add(Instance other)
        {
            if (!Castable(other, "Vector3"))
            {
                Vector3Instance cOther = (Vector3Instance)other;
                float x1 = ((NumberInstance)GetMember("x")).AsFloat();
                float y1 = ((NumberInstance)GetMember("y")).AsFloat();
                float z1 = ((NumberInstance)GetMember("z")).AsFloat();
                float x2 = ((NumberInstance)cOther.GetMember("x")).AsFloat();
                float y2 = ((NumberInstance)cOther.GetMember("y")).AsFloat();
                float z2 = ((NumberInstance)cOther.GetMember("z")).AsFloat();

                return new Vector3Instance(x1 + x2, y1 + y2, z1 + z2);
            }
            throw new InvalidOperatorException();
        }
        public override Instance Subtract(Instance other)
        {
            if (!Castable(other, "Vector3"))
            {
                Vector3Instance cOther = (Vector3Instance)other;
                float x1 = ((NumberInstance)GetMember("x")).AsFloat();
                float y1 = ((NumberInstance)GetMember("y")).AsFloat();
                float z1 = ((NumberInstance)GetMember("z")).AsFloat();
                float x2 = ((NumberInstance)cOther.GetMember("x")).AsFloat();
                float y2 = ((NumberInstance)cOther.GetMember("y")).AsFloat();
                float z2 = ((NumberInstance)cOther.GetMember("z")).AsFloat();

                return new Vector3Instance(x1 - x2, y1 - y2, z1 - z2);
            }
            throw new InvalidOperatorException();
        }
        public override Instance Multiply(Instance other)
        {
            if (!Castable(other, "float"))
            {
                float x = ((NumberInstance)GetMember("x")).AsFloat();
                float y = ((NumberInstance)GetMember("y")).AsFloat();
                float z = ((NumberInstance)GetMember("z")).AsFloat();
                float scalar = ((NumberInstance)other).AsFloat();

                return new Vector3Instance(x * scalar, y * scalar, z * scalar);
            }
            throw new InvalidOperatorException();
        }
        public override Instance Divide(Instance other)
        {
            if (!Castable(other, "float"))
            {
                float x = ((NumberInstance)GetMember("x")).AsFloat();
                float y = ((NumberInstance)GetMember("y")).AsFloat();
                float z = ((NumberInstance)GetMember("z")).AsFloat();
                float value = ((NumberInstance)other).AsFloat();

                if (value == 0)
                    throw new System.DivideByZeroException();
                return new Vector3Instance(x / value, y / value, z / value);
            }
            throw new InvalidOperatorException();
        }
        public override Instance Modulo(Instance other)
        {
            if (!Castable(other, "float"))
            {
                float x = ((NumberInstance)GetMember("x")).AsFloat();
                float y = ((NumberInstance)GetMember("y")).AsFloat();
                float z = ((NumberInstance)GetMember("z")).AsFloat();
                float value = ((NumberInstance)other).AsFloat();

                if (value == 0)
                    throw new System.DivideByZeroException();
                return new Vector3Instance(x % value, y % value, z % value);
            }
            throw new InvalidOperatorException();
        }
        public override Instance Minus()
        {
            float x = ((NumberInstance)GetMember("x")).AsFloat();
            float y = ((NumberInstance)GetMember("y")).AsFloat();
            float z = ((NumberInstance)GetMember("z")).AsFloat();

            return new Vector3Instance(-x, -y, -z);
        }
        public override Instance Denial()
        {
            throw new InvalidOperatorException();
        }
    }
}
