﻿namespace TestMaker.Authentication.Application;

public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message)
    { }
}
