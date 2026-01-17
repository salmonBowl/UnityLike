public class PosZ : Value
{
    public PosZ(float x) : base(x) { }

    public PosZ Add(PosZ other)
    {
        float result = value + other.Get();

        return new PosZ(result);
    }
    public PosZ Subtract(PosZ other)
    {
        float result = value - other.Get();

        return new PosZ(result);
    }
    public PosZ Multiply(DisplacementScalar magnification)
    {
        float result = value * magnification.Get();

        return new PosZ(result);
    }
}
