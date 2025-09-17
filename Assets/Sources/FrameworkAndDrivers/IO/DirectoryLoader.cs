using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace UnityLike.FrameworkAndDrivers.IO
{
    public class DirectoryLoader
    {
        public List<string> GetAllFileNames()
        {
            string savePath = Application.dataPath + "/SaveData";

            List<string> fileNames = new();
            if (!Directory.Exists(savePath))
            {
                Debug.LogError("SaveData directory not found at: " + savePath);
                return fileNames;
            }

            string[] filePaths = Directory.GetFiles(savePath, "*.json");
            foreach (string filePath in filePaths)
            {
                fileNames.Add(Path.GetFileNameWithoutExtension(filePath));
            }

            return fileNames;
        }
    }
}
