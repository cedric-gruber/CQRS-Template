using $safeprojectname$.BaseComponents;
using $safeprojectname$.TodoList.Exceptions;
using System.Collections.Generic;

namespace $safeprojectname$.TodoList.ValueObjects
{
    public class TodoName : ValueObject
    {
        public string Value { get; }

        public TodoName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new NameInvalidException($"The todo name cannot be empty");

            Value = name;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static bool operator ==(TodoName left, TodoName right) => EqualOperator(left, right);

        public static bool operator !=(TodoName left, TodoName right) => EqualOperator(left, right);

        public override bool Equals(object obj) => base.Equals(obj);

        public override int GetHashCode() => base.GetHashCode();
    }
}
