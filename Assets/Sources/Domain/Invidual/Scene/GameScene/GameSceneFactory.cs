namespace UnityLike
{
    public partial class GameScene
    {
        private class GameSceneFactory
        {
            private readonly GameScene outher;
            private readonly IGameSceneApplicationFactory application;

            public GameSceneFactory(IGameSceneApplicationFactory application, GameScene outher)
            {
                this.outher = outher;
                this.application = application;
            }


        }
    }
}
