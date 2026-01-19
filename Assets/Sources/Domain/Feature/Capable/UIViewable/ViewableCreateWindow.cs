namespace UnityLike.UI
{
    public class ViewableCreateWindow
    {
        private readonly CreateWindow createWindow;

        public ViewableCreateWindow(CreateWindow createWindow)
        {
            this.createWindow = createWindow;
        }

        public bool GetActive() => createWindow.GetActive();
    }
}
