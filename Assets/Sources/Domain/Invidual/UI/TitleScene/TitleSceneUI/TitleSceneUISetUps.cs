namespace UnityLike.UI
{
    public partial class TitleSceneUI
    {
        private class TitleSceneUISetUps
        {
            private readonly TitleSceneUI outher;
            private readonly ITitleSceneApplicationFactory application;

            private readonly EntityList entityList;

            public TitleSceneUISetUps(ITitleSceneApplicationFactory application, TitleSceneUI outher)
            {
                this.application = application;
                this.outher = outher;

                entityList = outher.entityList;
            }

            public void UnityIcon()
            {
                using (outher.MemberInitialization(2))
                {
                    var unityIconEntity = application.ConnectUnityIconEntity(outher.unityIcon);

                    entityList.Add(unityIconEntity);
                }
            }

            public void CreateWindow(out IButtonInput createWindowButtonInput)
            {
                createWindowButtonInput = application.GetCreateWindowButtonInput();

                using (outher.MemberInitialization(1))
                {
                    var createWindowEntity = application.ConnectCreateWindowEntity(outher.createWindow);

                    entityList.Add(createWindowEntity);
                }
            }

            public void LoadWindow(out IButtonInput loadWindowButtonInput)
            {
                loadWindowButtonInput = application.GetLoadWindowButtonInput();

                using (outher.MemberInitialization(1))
                {
                    var loadWindowEntity = application.ConnectLoadWindowEntity(outher.loadWindow);

                    entityList.Add(loadWindowEntity);
                }
            }
        }
    }
}
