using Vector2 = UnityEngine.Vector2;
using Zenject;

using UnityLike.Entities.CodeEditor;

namespace UnityLike.InterfaceAdapters.TextAreaLayout
{
    public class TextAreaLayoutAdjust
    {
        private readonly LineCountManager lineCountManager;
        private readonly ITextAreaView view;

        [Inject]
        public TextAreaLayoutAdjust(ITextAreaView view)
        {
            lineCountManager = new();
            this.view = view;
        }

        public void Execute(CodeEditorBlock block, string newText)
        {
            LayoutDataBuilder builder = new(lineCountManager);

            int newLineCount = builder.CalculateLineCount(newText);

            lineCountManager.SetLineCount(block, newLineCount);

            SetLayout(builder.BuildData());
        }

        private void SetLayout(TextAreaLayoutData layoutData)
        {
            view.SetContentSize(new Vector2(0, layoutData.ContentHeight));

            view.SetAreaVoidstartLayout(layoutData.AreaVoidstartSize, layoutData.AreaVoidstartPosition);

            view.SetAreaVoidupdateLayout(layoutData.AreaVoidupdateSize, layoutData.AreaVoidupdatePosition);

            view.SetBlockVoidupdatePosition(layoutData.BlockVoidupdatePosition);
        }
    }
}