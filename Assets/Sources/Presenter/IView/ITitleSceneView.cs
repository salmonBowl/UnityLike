using UnityEngine;
using UnityEngine.UI;

namespace UnityLike.Presenter.IView
{
    public interface ITitleSceneView
    {
        RectTransform IconTransform { get; }
        Button CreateWindowOpen { get; }
        Button LoadWindowOpen { get; }
        GameObject CreateWindow { get; }
        GameObject LoadWindow { get; }
    }
}
