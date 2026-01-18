namespace UnityLike
{
    public partial class TitleScene : Scene
    {
        // TitleScene本体
        private readonly TitleSceneFactory factory;
        private readonly TitleSceneUI ui;

        // メンバー
        private readonly ActorList actorList;
        private readonly EntityList entityList;
        private readonly Clock clock = new();

        // コンストラクタ―
        public TitleScene(ITitleSceneApplicationFactory application)
        {
            factory = new TitleSceneFactory(application, this);
        }

        // オーバーライド
        protected override System.Type GetScopeType() => typeof(TitleSceneScope);
        public override SceneType GetSceneType() => new SceneType.Title();

        // ゲッター
    }

    // スコープ
    public class TitleSceneScope : SceneScope
    {

    }
}
