using $safeprojectname$.TodoList.ValueObjects;

namespace $safeprojectname$.TodoList
{
    public sealed class Todo
    {
        public TodoId Id { get; private set; }
        public TodoName Name { get; private set; }
        public bool Completed { get; private set; }


        private Todo(TodoId id, TodoName name)
        {
            Id = id;
            Name = name;
            Completed = false;
        }

        internal static Todo Create(TodoId id, TodoName name)
        {
            return new Todo(id, name);
        }

        internal void ChangeName(TodoName name)
        {
            Name = name;
        }

        internal void Complete()
        {
            Completed = true;
        }

        #region Method to create existing Todo from the Datastore

        public static Todo CreateFromDataStore(TodoId id, TodoName name)
        {
            var result = new Todo(id, name);
            return result;
        }

        #endregion

    }
}
