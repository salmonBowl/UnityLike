using UnityEngine;

namespace UnityLike.FrameworkAndDrivers.GameObjectManagement
{
    public class ModelManager : MonoBehaviour
    {
        [SerializeField] private Material highlightMaterial;

        private GameObject model;
        private SwitchHighlight highlight;

        /// <summary>
        /// V‚µ‚­ƒ‚ƒfƒ‹‚ğŠi”[‚µ‚Ü‚·
        /// </summary>
        /// <param name="newModel"></param>
        public void SetModel(GameObject newModel, Transform parent)
        {
            // Œ³‚Ìƒ‚ƒfƒ‹‚Í”jŠü
            if (model != null)
            {
                Destroy(model);
            }

            model = newModel;
            highlight = new SwitchHighlight(newModel, parent, highlightMaterial);
        }
        public void ChangeModel()
        {

        }
        public void HighlightSetActive(bool value)
        {
            highlight.SetActive(value);
        }
    }
}
