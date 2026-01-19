namespace UnityLike.UI
{
    public class CreateWindow : UIObject
    {
        private readonly ActiveStatus activeStatus = new();

        protected override System.Type GetScopeType() => typeof(CreateWindowScope);
        public bool GetActive() => activeStatus.Current();
    }
    public class CreateWindowScope : ScopeBase
    {

    }
}
