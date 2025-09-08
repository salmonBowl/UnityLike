using UnityEngine;

using UnityLike.Entities.SceneLoad;

namespace UnityLike.FrameworkAndDrivers.GameObjectManagement
{
    public class ComponentReader
    {
        public GameObjectData Read(GameObjectPrefab gameObjectPrefab)
        {
            GameObjectData data = new();

            TransformData transformData = new();
            RigidbodyData rigidbodyData = new();

            GameObject gameObject = gameObjectPrefab.gameObject;
            
            data.name = gameObjectPrefab.Name;
            data.modelName = gameObjectPrefab.ModelName;
            data.activeSelf = gameObject.activeSelf;
            data.transform = transformData;
            data.rigidbody = rigidbodyData;
            data.voidStart = gameObjectPrefab.GetCodeVoidStart();
            data.voidUpdate = gameObjectPrefab.GetCodeVoidUpdate();

            Transform transform = gameObject.GetComponent<Transform>();
            Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();

            transformData.position = transform.position;
            transformData.eulerAngles = transform.eulerAngles;
            transformData.localScale = transform.localScale;

            rigidbodyData.mass = rigidbody.mass;
            rigidbodyData.useGravity = rigidbody.useGravity;
            rigidbodyData.isKinematic = rigidbody.isKinematic;
            rigidbodyData.velocity = rigidbody.linearVelocity;

            return data;
        }
    }
}
