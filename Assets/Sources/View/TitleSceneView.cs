using UnityEngine;
using UnityEngine.UI;
using UnityLike.Presenter.IView;

namespace UnityLike.View
{
    public class TitleSceneView : MonoBehaviour, ITitleSceneView
    {
        [SerializeField] private RectTransform iconTransform;
        [SerializeField] private Button createWindowOpen;
        [SerializeField] private Button loadWindowOpen;
        [SerializeField] private GameObject createWindow;
        [SerializeField] private GameObject loadWindow;
        [SerializeField] private InputField newSceneNameInput;
        [SerializeField] private Button createNewExecute;

        public RectTransform IconTransform => iconTransform;
        public Button CreateWindowOpen => createWindowOpen;
        public Button LoadWindowOpen => loadWindowOpen;
        public GameObject CreateWindow => createWindow;
        public GameObject LoadWindow => loadWindow;
    }
}
