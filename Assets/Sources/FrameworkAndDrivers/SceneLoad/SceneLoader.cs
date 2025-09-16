using UnityEngine;
using Zenject;

using UnityLike.Entities.SceneLoad;
using UnityLike.FrameworkAndDrivers.GameObjectManagement;
using UnityLike.FrameworkAndDrivers.IO;

namespace UnityLike.FrameworkAndDrivers.SceneLoad
{
    public class SceneLoader
    {
        [Inject]
        private readonly GameObjectFactory gameObjectFactory;

        [Inject]
        private readonly GameObjectManager gameObjectManager;

        private readonly FileLoader fileLoader;
        private readonly ComponentReader componentReader = new();

        public SceneLoader(GameObjectManager gameObjectManager)
        {
            this.gameObjectManager = gameObjectManager;

            string sceneFilePath = FilePath.GetPath();
            fileLoader = new FileLoader(sceneFilePath);
        }

        public void LoadScene()
        {
            LoadData data = fileLoader.LoadData();

            foreach (var gameObjectData in data.gameObjects)
            {
                gameObjectFactory.LoadGameObject(gameObjectData);
            }
        }
        public void SaveScene()
        {
            LoadData data = new();
            var gameObjects = gameObjectManager.GetAllGameObjects();

            foreach (var gameObject in gameObjects)
            {
                GameObjectData g = componentReader.Read(gameObject);
                data.gameObjects.Add(g);
            }

            if (data.gameObjects.Count != 0)
            {
                fileLoader.SaveFile(data);
            }
            else
            {
                Debug.Log("実行中のビルドにより、このシーンは保存しません");
            }
        }
    }
}
