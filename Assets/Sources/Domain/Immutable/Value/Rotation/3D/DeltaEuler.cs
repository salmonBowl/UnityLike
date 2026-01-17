namespace UnityLike
{
    public class DeltaEuler : EulerAngle
    {
        public DeltaEuler(RotX x, RotY y, RotZ z, AngleUnit angleUnit) : base(x, y, z, angleUnit) { }
        public DeltaEuler(float x, float y, float z, AngleUnit angleUnit) : base(x, y, z, angleUnit) { }
        public DeltaEuler(RotX x, RotY y, RotZ z) : base(x, y, z) { }
        public DeltaEuler(float x, float y, float z) : base(x, y, z) { }
    }
}
