using UnityLike.Entities.Compiler;

namespace UnityLike.Entities.Symbol
{
    public class FloatInstance : NumberInstance
    {
        public override Class Type => FloatClass.Single;

        public FloatInstance(float value)
        {
            Value = value;
        }

        public override float AsFloat()
        {
            return (float)Value;
        }

        public override Instance Add(Instance other)
        {
            if (!Castable(other, "float"))
            {
                float value1 = AsFloat();
                float value2 = ((NumberInstance)other).AsFloat();

                return new FloatInstance(value1 + value2);
            }
            throw new InvalidOperatorException();
        }
        public override Instance Subtract(Instance other)
        {
            if (!Castable(other, "float"))
            {
                float value1 = AsFloat();
                float value2 = ((NumberInstance)other).AsFloat();

                return new FloatInstance(value1 - value2);
            }
            throw new InvalidOperatorException();
        }
        public override Instance Multiply(Instance other)
        {
            if (!Castable(other, "float"))
            {
                float value1 = AsFloat();
                float value2 = ((NumberInstance)other).AsFloat();

                return new FloatInstance(value1 * value2);
            }
            else if (!Castable(other, "Vector3"))
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
            if (!Castable(other, "float"))
            {
                float value1 = (float)Value;
                float value2 = ((NumberInstance)other).AsFloat();

                if (value2 == 0)
                    throw new System.DivideByZeroException();
                return new FloatInstance(value1 / value2);
            }
            throw new InvalidOperatorException();
        }
        public override Instance Modulo(Instance other)
        {
            if (!Castable(other, "float"))
            {
                float value1 = (float)Value;
                float value2 = ((NumberInstance)other).AsFloat();

                if (value2 == 0)
                    throw new System.DivideByZeroException();
                return new FloatInstance(value1 % value2);
            }
            throw new InvalidOperatorException();
        }
        public override Instance Minus()
        {
            return new FloatInstance(-AsFloat());
        }
        public override Instance Denial()
        {
            throw new InvalidOperatorException();
        }
    }
}
