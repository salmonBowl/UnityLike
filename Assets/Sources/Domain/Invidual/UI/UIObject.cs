namespace UnityLike
{
    public abstract class UIObject : ScopedClass
    {
        public virtual void SetUp() { }
        public virtual void Update() { }
    }
    public abstract class UIObjectScope : ScopeBase
    {

    }
}
