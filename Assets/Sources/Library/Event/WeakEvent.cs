using System;
using System.Collections.Generic;

namespace UnityLike
{
    public class WeakEvent
    {
        private readonly List<WeakReference<EventHandler>> handlers;

        public void Subscribe(EventHandler handler)
        {
            lock (handlers) handlers.Add(new WeakReference<EventHandler>(handler));
        }

        public void Unsubscribe(EventHandler item)
        {
            lock (handlers)
            {
                handlers.RemoveAll(reference =>
                {
                    if (reference.TryGetTarget(out var handler))
                    {
                        // 削除したいものをリストから削除
                        return item == handler;
                    }

                    // 参照先が消えていればリストから削除
                    return true;
                });
            }
        }
        public static WeakEvent operator +(WeakEvent weakEvent, EventHandler handler)
        {
            weakEvent.Subscribe(handler);
            return weakEvent;
        }
        public static WeakEvent operator -(WeakEvent weakEvent, EventHandler handler)
        {
            weakEvent.Unsubscribe(handler);
            return weakEvent;
        }
    }
}
