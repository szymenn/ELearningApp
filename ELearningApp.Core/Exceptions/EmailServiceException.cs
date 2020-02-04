using System;
using ELearningApp.Core.Helpers;
using Microsoft.AspNetCore.Http;

namespace ELearningApp.Core.Exceptions
{
    public class EmailServiceException : Exception
    {
        public int StatusCode { get; }
        public string ReasonPhrase { get; }

        public EmailServiceException()
        {
            StatusCode = StatusCodes.Status400BadRequest;
            ReasonPhrase = Constants.BadRequest;
        }

        public EmailServiceException(string message)
            : base(message)
        {
            StatusCode = StatusCodes.Status400BadRequest;
            ReasonPhrase = Constants.BadRequest;
        }

        public EmailServiceException(string message, Exception inner)
            : base(message, inner)
        {
            StatusCode = StatusCodes.Status400BadRequest;
            ReasonPhrase = Constants.BadRequest;
        }
    }
}