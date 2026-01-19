namespace UnityLike.UI
{
    public abstract class ILoadWindowEntity : ScopedClass, IUIEntity
    {
        protected override System.Type GetScopeType() => typeof(LoadWindowEntityScope);

        public abstract void DrawUpdate();
    }
    public class LoadWindowEntityScope : EntityScope { }
}
