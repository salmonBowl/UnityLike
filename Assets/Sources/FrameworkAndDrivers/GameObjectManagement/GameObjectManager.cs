using System.Collections.Generic;
using UnityEngine;

using UnityLike.Entities.SceneLoad;
using UnityLike.FrameworkAndDrivers.GameRoop;

namespace UnityLike.FrameworkAndDrivers.GameObjectManagement
{
    public class GameObjectManager : MonoBehaviour, ICodeExecute
    {
        [SerializeField] private GameObject gameObjectPrefab;
        [SerializeField] private ModelList models;

        private readonly List<GameObjectPrefab> gameObjects = new();

        private readonly GameObjectSelection selectionManager = new();
        private readonly ComponentSetter componentSetter = new();

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

        /// <summary>
        /// ボタンからのイベントで呼び出す関数です。オブジェクトを新規作成します。
        /// </summary>
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
        /// データファイルからオブジェクトの状態を復元します
        /// </summary>
        public void LoadGameObject(GameObjectData data)
        {
            string modelName = data.modelName;

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

        public List<GameObjectPrefab> GetAllGameObjects()
        {
            return gameObjects;
        }
    }
}
