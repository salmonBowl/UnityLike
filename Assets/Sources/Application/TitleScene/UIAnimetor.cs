using UnityEngine;

namespace UnityLike.FrameworkAndDrivers.TitleScene
{
    public class UIAnimator : MonoBehaviour
    {
        [SerializeField] private RectTransform unityIcon;

        private float angleDegDestination = 0;

        public void SetRotationDestination(float angle)
        {
            angleDegDestination = angle;
        }

        void Update()
        {
            // ŠŠ‚ç‚©‚ÉŠp“x‚ð•Ï‰»‚³‚¹‚é
            unityIcon.rotation = Quaternion.Lerp(
                Quaternion.Euler(0, 0, angleDegDestination),
                unityIcon.rotation,
                0.9f
            );
        }
    }
}
