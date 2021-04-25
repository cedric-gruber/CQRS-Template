using System;

namespace $safeprojectname$.TodoList.Exceptions
{
    public class NameInvalidException : ApplicationException
    {
        public NameInvalidException(string message) : base(message)
        {

        }
    }
}
