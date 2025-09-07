using System.Collections;
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

        private readonly List<GameObjectPrefab> gameObjects = new();
        private GameObjectPrefab selectedGameObject;

        [SerializeField] private SceneLoader sceneLoader;
        private readonly ComponentSetter componentSetter = new();
        private readonly ComponentReader componentReader = new();

        public void ChangeSelected(GameObjectPrefab target)
        {
            // 元々選択していたオブジェクトの選択を外します
            if (selectedGameObject)
            {
                // エディターを閉じる
                selectedGameObject.EditorSetActive(false);
                // ハイライトを非表示
                selectedGameObject.HighlightSetActive(false);
            }

            // selectedGameObjectを変更します
            selectedGameObject = target;

            // 新しく選択するオブジェクトを選択します
            if (target)
            {
                // ハイライトを表示
                target.HighlightSetActive(true);
                // エディターを開く
                // この処理は時間がかかるため、ハイライトの描画を先に行っています
                StartCoroutine(OpenCodeEditor(target));
            }
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
        /// データファイルからオブジェクトを読み込みます
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

            sceneLoader.SaveFile(data);
        }

        private IEnumerator OpenCodeEditor(GameObjectPrefab gameObject)
        {
            yield return null;
            gameObject.EditorSetActive(true);
        }
    }
}
