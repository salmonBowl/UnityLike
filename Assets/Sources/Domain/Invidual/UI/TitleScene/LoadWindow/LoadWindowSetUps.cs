namespace UnityLike.UI
{
    public partial class LoadWindow
    {
        private class LoadWindowSetUps
        {
            private readonly LoadWindow outher;
            private readonly ITitleSceneApplicationFactory application;

            public LoadWindowSetUps(ITitleSceneApplicationFactory application, LoadWindow outher)
            {
                this.outher = outher;
                this.application = application;
            }
        }
    }
}
