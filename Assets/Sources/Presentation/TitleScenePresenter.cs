using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine.EventSystems;
using Quaternion = UnityEngine.Quaternion;

using UnityLike.Domain.IPresenter;
using UnityLike.Presenter.IView;

namespace UnityLike.Presenter
{
    public class TitleScenePresenter : ITitleScenePresenter
    {
        private readonly ITitleSceneView view;
        public TitleScenePresenter(ITitleSceneView view) { this.view = view; }

        public void IconSetAngle(Quaternion angle)
        {
            view.IconTransform.rotation = angle;
        }
        IObservable<Unit> ITitleScenePresenter.CreateWindowOpenObservable => view.CreateWindowOpen.OnClickAsObservable();
        IObservable<Unit> ITitleScenePresenter.LoadWindowOpenObservable => view.LoadWindowOpen.OnClickAsObservable();
        IObservable<PointerEventData> ITitleScenePresenter.CreateWindowOpenPointerEnter => view.CreateWindowOpen.OnPointerEnterAsObservable();
        IObservable<PointerEventData> ITitleScenePresenter.LoadWindowOpenPointerEnter => view.LoadWindowOpen.OnPointerEnterAsObservable();
        IObservable<PointerEventData> ITitleScenePresenter.CreateWindowOpenPointerEnter => view.CreateWindowOpen.OnPointerEnterAsObservable();
        IObservable<PointerEventData> ITitleScenePresenter.LoadWindowOpenPointerEnter => view.LoadWindowOpen.OnPointerEnterAsObservable();
        public void SetActiveCreateWindow(bool value)
        {
            view.CreateWindow.SetActive(value);
        }
        public void SetActiveLoadWindow(bool value)
        {
            view.LoadWindow.SetActive(value);
        }
        public bool IsActiveCreateWindow => view.CreateWindow.activeSelf;
        public bool IsActiveLoadWindow => view.LoadWindow.activeSelf;

        // Presenter‚ª‚·‚éd–‚ÍUseCase‚ªView‚ğG‚ç‚È‚¢ó‘Ô‚ğì‚é‚±‚Æ‚¾‚¯
    }
}
