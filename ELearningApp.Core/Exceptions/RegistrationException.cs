using System;
using ELearningApp.Core.Helpers;
using Microsoft.AspNetCore.Http;

namespace ELearningApp.Core.Exceptions
{
    public class RegistrationException : Exception
    {
        public int StatusCode { get; }
        public string ReasonPhrase { get; }

        public RegistrationException()
        {
            StatusCode = StatusCodes.Status400BadRequest;
            ReasonPhrase = Constants.BadRequest;
        }

        public RegistrationException(string message)
            : base(message)
        {
            StatusCode = StatusCodes.Status400BadRequest;
            ReasonPhrase = Constants.BadRequest;
        }

        public RegistrationException(string message, Exception inner)
            : base(message, inner)
        {
            StatusCode = StatusCodes.Status400BadRequest;
            ReasonPhrase = Constants.BadRequest;
        }
    }
}