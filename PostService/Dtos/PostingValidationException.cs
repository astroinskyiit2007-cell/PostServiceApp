using System;
using System.Collections.Generic;

namespace PostService.App
{
    public class PostingValidationException : Exception
    {
        public Dictionary<string, string[]> Errors { get; }

        public PostingValidationException(string message, Dictionary<string, string[]> errors)
            : base(message)
        {
            Errors = errors ?? new Dictionary<string, string[]>();
        }
    }
}