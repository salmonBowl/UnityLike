public class DisplacementScalar : Scalar
{
    public DisplacementScalar(float multiplier) : base(multiplier) { }

    public DisplacementScalar Multiply(DisplacementScalar other)
    {
        float result = value * other.value;

        return new DisplacementScalar(result);
    }
}
