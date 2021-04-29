using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$.TodoLists.Exceptions
{
    public class TodoListAlreadyCompletedException : ApplicationException
    {
        public TodoListAlreadyCompletedException(string message) : base(message)
        {

        }
    }
}
