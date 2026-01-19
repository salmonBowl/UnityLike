namespace UnityLike.UI
{
    public partial class LoadWindow : UIObject
    {
        private readonly ActiveStatus activeStatus;

        protected override System.Type GetScopeType() => typeof(LoadWindowScope);
        public bool GetActive() => activeStatus.Current();
    }
    public class LoadWindowScope : ScopeBase
    {

    }
}
