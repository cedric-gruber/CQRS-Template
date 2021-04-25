using System;

namespace $safeprojectname$.TodoList.Exceptions
{
    public class TodoAlreadyCompletedException : ApplicationException
    {
        public TodoAlreadyCompletedException(string message) : base(message)
        {

        }
    }
}
