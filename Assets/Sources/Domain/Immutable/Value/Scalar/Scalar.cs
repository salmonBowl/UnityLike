public class Scalar : Value
{
    public Scalar(float value) : base(value) { }

    public Scalar Multiply(Scalar other)
    {
        float result = value * other.value;

        return new Scalar(result);
    }
}
