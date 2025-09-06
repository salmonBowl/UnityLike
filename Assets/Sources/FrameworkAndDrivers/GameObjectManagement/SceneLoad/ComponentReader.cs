using UnityEngine;

using UnityLike.Entities.SceneLoad;

namespace UnityLike.FrameworkAndDrivers.GameObjectManagement
{
    public class ComponentReader
    {
        public GameObjectData Read(GameObjectPrefab gameObjectPrefab)
        {
            GameObjectData data = new();

            GameObject gameObject = gameObjectPrefab.gameObject;
            Transform transform = gameObject.GetComponent<Transform>();
            Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();

            data.transform.position = transform.position;
            data.transform.eulerAngles = transform.eulerAngles;
            data.transform.localScale = transform.localScale;

            data.rigidbody.mass = rigidbody.mass;
            data.rigidbody.useGravity = rigidbody.useGravity;
            data.rigidbody.isKinematic = rigidbody.isKinematic;
            data.rigidbody.velocity = rigidbody.linearVelocity;

            data.activeSelf = gameObject.activeSelf;
            data.name = gameObjectPrefab.Name;
            data.modelName = gameObjectPrefab.ModelName;

            return data;
        }
    }
}
