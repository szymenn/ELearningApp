using System;
using ELearningApp.Core.Helpers;
using Microsoft.AspNetCore.Http;

namespace ELearningApp.Core.Exceptions
{
    public class LoginException : Exception
    {
        public int StatusCode { get; }
        public string ReasonPhrase { get; }

        public LoginException()
        {
            StatusCode = StatusCodes.Status400BadRequest;
            ReasonPhrase = Constants.BadRequest;
        }

        public LoginException(string message)
            : base(message)
        {
            StatusCode = StatusCodes.Status400BadRequest;
            ReasonPhrase = Constants.BadRequest;
        }

        public LoginException(string message, Exception inner)
            : base(message, inner)
        {
            StatusCode = StatusCodes.Status400BadRequest;
            ReasonPhrase = Constants.BadRequest;
        }
    }
}