using System;
using System.Collections.Generic;
using System.Text;

namespace Maxject.Core.DependencyInjection.Exceptions
{
    public class DependencyNotImplementedException : Exception
    {
        public DependencyNotImplementedException(string message) : base(message)
        {

        }
    }
}
