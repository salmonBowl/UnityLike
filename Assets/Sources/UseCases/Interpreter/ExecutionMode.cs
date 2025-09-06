
namespace UnityLike.UseCases.Interpreter
{
    public enum ExecutionMode
    {
        FullExecution, // 完全な実行 : プレイ実行時
        InitalExecution, // 初期化コードは実行 : voidStartコード変更時, 実行停止時
        SemanticAnalysisOnly, // 意味解析のみ : voidUpdateコード変更時
    }
}
