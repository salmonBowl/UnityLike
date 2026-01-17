namespace UnityLike
{
    public abstract class IUnityIconEntity : ScopedClass
    {
        protected override System.Type GetScopeType() => typeof(UnityIconEntityScope);
    }
    public class UnityIconEntityScope : EntityScope { }
}
