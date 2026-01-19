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

            // ‰½‚à‚È‚©‚Á‚½ê‡‚ÍƒV[ƒ“‘JˆÚ‚ğs‚¢‚Ü‚¹‚ñ
            return GetSceneType();
        }
    }
}
