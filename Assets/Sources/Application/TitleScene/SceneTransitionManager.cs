using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace UnityLike.FrameworkAndDrivers.TitleScene
{
    public class SceneTransitionManager : MonoBehaviour
    {
        [SerializeField] private Image panel;

        private bool whileFadeOut = false;
        private float panelAlpha = 0f;

        public void StartFadeOut()
        {
            whileFadeOut = true;
        }
        public bool WhileFadeOut()
        {
            return whileFadeOut;
        }

        void Update()
        {
            if (whileFadeOut)
            {
                IncreasePanelAlpha(1.05f);
                SetPanelColorAlpha(panelAlpha);

                if (panelAlpha >= 1.0f)
                {
                    SceneManager.LoadScene(1);
                }
            }
        }

        void IncreasePanelAlpha(float increaseRatio)
        {
            float adjustIncreaseSpeed = 1.03f;
            panelAlpha += (adjustIncreaseSpeed - panelAlpha) * (increaseRatio - 1);
            panelAlpha = Mathf.Clamp01(panelAlpha);
        }

        void SetPanelColorAlpha(float panelAlpha)
        {
            Color panelColor = panel.color;
            panelColor.a = panelAlpha;
            panel.color = panelColor;
        }
    }
}
