namespace UnityLike
{
    public class RotZ : Value
    {
        public RotZ(float value) : base(value) { }
        public RotZ Add(RotZ other)
        {
            var result = value + other.value;
            return new RotZ(result);
        }
        public RotZ Subtract(RotZ other)
        {
            var result = value + other.value;
            return new RotZ(result);
        }
        public RotZ Multiply(AngleScalar magnification)
        {
            var result = value * magnification.Get();
            return new RotZ(result);
        }
    }
}
