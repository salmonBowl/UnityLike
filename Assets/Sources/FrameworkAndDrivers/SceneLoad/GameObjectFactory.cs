using System.Collections.Generic;
using UnityEngine;

using UnityLike.Entities.SceneLoad;
using UnityLike.FrameworkAndDrivers.GameObjectManagement;

namespace UnityLike.FrameworkAndDrivers.SceneLoad
{
    public class GameObjectFactory : MonoBehaviour
    {
        [SerializeField, Header("オブジェクト新規作成のためのプレハブを取得します")]
        private GameObject gameObjectPrefab;

        [SerializeField, Header("モデルオブジェクトのプレハブを取得します")]
        private ModelList modelList;

        private readonly GameObjectManager gameObjectManager = new();
        private readonly ComponentSetter componentSetter = new();

        /// <summary>
        /// オブジェクトを新規作成します。ボタンからのイベントで呼び出す関数です。
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
            if (!modelList.TryGetValue(modelName, out var modelObject))
            {
                throw new KeyNotFoundException($"モデル名'{modelName}'が見つかりませんでした");
            }

            // モデルからInstantiate
            GameObjectPrefab gameObject = GameObjectPrefab.Instantiate
                (objectName, modelName, gameObjectPrefab, modelObject);

            // 新規オブジェクトの初期値を設定
            componentSetter.SetAsInitialize(gameObject.gameObject);

            // GameObjectリストに格納
            gameObjectManager.Add(gameObject);
        }

        /// <summary>
        /// データファイルからオブジェクトの状態を復元します
        /// </summary>
        public void LoadGameObject(GameObjectData data)
        {
            string modelName = data.modelName;

            // モデルのオブジェクトを取得
            if (!modelList.TryGetValue(modelName, out var modelObject))
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
            gameObjectManager.Add(gameObject);
        }
    }
}
