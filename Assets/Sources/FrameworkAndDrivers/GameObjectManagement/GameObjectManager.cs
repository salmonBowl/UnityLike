using System.Collections.Generic;

using UnityLike.FrameworkAndDrivers.GameRoop;

namespace UnityLike.FrameworkAndDrivers.GameObjectManagement
{
    public class GameObjectManager : ICodeExecute
    {
        private readonly List<GameObjectPrefab> gameObjects = new();

        private readonly GameObjectSelection selectionManager = new();

        /// <summary>
        /// gameObjects‚ÌƒŠƒXƒg‚É’Ç‰Á‚µ‚Ü‚·
        /// </summary>
        /// <exception cref="System.ArgumentException"></exception>
        public void Add(GameObjectPrefab gameObject)
        {
            if (gameObjects.Contains(gameObject))
            {
                throw new System.ArgumentException("‚±‚ÌgameObject‚ÍŠù‚É’Ç‰Á‚³‚ê‚Ä‚¢‚Ü‚·");
            }

            gameObjects.Add(gameObject);
        }

        public List<GameObjectPrefab> GetAllGameObjects()
        {
            return gameObjects;
        }

        public void ChangeSelected(GameObjectPrefab target)
        {
            selectionManager.ChangeSelected(target);
        }

        public void ExecuteVoidStart(bool onStopped)
        {
            foreach (var gameObject in gameObjects)
            {
                gameObject.ExecuteVoidStart(onStopped);
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
