namespace UnityLike.UI
{
    public class ViewableUnityIcon
    {
        private readonly UnityIcon icon;
        
        public ViewableUnityIcon(UnityIcon icon)
        {
            this.icon = icon;
        }

        public Angle GetAngle() => icon.GetAngle();
    }
}
