namespace UnityLike
{
    public class UnitPositionVector : PositionVector
    {
        protected UnitPositionVector(UnitPositionVector vector3) : base(vector3.x, vector3.y, vector3.z) { }

        protected UnitPositionVector(PosX x, PosY y, PosZ z) : base(x, y, z) { }
        protected UnitPositionVector(float x, float y, float z) : base(x, y, z) { }

        public static UnitPositionVector Right => new(1, 0, 0);
        public static UnitPositionVector Left => new(-1, 0, 0);
        public static UnitPositionVector Up => new(0, 1, 0);
        public static UnitPositionVector Down => new(0, -1, 0);
        public static UnitPositionVector Forward => new(0, 0, 1);
        public static UnitPositionVector Back => new(0, 0, -1);

        public Displacement ScaleBy(PositionScalar magnification)
        {
            PosX x = this.x.Multiply(magnification);
            PosY y = this.y.Multiply(magnification);
            PosZ z = this.z.Multiply(magnification);

            return new Displacement(x, y, z);
        }

        public static UnitPositionVector Normalize(PositionVector vector3)
        {
            PositionScalar length = vector3.Magnitude;

            if (length.IsZero())
            {
                // ï‘Ç∑Ç◊Ç´å¸Ç´Ç™íËÇ‹ÇÁÇ»Ç¢ÇÃÇ≈ÅAÇ±Ç±Ç≈ÇÕ(1, 0, 0)Ç≈ï‘ÇµÇ‹Ç∑
                return Right;
            }

            PositionScalarReciprocal magnification = length.Reciprocal();

            PosX x = vector3.GetX().Multiply(magnification);
            PosY y = vector3.GetY().Multiply(magnification);
            PosZ z = vector3.GetZ().Multiply(magnification);

            return new UnitPositionVector(x, y, z);
        }
    }
}
