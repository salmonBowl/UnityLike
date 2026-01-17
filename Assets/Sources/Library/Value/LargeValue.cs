public class LargeValue
{
    protected readonly double value;

    public LargeValue(double value)
    {
        this.value = value;
    }

    public double Get() => value;

    public LargeValue Add(LargeValue other)
    {
        double result = value + other.value;
        return new LargeValue(result);
    }
    public LargeValue Add(Value other)
    {
        double result = value + other.Get();
        return new LargeValue(result);
    }

    public LargeValue Subtract(LargeValue other)
    {
        double result = value - other.value;
        return new LargeValue(result);
    }
    public LargeValue Subtract(Value other)
    {
        double result = value - other.Get();
        return new LargeValue(result);
    }
}
