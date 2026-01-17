public class Coodinate
{
    private readonly PosX x;
    private readonly PosY y;
    private readonly PosZ z;

    public Coodinate(PosX x, PosY y, PosZ z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    public Coodinate(float x, float y, float z)
    {
        this.x = new PosX(x);
        this.y = new PosY(y);
        this.z = new PosZ(z);
    }

    public PosX GetX() => x;
    public PosY GetY() => y;
    public PosZ GetZ() => z;

    public Coodinate Add(Displacement other)
    {
        PosX x = this.x.Add(other.GetX());
        PosY y = this.y.Add(other.GetY());
        PosZ z = this.z.Add(other.GetZ());

        return new Coodinate(x, y, z);
    }
}
