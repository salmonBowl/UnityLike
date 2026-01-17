using System.Collections.Generic;

public static class StaticScopeStack
{
    private static readonly Stack<ScopeContext> stack = new();

    public static void StartRange(ScopeBase currentScope, int memberCount)
    {
        var range = new ScopeContext(currentScope, memberCount);

        stack.Push(range);
    }
    public static void Dispose()
    {
        ScopeContext usedRange = stack.Pop();

        if (usedRange.RemainingGenerationCount != 0)
            throw new IncorrectMemberLimitException(
                "指定した数のメンバーがまだ生成されていません。using句を確認してください。");
    }

    public static ScopeBase FetchParent()
    {
        // 最上位のオブジェクトは親スコープを持ちません
        if (stack.Count == 0)
            return null;

        var currentRange = stack.Peek();

        currentRange.Peeked();

        return currentRange.ParentScope;
    }
}
