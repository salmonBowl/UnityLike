using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityLike.Entities.SceneLoad
{
    [Serializable]
    public class LoadData
    {
        public List<GameObjectData> gameObjects = new();
    }

    [Serializable]
    public class GameObjectData
    {
        public string name;
        public string modelName;
        public bool activeSelf;
        public TransformData transform;
        public RigidbodyData rigidbody;
        public string voidStart;
        public string voidUpdate;
    }

    [Serializable]
    public class TransformData
    {
        public Vector3 position;
        public Vector3 eulerAngles;
        public Vector3 localScale;
    }

    [Serializable]
    public class RigidbodyData
    {
        public float mass;
        public bool useGravity;
        public bool isKinematic;
        public Vector3 velocity;
    }
}
