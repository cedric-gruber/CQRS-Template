using System;

namespace $safeprojectname$.TodoLists.Exceptions
{
    public class TodoAlreadyCompletedException : ApplicationException
    {
        public TodoAlreadyCompletedException(string message) : base(message)
        {

        }
    }
}
