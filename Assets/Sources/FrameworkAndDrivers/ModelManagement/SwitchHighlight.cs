using UnityEngine;

namespace UnityLike.FrameworkAndDrivers.GameObjectManagement
{
    public class SwitchHighlight
    {
        private readonly GameObject copyModel;

        public SwitchHighlight(GameObject model, Transform parent, Material material)
        {
            copyModel = Object.Instantiate(model, parent);
            copyModel.GetComponent<Renderer>().material = material;
        }

        public void SetActive(bool value)
        {
            copyModel.SetActive(value);
        }
    }
}
