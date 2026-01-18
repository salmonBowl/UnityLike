namespace UnityLike
{
    public class TitleSceneUI : ScopedClass
    {
        private readonly ITitleSceneApplicationFactory factory;
        private readonly UIObjectList uiObjectList;
        private readonly EntityList entityList;

        private readonly UnityIcon unityIcon = new();
        private readonly CreateNewSceneButton createNewSceneButton;
        private readonly LoadSceneButton loadSceneButton;

        public TitleSceneUI(ITitleSceneApplicationFactory factory)
        {
            this.factory = factory;
        }

        protected override System.Type GetScopeType() => typeof(TitleSceneUIScope);

        public void SetUp()
        {
            using (MemberInitialization(1))
            {
                var unityIconEntity = factory.ConnectUnityIconEntity(unityIcon);

                entityList.Add(unityIconEntity);
            }
        }
    }

    public class TitleSceneUIScope : ScopeBase
    {

    }
}
