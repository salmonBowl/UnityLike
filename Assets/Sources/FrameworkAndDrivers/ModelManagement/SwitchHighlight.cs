using UnityEngine;

using UnityLike.FrameworkAndDrivers.Mesh;

namespace UnityLike.FrameworkAndDrivers.GameObjectManagement
{
    public class SwitchHighlight
    {
        private readonly GameObject copyModel;

        public SwitchHighlight(GameObject model, Transform parent, Material material)
        {
            copyModel = Object.Instantiate(model, parent);
            copyModel.AddComponent<OutLine>();
            copyModel.GetComponent<Renderer>().material = material;
        }

        public void SetActive(bool value)
        {
            copyModel.SetActive(value);
        }
    }
}
