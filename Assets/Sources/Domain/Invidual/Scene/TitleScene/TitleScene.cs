namespace UnityLike
{
    public partial class TitleScene : Scene
    {
        protected override System.Type GetScopeType() => typeof(TitleSceneScope);
        public override SceneType GetSceneType() => new SceneType.Title();
    }
}
