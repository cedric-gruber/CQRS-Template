using $safeprojectname$.BaseComponents;
using $ext_safeprojectname$.Common.Exceptions;
using System;
using System.Collections.Generic;

namespace $safeprojectname$.TodoLists.ValueObjects
{
    public class TodoListId : ValueObject
    {
        public Guid Value { get; }

        public TodoListId(Guid value)
        {
            if (value == default(Guid)) throw new EmptyParameterException("The Todo List Id value must be initialized");
            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static bool operator ==(TodoListId left, TodoListId right) => EqualOperator(left, right);

        public static bool operator !=(TodoListId left, TodoListId right) => NotEqualOperator(left, right);

        public override bool Equals(object obj) => base.Equals(obj);

        public override int GetHashCode() => base.GetHashCode();

    }
}
