namespace UnityLike
{
    public class IUnityIconEntity : ScopedClass
    {
        protected override System.Type GetScopeType() => typeof(UnityIconEntityScope);
    }
    public class UnityIconEntityScope : EntityScope { }
}
