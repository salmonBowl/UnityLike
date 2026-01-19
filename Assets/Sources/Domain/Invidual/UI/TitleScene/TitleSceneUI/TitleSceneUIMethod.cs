namespace UnityLike.UI
{
    public partial class TitleSceneUI
    {
        public void SetUp()
        {
            setup.CreateWindow(out var createWindowButtonInput);
            setup.LoadWindow(out var loadWindowButtonInput);
            setup.UnityIcon();

            System.EventHandler handler = new();
            createWindowButtonInput.OnPressDown += handler;

            iconAngleDestination.SetAngle(new Angle(0));
        }

        public void DrawUpdate()
        {
            entityList.DrawAll();
        }
    }
}
