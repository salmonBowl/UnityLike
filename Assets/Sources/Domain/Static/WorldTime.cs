namespace UnityLike
{
    public static class WorldTime
    {
        private readonly static Clock clock = new();

        public static DeltaTime DeltaTime { get; private set; }
        public static Time Time { get => clock.CurrentTime(); }

        public static void SyncClock(Clock clock, DeltaTime deltaTime)
        {
            // clock‚ð“¯Šú‚µ‚Ü‚·
            WorldTime.clock.SetTime(clock.CurrentTime());

            DeltaTime = deltaTime;
        }
    }
}
