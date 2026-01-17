using UnityEngine;

namespace UnityLike.Application
{
    public abstract class ApplicationFactoryBase : MonoBehaviour
    {
        protected T Create<T>(GameObject prefab)
        {
            if (prefab == null)
                throw new NullReferanceException(prefab + "がアタッチされていません");

            return GetClass<T>(Instantiate(prefab));
        }

        protected T GetClass<T>(GameObject gameObject)
        {
            if (gameObject.TryGetComponent(out T component))
            {
                return component;
            }

            throw new MissingComponentException($"{gameObject}に{typeof(T).Name}がアタッチされていません");
        }
    }
}
