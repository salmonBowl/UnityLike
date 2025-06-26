using UnityEngine;

public readonly struct TextAreaLayoutData
{
    public readonly float ContentHeight;

    public readonly float HeightVoidstart;
    public readonly float HeightVoidupdate;

    public readonly Vector2 AreaVoidstartSize;
    public readonly Vector2 AreaVoidupdateSize;

    public readonly Vector2 AreaVoidstartPosition;
    public readonly Vector2 AreaVoidupdatePosition;

    public readonly Vector2 BlockVoidupdatePosition;

    public TextAreaLayoutData(
        float contentHeight,
        float heightvoidStart,
        float heightVoidupdate,
        Vector2 areaVoidstartSize,
        Vector2 areaVoidupdateSize,
        Vector2 areaVoidstartPosition,
        Vector2 areaVoidupdatePosition,
        Vector2 blockVoidupdatePosition
        )
    {
        ContentHeight = contentHeight;
        HeightVoidstart = heightvoidStart;
        HeightVoidupdate = heightVoidupdate;
        AreaVoidstartSize = areaVoidstartSize;
        AreaVoidupdateSize = areaVoidupdateSize;
        AreaVoidstartPosition = areaVoidstartPosition;
        AreaVoidupdatePosition = areaVoidupdatePosition;
        BlockVoidupdatePosition = blockVoidupdatePosition;
    }
}