public class ScopeContext
{
    public ScopeBase ParentScope { get; }
    public int RemainingGenerationCount { get; private set; } // このスコープがあと何回メンバーを作っても良いか

    public ScopeContext(ScopeBase scope, int count)
    {
        ParentScope = scope;
        RemainingGenerationCount = count;
    }

    public void Peeked()
    {
        RemainingGenerationCount--;

        if (RemainingGenerationCount < 0)
            throw new IncorrectMemberLimitException(
                "メンバーの生成回数が指定した数を超えました。using句を利用せずにメンバーを生成した可能性があります。");
    }
}