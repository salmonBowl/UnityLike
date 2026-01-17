using System;
using TMPro;

namespace UnityLike.FrameworkAndDrivers.CodeEditor
{
    [Serializable]
    public class NameFieldUI
    {
        public TMP_InputField inputField;

        public void SetName(string text)
        {
            inputField.SetTextWithoutNotify(text);
        }
    }
}
