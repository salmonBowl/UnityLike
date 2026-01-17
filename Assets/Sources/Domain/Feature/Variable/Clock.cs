namespace UnityLike
{
    public class Clock
    {
        private Time time;

        public Clock()
        {
            time = new(0.0f);
        }

        public Time CurrentTime() => time;
        public TimeUnit CurrentTimeUnit() => time.CurrentTimeUnit();

        public void SetTime(Time time)
        {
            this.time = time;
        }

        public void Advance(DeltaTime addTime)
        {
            time = time.Add(addTime);
        }

        public void Restart()
        {
            time = new Time(0.0f, time.CurrentTimeUnit());
        }
    }
}