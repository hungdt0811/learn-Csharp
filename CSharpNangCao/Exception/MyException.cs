using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionLession
{
    internal class NameEmtyException : Exception
    {
        public NameEmtyException() : base("Ten khong duoc de trong")
        {
            
        }
    }
}
