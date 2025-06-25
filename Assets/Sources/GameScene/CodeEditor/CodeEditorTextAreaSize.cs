using UnityEngine;

public class CodeEditorTextAreaSize
{
    private readonly CodeEditorLineCountManager lineCountManager;
    private readonly CodeEditorSettings settings;

    private readonly RectTransform areaVoidstart;
    private readonly RectTransform areaVoidupdate;

    public CodeEditorTextAreaSize(
        CodeEditorLineCountManager lineCountManager,
        CodeEditorSettings settings,
        RectTransform areaVoidstart,
        RectTransform areaVoidupdate
        )
    {
        this.lineCountManager = lineCountManager;
        this.settings = settings;

        this.areaVoidstart = areaVoidstart;
        this.areaVoidupdate = areaVoidupdate;
    }

    public void Update()
    {
        Debug.Log("textAreaSize.Update()");

        //areaVoidstart.anchoredPosition = new Vector2(0, 1f);
        //areaVoidupdate.anchoredPosition = new Vector2(0, heightVoidstart - 0.2f);

        // InputField�̃T�C�Y�𒲐�
        // �T�C�Y���v�Z����
        float heightVoidstart = Mathf.Max(
            settings.lowerHeightInputField,
            settings.lineHeight * lineCountManager.LineCountVoidstart
            );
        // ���f
        areaVoidstart.sizeDelta = new Vector2(11f, heightVoidstart);
        areaVoidstart.anchoredPosition = new Vector2(0, heightVoidstart * -0.5f + 0.5f);

        //
    }
}
