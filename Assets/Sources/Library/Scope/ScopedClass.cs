using System;

public abstract class ScopedClass
{
    protected readonly ScopeBase myScope;

    protected abstract Type GetScopeType();

    public ScopedClass()
    {
        // 自身のスコープを生成します
        myScope = (ScopeBase)Activator.CreateInstance(GetScopeType());

        // 親クラスのスコープを取得し、スコープの親子関係を設定します
        var parentScope = StaticScopeStack.FetchParent();

        myScope.ConnectParent(parentScope);
    }

    /// <summary>
    /// using句の中で使用します。メンバーの親が自分であることを示します。
    /// </summary>
    public IDisposable MemberInitialization(int memberCount)
    {
        StaticScopeStack.StartRange(myScope, memberCount);

        return new Unlinker();
    }
    private class Unlinker : IDisposable
    {
        public void Dispose() => StaticScopeStack.Dispose();
    }

    /// <summary>
    /// テストコードで使用します
    /// </summary>
    protected TScope MyScopeAs<TScope>() where TScope : ScopeBase
    {
        return myScope as TScope;
    }
}
