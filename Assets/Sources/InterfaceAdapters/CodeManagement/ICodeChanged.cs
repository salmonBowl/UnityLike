
namespace UnityLike.InterfaceAdapters.CodeManagement
{
    public interface ICodeChanged
    {
        void OnChangeCode(string sourceCode, bool isVoidStart);
    }
}