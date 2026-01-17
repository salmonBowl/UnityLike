using System;

public class MissingComponentException : Exception
{
    public MissingComponentException() { }
    public MissingComponentException(string message) : base(message) { }
}
