using UnityEngine;

using UnityLike.Entities.CodeEditor;
using UnityLike.FrameworkAndDrivers.CodeEditor;

namespace UnityLike.FrameworkAndDrivers.GameObjectManagement
{
    [RequireComponent(typeof(ModelManager))]
    public class GameObjectPrefab : MonoBehaviour
    {
        [SerializeField] private CodeEditorManager codeEditor;
        [SerializeField] private GameObject codeEditorCanvas;

        public string Name { get; set; }
        public string ModelName { get; private set; }

        private ModelManager model;

        void Start()
        {
            model = GetComponent<ModelManager>();
        }

        public void ExecuteVoidStart() => codeEditor.ExecuteVoidStart();
        public void ExecuteVoidUpdate() => codeEditor.ExecuteVoidUpdate();
        public void SetCodeVoidStart(string sourceCode) => codeEditor.SetCodeVoidStart(sourceCode);
        public void SetCodeVoidUpdate(string sourceCode) => codeEditor.SetCodeVoidStart(sourceCode);
        public string GetCodeVoidStart() => codeEditor.GetCodeVoidStart();
        public string GetCodeVoidUpdate() => codeEditor.GetCodeVoidUpdate();

        public void EditorSetActive(bool value)
        {
            codeEditorCanvas.SetActive(value);
        }
        public void HighlightSetActive(bool value)
        {
            model.HighlightSetActive(value);
        }

        public static GameObjectPrefab Instantiate(string name, string modelName, GameObject prefab, GameObject model)
        {
            GameObject newGameObject = Instantiate(prefab);
            GameObject newModel = Instantiate(model, newGameObject.transform);

            newModel.tag = "ObjectModel";

            GameObjectPrefab gameObject = newGameObject.GetComponent<GameObjectPrefab>();

            gameObject.Name = name;
            gameObject.ModelName = modelName;
            gameObject.model = gameObject.GetComponent<ModelManager>();
            gameObject.model.SetModel(newModel, gameObject.transform);

            gameObject.model.HighlightSetActive(false);

            return gameObject;
        }
    }
}
