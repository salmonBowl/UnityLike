using System;

using UnityLike.Entities.CodeEditor;

namespace UnityLike.InterfaceAdapters.TextAreaLayout
{
    public class LineCountManager
    {
        public int LineCountVoidstart { get; private set; }
        public int LineCountVoidupdate { get; private set; }

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
                    UnityEngine.Debug.LogError($"想定されていないブロックが指定されました : CodeEditorLineCountManager.SetLineCount({block}, {value})");
                    break;
            }
        }
    }
}