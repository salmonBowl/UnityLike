public class PosY : Value
{
    public PosY(float x) : base(x) { }

    public PosY Add(PosY other)
    {
        float result = value + other.Get();

        return new PosY(result);
    }
    public PosY Subtract(PosY other)
    {
        float result = value - other.Get();

        return new PosY(result);
    }
    public PosY Multiply(DisplacementScalar magnification)
    {
        float result = value * magnification.Get();

        return new PosY(result);
    }
}
