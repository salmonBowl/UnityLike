namespace UnityLike
{
    public class UnitDisplacement : Displacement
    {
        protected UnitDisplacement(PosX x, PosY y, PosZ z) : base(x, y, z) { }
        protected UnitDisplacement(float x, float y, float z) : base(x, y, z) { }

        public static UnitDisplacement Right => new(1, 0, 0);
        public static UnitDisplacement Left => new(-1, 0, 0);
        public static UnitDisplacement Up => new(0, 1, 0);
        public static UnitDisplacement Down => new(0, -1, 0);
        public static UnitDisplacement Forward => new(0, 0, 1);
        public static UnitDisplacement Back => new(0, 0, -1);

        public Displacement ScaleBy(PositionScalar magnification)
        {
            PosX x = this.x.Multiply(magnification);
            PosY y = this.y.Multiply(magnification);
            PosZ z = this.z.Multiply(magnification);

            return new Displacement(x, y, z);
        }

        public static UnitDisplacement Normalize(PositionVector vector3)
        {
            PositionScalar length = vector3.Magnitude();

            if (length.IsZero())
            {
                // ï‘Ç∑Ç◊Ç´å¸Ç´Ç™íËÇ‹ÇÁÇ»Ç¢ÇÃÇ≈ÅAÇ±Ç±Ç≈ÇÕ(1, 0, 0)Ç≈ï‘ÇµÇ‹Ç∑
                return Right;
            }

            PositionScalar.

            PosX x = vector3.GetX().Multiply(length);
            PosY y = vector3.GetX().Multiply(length);
        }
    }
}
