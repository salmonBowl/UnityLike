namespace UnityLike
{
    public class DeltaTime : TimeSpan
    {
        public DeltaTime(float value, TimeUnit timeUnit) : base(value, timeUnit) { }
        public DeltaTime(float value) : base(value) { }
    }
}
