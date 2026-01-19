namespace UnityLike.UI
{
    public partial class TitleSceneUI : ScopedClass
    {
        private readonly TitleSceneUISetUps setup;
        private readonly EntityList entityList = new();

        private readonly UnityIcon unityIcon;
        private readonly CreateWindow createWindow;
        private readonly LoadWindow loadWindow;

        private readonly AngleStatus iconAngleDestination = new(AngleUnit.Radian);

        public TitleSceneUI(ITitleSceneApplicationFactory application)
        {
            setup = new TitleSceneUISetUps(application, this);
            
            using (MemberInitialization(3))
            {
                unityIcon = new UnityIcon();
                createWindow = new CreateWindow();
                loadWindow = new LoadWindow();
            }
        }

        protected override System.Type GetScopeType() => typeof(TitleSceneUIScope);
    }

    public class TitleSceneUIScope : ScopeBase
    {

    }
}
