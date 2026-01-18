namespace UnityLike.UI
{
    public partial class LoadWindow : UIObject
    {
        protected override System.Type GetScopeType() => typeof(LoadWindowScope);
    }
    public class LoadWindowScope : ScopeBase
    {

    }
}
