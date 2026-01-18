namespace UnityLike
{
    public abstract class Actor : ScopedClass
    {
        public abstract void SetUp();
        public abstract void Update();
    }
    public abstract class ActorScope : ScopeBase
    {

    }
}
