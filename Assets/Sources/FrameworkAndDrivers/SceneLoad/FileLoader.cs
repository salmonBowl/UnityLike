using System.IO;
using UnityEngine;

using UnityLike.Entities.SceneLoad;

namespace UnityLike.FrameworkAndDrivers.FileAdapter
{
    public class FileLoader
    {
        private readonly string filePath;

        public FileLoader(string relativeFilePath)
        {
            filePath = Path.Combine(Application.dataPath, relativeFilePath);
        }

        public LoadData LoadData()
        {
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

            return loadData;
        }

        public void SaveFile(LoadData data)
        {
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
