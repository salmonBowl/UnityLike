namespace UnityLike
{
    public interface IButtonInput
    {
        event BlankEventHandler OnPressDown;
        event BlankEventHandler OnMouseOverEnter;
        event BlankEventHandler OnMouseOverLeave;
    }
}
