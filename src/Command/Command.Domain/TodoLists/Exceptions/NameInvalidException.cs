using System;

namespace $safeprojectname$.TodoLists.Exceptions
{
    public class NameInvalidException : ApplicationException
    {
        public NameInvalidException(string message) : base(message)
        {

        }
    }
}
