using System;
using System.Collections.Generic;
using System.Text;

namespace IndianCensusAnalyzerPrgm.DTO
{

    public class StateCensusException : Exception
    {
        public enum ExceptionType
        {
            FILE_INCORRECT, TYPE_INCORRECT, Delemeter_INCORRECT, HEADER_INCORRECT
        }
        public ExceptionType type;
        public StateCensusException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}