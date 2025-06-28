using System;

using UnityLike.Entities.CodeEditor;

namespace UnityLike.UseCases.CodeEditor
{
    public class LineCountManager
    {
        public int LineCountVoidstart { get; private set; }
        public int LineCountVoidupdate { get; private set; }

        public event Action OnLineCountChanged;

        public LineCountManager()
        {
            LineCountVoidstart = 1;
            LineCountVoidupdate = 1;
        }

        public void SetLineCount(CodeEditorBlock block, int value)
        {
            switch (block)
            {
                case CodeEditorBlock.VoidStart:
                    LineCountVoidstart = value;
                    break;
                case CodeEditorBlock.VoidUpdate:
                    LineCountVoidupdate = value;
                    break;
                default:
                    UnityEngine.Debug.LogError($"�z�肳��Ă��Ȃ��u���b�N���w�肳��܂��� : CodeEditorLineCountManager.SetLineCount({block}, {value})");
                    break;
            }

            OnLineCountChanged?.Invoke();
        }
    }
}