using UnityEngine;

namespace UnityLike.Application
{
    public class ButtonInput : MonoBehaviour, IButtonInput
    {
        public event BlankEventHandler OnPressDown;
        public event BlankEventHandler OnMouseOverEnter;
        public event BlankEventHandler OnMouseOverLeave;

        public void PressDown()
        {
            OnPressDown?.Invoke();
        }
        public void MouseOverEnter()
        {
            OnMouseOverEnter?.Invoke();
        }
        public void MouseOverLeave()
        {
            OnMouseOverLeave?.Invoke();
        }
    }
}
