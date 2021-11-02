using System;
using System.Runtime.Serialization;

namespace JA.Candidates.API.Exceptions
{
    public class CandidateNotFoundException : Exception
    {
        public CandidateNotFoundException()
        {
        }

        public CandidateNotFoundException(string message) : base(message)
        {
        }

        public CandidateNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CandidateNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
