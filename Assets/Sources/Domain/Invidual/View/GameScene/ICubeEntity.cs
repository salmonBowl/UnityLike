namespace UnityLike
{
    public abstract class ICubeEntity : ScopedClass, IEntity
    {
        protected override System.Type GetScopeType() => typeof(ScopeBase);

        public abstract void DrawUpdate();
    }
    public class CubeEntityScope : ScopeBase { }
}
