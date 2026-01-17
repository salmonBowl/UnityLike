namespace UnityLike
{
    public partial class GameScene : Scene
    {
        // GameScene本体
        private readonly GameSceneFactory factory;

        // メンバー
        private readonly Clock clock = new();

        // コンストラクタ―
        public GameScene(IGameSceneApplicationFactory application)
        {
            factory = new GameSceneFactory(application, this);
        }

        // オーバーライド
        protected override System.Type GetScopeType() => typeof(GameSceneScope);
        public override SceneType GetSceneType() => new SceneType.Game();

        // ゲッター


    }

    // スコープ
    public class GameSceneScope : SceneScope
    {

    }
}
