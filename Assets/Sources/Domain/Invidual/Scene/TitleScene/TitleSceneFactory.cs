namespace UnityLike
{
    public partial class TitleScene
    {
        private class TitleSceneFactory
        {
            private readonly TitleScene outher;
            private readonly IApplicationFactory application;

            public TitleSceneFactory(IApplicationFactory application, TitleScene outher)
            {
                this.outher = outher;
                this.application = application;
            }


        }
    }
}
