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
    }
}
