namespace UnityLike.UI
{
    public abstract class ICreateWindowEntity : ScopedClass, IUIEntity
    {
        protected override System.Type GetScopeType() => typeof(CreateWindowEntityScope);

        public abstract void DrawUpdate();
    }
    public class CreateWindowEntityScope : EntityScope { }
}
