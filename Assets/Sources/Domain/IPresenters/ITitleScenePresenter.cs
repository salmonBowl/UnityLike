using System;
using UniRx;
using UnityEngine.EventSystems;
using Quaternion = UnityEngine.Quaternion;

namespace UnityLike.Domain.IPresenter
{
    public interface ITitleScenePresenter
    {
        void IconSetAngle(Quaternion angle);
        IObservable<Unit> CreateWindowOpenObservable { get; }
        IObservable<Unit> LoadWindowOpenObservable { get; }
        IObservable<PointerEventData> CreateWindowOpenPointerEnter { get; }
        IObservable<PointerEventData> LoadWindowOpenPointerEnter { get; }
        IObservable<PointerEventData> CreateWindowOpenPointerExit { get; }
        IObservable<PointerEventData> LoadWindowOpenPointerExit { get; }
        void SetActiveCreateWindow(bool value);
        void SetActiveLoadWindow(bool value);
        bool IsActiveCreateWindow { get; }
        bool IsActiveLoadWindow { get; }
    }
}
