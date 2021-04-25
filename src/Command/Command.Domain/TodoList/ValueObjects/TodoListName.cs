using $safeprojectname$.BaseComponents;
using $safeprojectname$.TodoList.Exceptions;
using System.Collections.Generic;

namespace $safeprojectname$.TodoList.ValueObjects
{
    public class TodoListName : ValueObject
    {
        public string Value { get; }

        public TodoListName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new NameInvalidException($"The todo list name cannot be empty");

            Value = name;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static bool operator ==(TodoListName left, TodoListName right) => EqualOperator(left, right);

        public static bool operator !=(TodoListName left, TodoListName right) => EqualOperator(left, right);

        public override bool Equals(object obj) => base.Equals(obj);

        public override int GetHashCode() => base.GetHashCode();
    }
}
