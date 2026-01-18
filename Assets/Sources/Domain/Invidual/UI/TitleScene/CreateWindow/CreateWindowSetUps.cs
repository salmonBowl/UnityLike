namespace UnityLike.UI
{
    public partial class CreateWindow
    {
        private class CreateWindowSetUps
        {
            private readonly CreateWindow outher;
            private readonly ITitleSceneApplicationFactory application;

            public CreateWindowSetUps(ITitleSceneApplicationFactory application, CreateWindow outher)
            {
                this.outher = outher;
                this.application = application;
            }
        }
    }
}
