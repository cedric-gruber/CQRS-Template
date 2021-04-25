using System;

namespace $safeprojectname$.Exceptions
{
    public class EmptyParameterException : ApplicationException
    {
        public EmptyParameterException(string message) : base(message)
        {
        }
    }
}
