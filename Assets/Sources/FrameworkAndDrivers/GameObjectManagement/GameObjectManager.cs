using System.Collections.Generic;
using UnityEngine;

namespace UnityLike.FrameworkAndDrivers.GameObjectManagement
{
    public class GameObjectManager : MonoBehaviour, IChangeSelected
    {
        [SerializeField] private GameObject gameObjectPrefab;

        private readonly List<GameObjectPrefab> gameObjects = new();
        private GameObjectPrefab selectedGameObject;

        public void AddGameObject(GameObject model)
        {
            GameObjectPrefab g = GameObjectPrefab.Instantiate(gameObjectPrefab, model);
            gameObjects.Add(g);
        }

        public void ChangeSelected(GameObjectPrefab target)
        {
            // 元々選択していたオブジェクトのエディターを閉じます
            if (selectedGameObject)
                selectedGameObject.EditorSetActive(false);

            // selectedGameObjectを変更します
            selectedGameObject = target;

            // 新しく選択するオブジェクトのエディターを開きます
            if (target)
                target.EditorSetActive(true);
        }

        public void ExecuteVoidStart()
        {
            foreach(var gameObject in gameObjects)
            {
                gameObject.ExecuteVoidStart();
            }
        }
        public void ExecuteVoidUpdate()
        {
            foreach (var gameObject in gameObjects)
            {
                gameObject.ExecuteVoidUpdate();
            }
        }
    }
}