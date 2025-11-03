using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyze15
{
    internal class ExceptionWithPosition : Exception
    {
        public int Position;

        public ExceptionWithPosition() : base() { }
        public ExceptionWithPosition(string message) : base(message) { }
        public ExceptionWithPosition(string message, System.Exception inner) : base(message, inner) { }
        public ExceptionWithPosition(string message, int pos) : base(message)

        {
            Position = pos;
        }
    }
}
