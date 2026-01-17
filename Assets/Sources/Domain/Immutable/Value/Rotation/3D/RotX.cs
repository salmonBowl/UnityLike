namespace UnityLike
{
    public class RotX : Value
    {
        public RotX(float value) : base(value) { }

        public RotX Add(RotX other)
        {
            var result = value + other.value;
            return new RotX(result);
        }
        public RotX Subtract(RotX other)
        {
            var result = value + other.value;
            return new RotX(result);
        }
        public RotX Multiply(AngleScalar magnification)
        {
            var result = value * magnification.Get();
            return new RotX(result);
        }
    }
}