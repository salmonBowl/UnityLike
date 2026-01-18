using System;
using System.Collections.Generic;

/// <summary>
/// 何かを管理するリストです。管理しているアイテムに一括でメソッドを適用する機能を持ちます。
/// </summary>
/// <typeparam name="T">管理するアイテムの型</typeparam>
public class ManagedList<T>
{
    private readonly List<T> itemList = new();

    private readonly PendingAddList pendingAdds = new();
    private readonly PendingRemoveList pendingRemoves = new();

    /// <summary>
    /// リストに追加します
    /// </summary>
    public void Add(T item)
    {
        // 追加要請を保留
        pendingAdds.Hold(item);
    }

    /// <summary>
    /// リストから削除します
    /// </summary>
    public void Remove(T item)
    {
        // 削除要請を保留
        pendingRemoves.Hold(item);
    }

    /// <summary>
    /// すべての要素に対して指定されたアクションを実行した後、保留中の追加・削除を反映します
    /// </summary>
    public void ProcessAll(Action<T> processAction)
    {
        // 関数を実行
        foreach (var item in itemList)
        {
            processAction(item);
        }

        // 保留中の変更要請を解決します
        pendingAdds.ApplyTo(itemList);
        pendingRemoves.ApplyTo(itemList);
    }

    private class PendingAddList
    {
        private readonly List<T> pendingAdds = new();

        public void Hold(T item)
        {
            pendingAdds.Add(item);
        }

        public void ApplyTo(List<T> targetList)
        {
            if (pendingAdds.Count > 0)
            {
                targetList.AddRange(pendingAdds);
                pendingAdds.Clear();
            }
        }
    }

    private class PendingRemoveList
    {
        private readonly List<T> pendingRemoves = new();

        public void Hold(T item)
        {
            pendingRemoves.Add(item);
        }

        public void ApplyTo(List<T> targetList)
        {
            foreach (var item in pendingRemoves)
            {
                if (!targetList.Remove(item))
                {
                    throw new KeyNotFoundException($"{item} はリストに存在しません。");
                }
            }
            pendingRemoves.Clear();
        }
    }
}