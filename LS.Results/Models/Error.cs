﻿using System.Net;

namespace LS.Results.Models;

public class Error(string code, string message)
{
    public string Code { get; } = code;
    public string Message { get; } = message;
}