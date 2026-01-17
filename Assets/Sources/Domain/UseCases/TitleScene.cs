using UnityLike.Domain.IPresenter;

namespace UnityLike.Domain.UseCase
{
    public class TitleScene
    {
        private readonly ITitleScenePresenter presenter;
        private readonly IconRotationManager iconRotation = new();
        private readonly ButtonSelectManager buttonSelect;

        public TitleScene(ITitleScenePresenter presenter)
        {
            this.presenter = presenter;
        }

        public void Begin()
        {
            presenter.CreateWindowOpenObservable.Subscribe(_ => {
                presenter.SetActiveCreateWindow(true);
                SetIconRotation();
            });
            presenter.LoadWindowOpenObservable.Subscribe(_ => {
                presenter.SetActiveLoadWindow(true);
                SetIconRotation();
            });
        }
        public void Update()
        {
            presenter.IconSetAngle(iconRotation.GetAngle());
        }

        private void SetIconRotation()
        {
            // マウスがボタンに触れているとき角度を変更
            if (buttonSelect.IsSelectedCreateWindow)
                iconRotation.SetAngleDestination(-120);
            else if (buttonSelect.IsSelectedLoadWindow)
                iconRotation.SetAngleDestination(120);

            // ウィンドウが開いているならそちらのほうが強い
            if (presenter.IsActiveCreateWindow)
                iconRotation.SetAngleDestination(-120);
            else if (presenter.IsActiveLoadWindow)
                iconRotation.SetAngleDestination(120);
        }

        // iconRotateをどうするか?

        // UseCaseには詳細な実装をさせない。それをするのはDomainの仕事
    }
}
