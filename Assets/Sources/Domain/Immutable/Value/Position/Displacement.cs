public class Displacement
{
    protected readonly PosX x;
    protected readonly PosY y;
    protected readonly PosZ z;

    public Displacement(PosX x, PosY y, PosZ z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    public Displacement(float x, float y, float z)
    {
        this.x = new PosX(x);
        this.y = new PosY(y);
        this.z = new PosZ(z);
    }
    public Displacement(PosX x, float y, float z)
    {
        this.x = x;
        this.y = new PosY(y);
        this.z = new PosZ(z);
    }
    public Displacement(float x, PosY y, float z)
    {
        this.x = new PosX(x);
        this.y = y;
        this.z = new PosZ(z);
    }
    public Displacement(float x, float y, PosZ z)
    {
        this.x = new PosX(x);
        this.y = new PosY(y);
        this.z = z;
    }

    public PosX GetX() => x;
    public PosY GetY() => y;
    public PosZ GetZ() => z;

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

    public Displacement Multiply(DisplacementScalar magnification)
    {
        PosX x = this.x.Multiply(magnification);
        PosY y = this.y.Multiply(magnification);
        PosZ z = this.z.Multiply(magnification);

        return new Displacement(x, y, z);
    }
}