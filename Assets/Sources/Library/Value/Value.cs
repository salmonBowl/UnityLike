public class Value
{
    protected readonly float value;

    public Value(float value)
    {
        this.value = value;
    }

    public float Get() => value;

    public Value Add(Value other)
    {
        float result = value + other.value;
        return new Value(result);
    }

    public Value Subtract(Value other)
    {
        float result = value - other.value;
        return new Value(result);
    }

    public Value Multiply(Value other)
    {
        float result = value * other.value;
        return new Value(result);
    }

    public Value Divide(Value other)
    {
        float result = value / other.value;
        return new Value(result);
    }
    public bool IsZero()
    {
        return value == 0;
    }
}
