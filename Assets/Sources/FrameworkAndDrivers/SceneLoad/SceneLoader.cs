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

        void Start()
        {
            LoadSceneFromFile("SaveData/first_scene.json");
        }

        public void LoadSceneFromFile(string relativePath)
        {
            string filePath = Path.Combine(Application.dataPath, relativePath);

            if (!File.Exists(filePath))
            {
                Debug.LogError($"ファイルが見つかりません: {filePath}");
            }

            try
            {
                string jsonString = File.ReadAllText(filePath);
                LoadData loadData = JsonUtility.FromJson<LoadData>(jsonString);

                foreach (var gameObjectData in loadData.gameObjects)
                {
                    gameObjectManager.LoadGameObject(gameObjectData.modelName, gameObjectData);
                }

                Debug.Log("Sceneファイルが正常に読み込まれました。");
            }
            catch (System.Exception ex)
            {
                Debug.LogError($"JSONファイルの読み込み中にエラーが発生しました: {ex.Message}");
            }
        }
    }
}
