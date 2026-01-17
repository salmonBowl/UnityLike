namespace UnityLike
{
    public class PositionVector
    {
        protected readonly PosX x;
        protected readonly PosY y;
        protected readonly PosZ z;

        public PositionVector(PosX x, PosY y, PosZ z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public PositionVector(float x, float y, float z)
        {
            this.x = new PosX(x);
            this.y = new PosY(y);
            this.z = new PosZ(z);
        }

        public PosX GetX() => x;
        public PosY GetY() => y;
        public PosZ GetZ() => z;

        public PositionScalar Magnitude
        {
            get
            {
                Value r1 = x.Multiply(x);
                Value r2 = y.Multiply(y);
                Value r3 = z.Multiply(z);

                Value result = r1.Add(r2).Add(r3).SquareRoot();

                return new PositionScalar(result.Get());
            }
        }
    }
}
