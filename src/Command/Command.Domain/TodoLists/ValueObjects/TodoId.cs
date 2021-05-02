using $safeprojectname$.BaseComponents;
using $ext_safeprojectname$.Common.Exceptions;
using System;
using System.Collections.Generic;

namespace $safeprojectname$.TodoLists.ValueObjects
{
    public class TodoId : ValueObject
    {
        public Guid Value { get; }

        public TodoId(Guid value)
        {
            if (value == default(Guid)) throw new EmptyParameterException("The Todo Id value must be initialized");
            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static bool operator ==(TodoId left, TodoId right) => EqualOperator(left, right);

        public static bool operator !=(TodoId left, TodoId right) => NotEqualOperator(left, right);

        public override bool Equals(object obj) => base.Equals(obj);

        public override int GetHashCode() => base.GetHashCode();
    }
}
