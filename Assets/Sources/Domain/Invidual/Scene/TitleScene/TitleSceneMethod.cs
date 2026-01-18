namespace UnityLike
{
    public partial class TitleScene : Scene
    {
        public override void SetUp()
        {
            factory.ConnectUnityIcon();


            clock.Restart();

            throw new System.NotImplementedException();
        }
        public override SceneType Update(DeltaTime deltaTime)
        {
            clock.Advance(deltaTime);

            WorldTime.SyncClock(clock, deltaTime);

            throw new System.NotImplementedException();
        }
    }
}
