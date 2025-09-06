using System.Collections.Generic;
using System.IO;
using UnityEngine;

using UnityLike.Entities.SceneLoad;
using UnityLike.FrameworkAndDrivers.GameObjectManagement;

namespace UnityLike.FrameworkAndDrivers.FileAdapter
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private GameObjectManager gameObjectManager;
        private readonly string relativePath = "SaveData/first_scene.json";

        void Start()
        {
            LoadSceneFromFile();
        }

        public void LoadSceneFromFile()
        {
            string filePath = Path.Combine(Application.dataPath, relativePath);

            if (!File.Exists(filePath))
            {
                Debug.LogError($"ファイルが見つかりません: {filePath}");
            }

            LoadData loadData = new();
            try
            {
                // ファイルを読み込み
                string jsonString = File.ReadAllText(filePath);

                // データの変換
                loadData = JsonUtility.FromJson<LoadData>(jsonString);

                Debug.Log("Sceneファイルが正常に読み込まれました。");
            }
            catch (System.Exception ex)
            {
                Debug.LogError($"JSONファイルの読み込み中にエラーが発生しました: {ex.Message}");
            }

            foreach (var gameObjectData in loadData.gameObjects)
            {
                gameObjectManager.LoadGameObject(gameObjectData.modelName, gameObjectData);
            }
        }

        public void SaveFile(LoadData data)
        {
            string filePath = Path.Combine(Application.dataPath, relativePath);

            try
            {
                // JSONファイルに変換
                string jsonString = JsonUtility.ToJson(data, true);

                // 書き出し
                File.WriteAllText(filePath, jsonString);

                Debug.Log($"シーンが {filePath} に保存されました。");
            }
            catch (System.Exception ex)
            {
                Debug.LogError($"シーンの保存中にエラーが発生しました: {ex.Message}");
            }
        }
    }
}
