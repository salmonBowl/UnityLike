namespace UnityLike
{
    public class TimeSpan : Value
    {
        private readonly TimeUnit timeUnit = TimeUnit.sec;

        public TimeSpan(float value, TimeUnit timeUnit) : base(value)
        {
            this.timeUnit = timeUnit;
        }

        public TimeUnit GetTimeUnit() => timeUnit;
    }
}
