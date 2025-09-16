
namespace UnityLike.FrameworkAndDrivers.SceneLoad
{
    public static class FilePath
    {
        private static string CurrentPath = "SaveData/first_scene.json";

        public static string GetPath() => CurrentPath;
        public static void SetPath(string path) => CurrentPath = path; 
    }
}
