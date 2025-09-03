using UnityEngine;

using UnityLike.FrameworkAndDrivers.CodeEditor;

namespace UnityLike.FrameworkAndDrivers.GameObjectManagement
{
    [RequireComponent(typeof(ModelManager))]
    public class GameObjectPrefab : MonoBehaviour
    {
        [SerializeField] private CodeEditorManager codeEditor;
        [SerializeField] private GameObject codeEditorCanvas;

        private ModelManager model;

        void Start()
        {
            model = GetComponent<ModelManager>();
        }

        public void ExecuteVoidStart() => codeEditor.ExecuteVoidStart();
        public void ExecuteVoidUpdate() => codeEditor.ExecuteVoidUpdate();

        public void EditorSetActive(bool value)
        {
            codeEditorCanvas.SetActive(value);
        }
        public void HighlightSetActive(bool value)
        {
            model.HighlightSetActive(value);
        }

        public static GameObjectPrefab Instantiate(GameObject prefab, GameObject model)
        {
            GameObject newGameObject = Instantiate(prefab);
            GameObject newModel = Instantiate(model, newGameObject.transform);

            newModel.tag = "ObjectModel";

            GameObjectPrefab gameObject = newGameObject.GetComponent<GameObjectPrefab>();
            gameObject.model = gameObject.GetComponent<ModelManager>();
            gameObject.model.SetModel(newModel, gameObject.transform);

            gameObject.model.HighlightSetActive(false);

            return gameObject;
        }
    }
}
