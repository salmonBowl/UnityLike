using UnityEngine;
using TMPro;

namespace UnityLike.FrameworkAndDrivers.CodeEditor
{
    public interface IUIPosCalculator
    {
        Vector2Int GetTextPosOnMouse(TMP_Text text);
    }
}