public class ScopeBase
{
    /// <summary>
    /// <see cref="ScopeBase">型に合った親スコープを探します。プログラムの中で使用してください。
    /// </summary>
    public TScope IfParentExist<TScope>() where TScope : ScopeBase
    {
        return LookUpParentScope<TScope>();
    }

    /// <summary>
    /// プログラム内でこのメソッドを利用することで、スコープがメンバーに保持しているイベントを駆動します
    /// </summary>
    public virtual void Occur(string eventName)
    {
        // 設計の健全性のため、スコープを経由したイベント発火では引数のやり取りを行わないようにしています。
        // もし引数を取る必要が出てくる場合、親子関係を見直すことを検討してください。

        // このメソッドではswitch文でパターンマッチングを行います。
    }

    // --- 以下は内部処理 ---

    private ScopeBase parentScope;

    public void ConnectParent(ScopeBase parent)
    {
        if (parentScope != null)
        {
            throw new ValueAlreadySetException(
                "親スコープは既に設定されています。単一のインスタンスを複数の場所からメンバーにしないでください。");
        }

        parentScope = parent;
    }

    private TScope LookUpParentScope<TScope>() where TScope : ScopeBase
    {
        ScopeBase runner = this;

        while (runner != null)
        {
            runner = runner.parentScope;

            // 条件に一致する親が見つかれば返します
            if (runner is TScope target)
                return target;
        }

        // 見つからなかった場合、nullを返します
        return null;
    }
}
