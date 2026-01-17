using System;

public class UnitIncorrectException : Exception
{
    public UnitIncorrectException() { }
    public UnitIncorrectException(string message) : base(message) { }
}
