public class Coodinate : PositionVector
{
    public Coodinate(PosX x, PosY y, PosZ z) : base(x, y, z) { }
    public Coodinate(float x, float y, float z) : base(x, y, z) { }

    public Coodinate Add(Displacement other)
    {
        PosX x = this.x.Add(other.GetX());
        PosY y = this.y.Add(other.GetY());
        PosZ z = this.z.Add(other.GetZ());

        return new Coodinate(x, y, z);
    }
    public Displacement Subtract(Coodinate other)
    {
        PosX x = this.x.Subtract(other.GetX());
        PosY y = this.y.Subtract(other.GetY());
        PosZ z = this.z.Subtract(other.GetZ());

        return new Displacement(x, y, z);
    }
}
