namespace UnityLike
{
    public class DeltaAngle : Angle
    {
        public DeltaAngle(float angle, AngleUnit angleUnit) : base(angle, angleUnit) { }
        public DeltaAngle(float angle) : base(angle) { }

        new public DeltaAngle Add(DeltaAngle other)
        {
            float result = value + other.value;
            return new DeltaAngle(result);
        }
        public DeltaAngle Subtract(DeltaAngle other)
        {
            float result = value - other.value;
            return new DeltaAngle(result);
        }
    }
}
