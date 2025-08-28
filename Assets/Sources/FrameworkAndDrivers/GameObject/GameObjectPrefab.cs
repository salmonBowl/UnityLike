using UnityEngine;

using UnityLike.FrameworkAndDrivers.CodeEditor;

namespace UnityLike.FrameworkAndDrivers.GameObjectManagement
{
    public class GameObjectPrefab : MonoBehaviour
    {
        [SerializeField] private CodeEditorManager codeEditorCanvas;

        private GameObject model;

        public void ExecuteVoidStart() => codeEditorCanvas.ExecuteVoidStart();
        public void ExecuteVoidUpdate() => codeEditorCanvas.ExecuteVoidUpdate();

        public void EditorSetActive(bool value)
        {
            codeEditorCanvas.gameObject.SetActive(value);
        }

        public static GameObjectPrefab Instantiate(GameObject prefab, GameObject model)
        {
            GameObject newGameObject = Instantiate(prefab);
            GameObject newModel = Instantiate(model, newGameObject.transform);

            newModel.tag = "ObjectModel";

            GameObjectPrefab retval = newGameObject.GetComponent<GameObjectPrefab>();
            retval.model = newModel;
            return retval;
        }
    }
}
