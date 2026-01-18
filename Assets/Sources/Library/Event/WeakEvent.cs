using System;
using System.Collections.Generic;

namespace UnityLike
{
    public class WeakEvent
    {
        private readonly List<WeakReference<EventHandler>> handlers;

        public void Add(EventHandler handler)
        {
            lock (handlers) handlers.Add(new WeakReference<EventHandler>(handler));
        }

        public void Remove(EventHandler handler)
        {
            lock (handlers)
            {
                handlers.RemoveAll(reference =>
                {
                    if (reference.TryGetTarget(out var h))
                    {
                        // Removeの一致するものをリストから削除
                        return h == handler;
                    }

                    // 参照先のインスタンスが消えていればリストから削除
                    return true;
                });
            }
        }
    }
}
