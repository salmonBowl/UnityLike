namespace UnityLike.UI
{
    public abstract class IUnityIconEntity : ScopedClass, IUIEntity
    {
        protected override System.Type GetScopeType() => typeof(UnityIconEntityScope);

        public abstract void DrawUpdate();
    }
    public class UnityIconEntityScope : EntityScope { }
}
