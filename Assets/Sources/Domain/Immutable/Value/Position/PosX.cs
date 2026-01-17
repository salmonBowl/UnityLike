public class PosX : Value
{
    public PosX(float x) : base(x) { }

    public PosX Add(PosX other)
    {
        float result = value + other.value;

        return new PosX(result);
    }
    public PosX Subtract(PosX other)
    {
        float result = value - other.value;

        return new PosX(result);
    }
    public PosX Multiply(DisplacementScalar magnification)
    {
        float result = value * magnification.Get();

        return new PosX(result);
    }
}
