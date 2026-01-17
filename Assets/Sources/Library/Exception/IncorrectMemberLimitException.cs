using System;

public class IncorrectMemberLimitException : Exception
{
    public IncorrectMemberLimitException() { }
    public IncorrectMemberLimitException(string message) : base(message) { }
}
