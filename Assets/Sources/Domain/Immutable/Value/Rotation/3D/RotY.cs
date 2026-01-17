namespace UnityLike
{
    public class RotY : Value
    {
        public RotY(float value) : base(value) { }
        public RotY Add(RotY other)
        {
            var result = value + other.value;
            return new RotY(result);
        }
        public RotY Subtract(RotY other)
        {
            var result = value + other.value;
            return new RotY(result);
        }
        public RotY Multiply(AngleScalar magnification)
        {
            var result = value * magnification.Get();
            return new RotY(result);
        }
    }
}
