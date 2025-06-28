using Vector2 = UnityEngine.Vector2;
using Mathf = UnityEngine.Mathf;
using Zenject;

using UnityLike.Entities.CodeEditor;
using UnityLike.InterfaceAdapters;

namespace UnityLike.UseCases.CodeEditor
{
    public class UpdateTextAreaUseCase
    {

        private readonly LineCountManager lineCountManager;
        private readonly CodeEditorSettings settings;
        private readonly ITextAreaLayoutPresenter layoutPresenter;

        [Inject]
        public UpdateTextAreaUseCase(
            LineCountManager lineCountManager,
            CodeEditorSettings settings,
            ITextAreaLayoutPresenter layoutPresenter
            )
        {
            this.lineCountManager = lineCountManager;
            this.settings = settings;
            this.layoutPresenter = layoutPresenter;
        }

        public void Execute()
        {
            if (settings == null)
            {
                UnityEngine.Debug.LogError("UpdateTextAreaUseCase : settingsが設定されていません");
            }

            // InputFieldのサイズを計算

            float heightVoidstart = Mathf.Max(
                settings.LowerHeightInputField,
                settings.LineHeight * lineCountManager.LineCountVoidstart + settings.AreaHeightOffset
                );
            float heightVoidupdate = Mathf.Max(
                settings.LowerHeightInputField,
                settings.LineHeight * lineCountManager.LineCountVoidupdate + settings.AreaHeightOffset
                );

            // レイアウトデータを生成
            float contentHeight = heightVoidstart + heightVoidupdate + 4.3f;
            Vector2 areaVoidstartSize = new(11f, heightVoidstart);
            Vector2 areaVoidupdateSize = new(11f, heightVoidupdate);
            Vector2 areaVoidstartPosition = new(0, heightVoidstart * -0.5f + 0.5f);
            Vector2 areaVoidupdatePosition = new(0, heightVoidupdate * -0.5f + 0.5f);
            Vector2 blockVoidupdatePosition = new(0, -heightVoidstart - 4.0f);

            TextAreaLayoutData layoutData = new(
                contentHeight,
                heightVoidstart,
                heightVoidupdate,
                areaVoidstartSize,
                areaVoidupdateSize,
                areaVoidstartPosition,
                areaVoidupdatePosition,
                blockVoidupdatePosition
            );

            // レイアウトデータの出力
            layoutPresenter.PresenterLayout(layoutData);
        }
    }
}
