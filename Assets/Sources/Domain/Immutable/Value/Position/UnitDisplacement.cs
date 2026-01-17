public class UnitDisplacement : Displacement
{
    protected UnitDisplacement(float x, float y, float z) : base(x, y, z) { }

    public static UnitDisplacement Right => new(1, 0, 0);
    public static UnitDisplacement Left => new(-1, 0, 0);
    public static UnitDisplacement Up => new(0, 1, 0);
    public static UnitDisplacement Down => new(0, -1, 0);
    public static UnitDisplacement Forward => new(0, 0, 1);
    public static UnitDisplacement Back => new(0, 0, -1);

    public Displacement ScaleBy(DisplacementScalar magnification)
    {
        PosX x = this.x.Multiply(magnification);
        PosY y = this.y.Multiply(magnification);
        PosZ z = this.z.Multiply(magnification);

        return new Displacement(x, y, z);
    }
}
