namespace UnityLike
{
    public partial class TitleScene : Scene
    {
        public override void SetUp()
        {
            ui.SetUp();

            clock.Restart();
        }
        public override SceneType Update(DeltaTime deltaTime)
        {
            clock.Advance(deltaTime);

            WorldTime.SyncClock(clock, deltaTime);

            ui.DrawUpdate();
        }
    }
}
