using System.Collections.Generic;
using UnityEngine;

using UnityLike.Entities.SceneLoad;
using UnityLike.FrameworkAndDrivers.FileAdapter;

namespace UnityLike.FrameworkAndDrivers.GameObjectManagement
{
    public class GameObjectManager : MonoBehaviour, IChangeSelected, ICodeExecute
    {
        [SerializeField] private GameObject gameObjectPrefab;
        [SerializeField] private ModelList models;
        [SerializeField] private SceneLoader sceneLoader;

        private readonly List<GameObjectPrefab> gameObjects = new();

        private readonly GameObjectSelectionManager selectionManager = new();
        private readonly ComponentSetter componentSetter = new();
        private readonly ComponentReader componentReader = new();

        void OnApplicationQuit()
        {
            SaveScene();
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

        public void AddNewObject()
        {
            AddNewObject("新規オブジェクト", "Cube");
        }
        /// <summary>
        /// オブジェクトを新規作成します
        /// </summary>
        public void AddNewObject(string objectName, string modelName)
        {
            // モデルのオブジェクトを取得
            if (!models.TryGetValue(modelName, out var modelObject))
            {
                throw new KeyNotFoundException($"モデル名'{modelName}'が見つかりませんでした");
            }

            // モデルからInstantiate
            GameObjectPrefab gameObject = GameObjectPrefab.Instantiate
                (objectName, modelName, gameObjectPrefab, modelObject);

            // 新規オブジェクトの初期値を設定
            componentSetter.SetAsInitialize(gameObject.gameObject);

            // GameObjectリストに格納
            gameObjects.Add(gameObject);
        }
        /// <summary>
        /// データファイルからオブジェクトを1つずつ読み込みます
        /// </summary>
        public void LoadGameObject(string modelName, GameObjectData data)
        {
            // モデルのオブジェクトを取得
            if (!models.TryGetValue(modelName, out var modelObject))
            {
                throw new KeyNotFoundException($"モデル名'{modelName}'が見つかりませんでした");
            }

            // モデルからInstantiate
            GameObjectPrefab gameObject = GameObjectPrefab.Instantiate
                (data.name, data.modelName, gameObjectPrefab, modelObject);

            // 状態の読み込み
            componentSetter.Set(gameObject.gameObject, data);

            // テキストを読み込み
            gameObject.SetNameInputField(data.name);
            gameObject.SetCodeVoidStart(data.voidStart);
            gameObject.SetCodeVoidUpdate(data.voidUpdate);

            // GameObjectリストに格納
            gameObjects.Add(gameObject);
        }
        public void SaveScene()
        {
            LoadData data = new();
            foreach (var gameObject in gameObjects)
            {
                data.gameObjects.Add(componentReader.Read(gameObject));
            }

            if (data.gameObjects.Count == 0)
            {
                Debug.Log("実行中のビルドにより、このシーンは保存しません");
                return;
            }
            sceneLoader.SaveFile(data);
        }
    }
}
