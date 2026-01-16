using UnityEngine;

using UnityLike.Entities.SceneLoad;

namespace UnityLike.FrameworkAndDrivers.SceneLoad
{
    public class ComponentSetter
    {
        public void Set(GameObject gameObject, GameObjectData data)
        {
            Transform transform = gameObject.GetComponent<Transform>();
            Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();

            transform.position = data.transform.position;
            transform.eulerAngles = data.transform.eulerAngles;
            transform.localScale = data.transform.localScale;

            rigidbody.mass = data.rigidbody.mass;
            rigidbody.useGravity = data.rigidbody.useGravity;
            rigidbody.isKinematic = data.rigidbody.isKinematic;
            if (!rigidbody.isKinematic)
                rigidbody.linearVelocity = data.rigidbody.velocity;

            gameObject.SetActive(data.activeSelf);
        }
        public void SetAsInitialize(GameObject gameObject, out GameObjectData initialData)
        {
            Transform transform = gameObject.GetComponent<Transform>();
            Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();

            transform.position = Vector3.zero;
            transform.eulerAngles = Vector3.zero;
            transform.localScale = Vector3.one;

            rigidbody.mass = 1;
            rigidbody.useGravity = true;
            rigidbody.isKinematic = true;

            gameObject.SetActive(true);

            initialData = new()
            {
                name = "新規オブジェクト",
                voidStart =
                "transform.position = new Vector3(0, 0, 0);\n" +
                "transform.eulerAngles = new Vector3(0, 0, 0);\n" +
                "transform.localScale = new Vector3(1, 1, 1);",
                voidUpdate = "",
            };
        }
    }
}
