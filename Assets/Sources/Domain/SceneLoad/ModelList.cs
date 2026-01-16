using System;
using System.Collections.Generic;
using GameObject = UnityEngine.GameObject;

namespace UnityLike.Entities.SceneLoad
{
    // Dictionaryのようなものをインスペクター上で管理するためのクラスです
    [Serializable]
    public class ModelList
    {
        public List<ObjectModel> models;

        public bool TryGetValue(string key, out GameObject output)
        {
            output = null;

            foreach(var model in models)
            {
                if (model.name == key)
                {
                    output = model.gameObject;
                    return true;
                }
            }
            return false;
        }
    }

    [Serializable]
    public class ObjectModel
    {
        public string name;
        public GameObject gameObject;
    }
}
