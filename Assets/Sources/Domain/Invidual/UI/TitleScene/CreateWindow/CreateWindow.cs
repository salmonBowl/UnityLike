namespace UnityLike.UI
{
    public partial class CreateWindow : UIObject
    {
        private readonly CreateWindowSetUps setup;
        public class CreateWindow(ITitleSceneApplicationFactory application)
        {
            setup = new CreateWindowSetUps(application, this);
        }
    }
    public class CreateWindowScope : ScopeBase
    {

    }
}
