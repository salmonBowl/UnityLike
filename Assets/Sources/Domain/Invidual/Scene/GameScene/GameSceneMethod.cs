namespace UnityLike
{
    public partial class GameScene : Scene
    {
        // ÉÅÉìÉoÅ[ÇÃÉÅÉÇ
        
        // GameSceneFactory factory;

        // Clock clock;

        public override void SetUp()
        {
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
