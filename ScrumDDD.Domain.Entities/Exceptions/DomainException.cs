using System;
using System.Collections.Generic;
using System.Text;

namespace ScrumDDD.Domain.Entities.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message)
        {

        }
    }
}
