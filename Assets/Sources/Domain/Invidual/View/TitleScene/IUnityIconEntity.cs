namespace UnityLike
{
    public abstract class IUnityIconEntity : ScopedClass, IEntity
    {
        protected override System.Type GetScopeType() => typeof(UnityIconEntityScope);

        public abstract void DrawUpdate();
    }
    public class UnityIconEntityScope : EntityScope { }
}
