using UnityEngine;
using UnityEngine.UI;

namespace UnityLike.FrameworkAndDrivers.GameRoop
{
    [RequireComponent(typeof(Button))]
    public class PlayButton : MonoBehaviour
    {
        private Button button;

        void Start()
        {
            button = GetComponent<Button>();
        }

        public void Enable()
        {
            button.interactable = true;
        }
        public void Disable()
        {
            button.interactable = false;
        }
    }
}