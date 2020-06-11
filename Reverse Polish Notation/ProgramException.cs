using System;
using System.Collections.Generic;
using System.Text;

namespace Reverse_Polish_Notation
{
    class ProgramException : Exception
    {
        public ProgramException()
        {
        }
        public ProgramException(string message)
            : base(message)
        {

        }
        public ProgramException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
