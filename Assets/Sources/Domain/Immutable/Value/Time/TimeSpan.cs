namespace UnityLike
{
    public class TimeSpan : Value
    {
        private readonly TimeUnit timeUnit;

        public TimeSpan(float value, TimeUnit timeUnit) : base(value)
        {
            this.timeUnit = timeUnit;
        }
        public TimeSpan(float value) : this(value, TimeUnit.sec) { }

        public TimeUnit GetTimeUnit() => timeUnit;
    }
}
