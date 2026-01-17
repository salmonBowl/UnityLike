namespace UnityLike
{
    public class Time : LargeValue
    {
        private readonly TimeUnit timeUnit = TimeUnit.sec;

        public Time(double value) : base(value) { }
        public Time(LargeValue value) : base(value.Get()) { }
        public Time(double value, TimeUnit timeUnit) : this(value)
        {
            this.timeUnit = timeUnit;
        }
        public Time(LargeValue value, TimeUnit timeUnit) : this(value)
        {
            this.timeUnit = timeUnit;
        }

        public TimeUnit CurrentTimeUnit() => timeUnit;

        public Time Add(TimeSpan addTime)
        {
            if (addTime.GetTimeUnit() != timeUnit)
                throw new UnitIncorrectException("ŠÔ‚Ì’PˆÊ‚ª³‚µ‚­‚ ‚è‚Ü‚¹‚ñ");

            double result = value + addTime.Get();
            return new Time(result, timeUnit);
        }
    }
}