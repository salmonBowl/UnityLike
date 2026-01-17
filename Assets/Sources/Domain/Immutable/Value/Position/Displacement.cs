namespace UnityLike
{
    public class Displacement : PositionVector
    {
        public Displacement(PosX x, PosY y, PosZ z) : base(x, y, z) { }
        public Displacement(float x, float y, float z) : base(x, y, z) { }
        public Displacement(PosX x, float y, float z) : base(x, new PosY(y), new PosZ(z)) { }
        public Displacement(float x, PosY y, float z) : base(new PosX(x), y, new PosZ(z)) { }
        public Displacement(float x, float y, PosZ z) : base(new PosX(x), new PosY(y), z) { }

        public Displacement Add(Displacement other)
        {
            PosX x = this.x.Add(other.GetX());
            PosY y = this.y.Add(other.GetY());
            PosZ z = this.z.Add(other.GetZ());

            return new Displacement(x, y, z);
        }

        public Displacement Subtract(Displacement other)
        {
            PosX x = this.x.Subtract(other.GetX());
            PosY y = this.y.Subtract(other.GetY());
            PosZ z = this.z.Subtract(other.GetZ());

            return new Displacement(x, y, z);
        }

        public Displacement Multiply(PositionScalar magnification)
        {
            PosX x = this.x.Multiply(magnification);
            PosY y = this.y.Multiply(magnification);
            PosZ z = this.z.Multiply(magnification);

            return new Displacement(x, y, z);
        }
    }
}