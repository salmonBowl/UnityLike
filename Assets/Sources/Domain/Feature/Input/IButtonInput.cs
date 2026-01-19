namespace UnityLike
{
    public interface IButtonInput
    {
        WeakEvent OnPressDown { get; set; }
        WeakEvent OnMouseOverEnter { get; }
        WeakEvent OnMouseOverExit { get; }
    }
}
