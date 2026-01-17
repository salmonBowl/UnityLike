namespace UnityLike
{
    public class RotationAxis : UnitPositionVector
    {
        public RotationAxis(UnitPositionVector normalized) : base(normalized) { }

        protected RotationAxis(float x, float y, float z) : base(x, y, z) { }

        public static RotationAxis AxisX => new(1, 0, 0);
        public static RotationAxis AxisY => new(0, 1, 0);
        public static RotationAxis AxisZ => new(0, 0, 1);
    }
}
