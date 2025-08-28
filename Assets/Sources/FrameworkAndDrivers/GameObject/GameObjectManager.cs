using System.Collections.Generic;
using UnityEngine;

namespace UnityLike.FrameworkAndDrivers.GameObjectManagement
{
    public class GameObjectManager : MonoBehaviour
    {
        [SerializeField] private GameObject gameObjectPrefab;

        private List<GameObjectPrefab> gameObjects;
        private GameObjectPrefab selectedGameObject;

        public void AddGameObject(GameObject model)
        {
            GameObjectPrefab g = GameObjectPrefab.Instantiate(gameObjectPrefab, model);
            gameObjects.Add(g);
        }

        public void SelectObject(GameObjectPrefab target)
        {
            selectedGameObject.EditorSetActive(false);

            selectedGameObject = target;

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