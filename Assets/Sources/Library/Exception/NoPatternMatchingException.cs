using System;

public class NoPatternMatchingException : Exception
{
    public NoPatternMatchingException() { }
    public NoPatternMatchingException(string message) : base(message) { }
}