using UnityEngine;

using UnityLike.FrameworkAndDrivers.Mesh;

namespace UnityLike.FrameworkAndDrivers.GameObjectManagement
{
    public class Highlight
    {
        private readonly GameObject copyModel;

        public Highlight(GameObject model, Transform parent, Material material)
        {
            copyModel = Object.Instantiate(model, parent);
            copyModel.AddComponent<OutLine>();
            copyModel.GetComponent<Renderer>().material = material;
        }

        public void SetActive(bool value)
        {
            copyModel.SetActive(value);
        }

        public void SetModelSize(Vector3 size)
        {
            copyModel.transform.localScale = size;
        }
    }
}
