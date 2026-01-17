using System;

public class NullReferanceException : Exception
{
    public NullReferanceException() { }
    public NullReferanceException(string message) : base(message) { }
}
