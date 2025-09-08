using UnityEngine;

namespace UnityLike.FrameworkAndDrivers.GameObjectManagement
{
    public class ModelManager : MonoBehaviour
    {
        [SerializeField] private Material highlightMaterial;

        private GameObject model;
        private Highlight highlight;

        /// <summary>
        /// êVÇµÇ≠ÉÇÉfÉãÇäiî[ÇµÇ‹Ç∑
        /// </summary>
        /// <param name="newModel"></param>
        public void SetModel(GameObject newModel, Transform parent)
        {
            // å≥ÇÃÉÇÉfÉãÇÕîjä¸
            if (model != null)
            {
                Destroy(model);
            }

            model = newModel;
            highlight = new Highlight(newModel, parent, highlightMaterial);
        }
        public void ChangeModel()
        {

        }
        public void HighlightSetActive(bool value)
        {
            highlight.SetActive(value);
        }

        public Vector3 GetModelSize()
        {
            return model.transform.localScale;
        }
        public void SetModelSize(Vector3 size)
        {
            model.transform.localScale = size;
            highlight.SetModelSize(size);
        }
    }
}
