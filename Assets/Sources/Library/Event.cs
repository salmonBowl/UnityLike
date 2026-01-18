using System;

public class Event<TArg>
{
    private event EventHandler<TArg> E;

    public IDisposable Subscribe(EventHandler<TArg> handler)
    {
        E += handler;
        return new UnSubscriber(() => E -= handler);
    }

    public void Raise(object sender, TArg arg) => E?.Invoke(sender, arg);

    private class UnSubscriber : IDisposable
    {
        private readonly Action unSubscribe;
        public UnSubscriber(Action unSubscribe)
        {
            this.unSubscribe = unSubscribe;
        }

        public void Dispose()
        {
            unSubscribe.Invoke();
        }
    }
}
public class Event : Event<BlankEventHandler>
{

}