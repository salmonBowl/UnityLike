using Vector2 = UnityEngine.Vector2;
using Zenject;

using UnityLike.Entities.CodeEditor;

namespace UnityLike.InterfaceAdapters.Presenter
{
    public class TextAreaLayoutPresenter : ITextAreaLayoutPresenter
    {
        private readonly ITextAreaView view;

        [Inject]
        public TextAreaLayoutPresenter(ITextAreaView view)
        {
            this.view = view;
        }

        public void PresenterLayout(TextAreaLayoutData layoutData)
        {
            if (view == null)
            {
                UnityEngine.Debug.LogError("TextAreaLayoutPresenter : view‚ªŽw’è‚³‚ê‚Ä‚¢‚Ü‚¹‚ñ");
                return;
            }

            view.SetContentSize(new Vector2(0, layoutData.ContentHeight));

            view.SetAreaVoidstartLayout(layoutData.AreaVoidstartSize, layoutData.AreaVoidstartPosition);

            view.SetAreaVoidupdateLayout(layoutData.AreaVoidupdateSize, layoutData.AreaVoidupdatePosition);

            view.SetBlockVoidupdatePosition(layoutData.BlockVoidupdatePosition);
        }
    }
}