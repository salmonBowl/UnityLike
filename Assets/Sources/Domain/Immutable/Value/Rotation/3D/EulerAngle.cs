namespace UnityLike
{
    public class EulerAngle
    {
        private readonly AngleUnit angleUnit;
        private readonly RotX x;
        private readonly RotY y;
        private readonly RotZ z;

        public EulerAngle(RotX x, RotY y, RotZ z, AngleUnit angleUnit)
        {
            this.angleUnit = angleUnit;
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public EulerAngle(float x, float y, float z, AngleUnit angleUnit) :
            this(new RotX(x), new RotY(y), new RotZ(z), angleUnit) { }
        public EulerAngle(RotX x, RotY y, RotZ z) : this(x, y, z, AngleUnit.Radian) { }
        public EulerAngle(float x, float y, float z) : this(x, y, z, AngleUnit.Radian) { }
    }
}
