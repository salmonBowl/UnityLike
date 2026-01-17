namespace UnityLike
{
    public partial class GameScene : Scene
    {
        private readonly GameSceneFactory factory;

        public GameScene(IApplicationFactory applicationFactory)
        {
            factory = new GameSceneFactory(applicationFactory, this);
        }
        protected override System.Type GetScopeType() => typeof(GameSceneScope);
        public override SceneType GetSceneType() => new SceneType.Game();
    }
}
