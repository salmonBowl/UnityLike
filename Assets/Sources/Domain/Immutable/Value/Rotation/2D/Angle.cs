namespace UnityLike
{
    public class Angle : Value
    {
        private readonly AngleUnit angleUnit;

        public Angle(float value, AngleUnit angleUnit) : base(value)
        {
            this.angleUnit = angleUnit;
        }
        public Angle(float value) : this(value, AngleUnit.Radian) { }

        public Angle Add(DeltaAngle deltaAngle)
        {
            float result = value + deltaAngle.Get();
            return new Angle(result);
        }
    }
}
