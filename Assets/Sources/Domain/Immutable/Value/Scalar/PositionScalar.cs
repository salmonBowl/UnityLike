using UnityLike;

public class PositionScalar : Scalar
{
    public PositionScalar(float multiplier) : base(multiplier) { }

    public PositionScalar Multiply(PositionScalar other)
    {
        float result = value * other.value;

        return new PositionScalar(result);
    }

    public PositionScalarReciprocal Reciprocal()
    {
        if (IsZero())
            throw new System.DivideByZeroException("0ÇÃãtêîÇ™åvéZÇ≥ÇÍÇ‹ÇµÇΩ");

        float result = 1 / value;

        return new PositionScalarReciprocal(result);
    }
}
