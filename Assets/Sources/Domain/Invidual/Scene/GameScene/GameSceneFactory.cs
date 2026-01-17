namespace UnityLike
{
    public partial class GameScene
    {
        private class GameSceneFactory
        {
            private readonly GameScene outher;
            private readonly IApplicationFactory application;

            public GameSceneFactory(IApplicationFactory application, GameScene outher)
            {
                this.outher = outher;
                this.application = application;
            }


        }
    }
}
