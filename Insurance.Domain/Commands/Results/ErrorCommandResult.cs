using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Insurance.Domain.Commands.Results
{
    public class ErrorCommandResult : CommandResult
    {
        public ErrorCommandResult(string message, Exception exception)
        {
            Success = false;
            Message = message;
            Data = exception;
        }
    }
}