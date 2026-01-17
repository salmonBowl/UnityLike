namespace UnityLike.View
{
    public abstract class ICubeEntity : ScopedClass
    {
        protected override System.Type GetScopeType() => typeof(ScopeBase);
    }
    public class CubeEntityScope : ScopeBase { }
}
