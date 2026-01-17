namespace UnityLike
{
    public partial class TitleScene
    {
        private class TitleSceneFactory
        {
            private readonly TitleScene outher;
            private readonly ITitleSceneApplicationFactory application;

            public TitleSceneFactory(ITitleSceneApplicationFactory application, TitleScene outher)
            {
                this.outher = outher;
                this.application = application;
            }


        }
    }
}
