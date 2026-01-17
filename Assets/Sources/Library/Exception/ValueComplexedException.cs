using System;

public class ValueComplexedException : Exception
{
    public ValueComplexedException() { }
    public ValueComplexedException(string message) : base(message) { }
}
