namespace UnityLike
{
    public abstract class Scene : ScopedClass
    {
        public abstract SceneType GetSceneType();
        public abstract void SetUp();
        public abstract void Update();
    }
}
