using $safeprojectname$.BaseComponents;
using $safeprojectname$.TodoLists.DomainEvents;
using $safeprojectname$.TodoLists.Enum;
using $safeprojectname$.TodoLists.Exceptions;
using $safeprojectname$.TodoLists.ValueObjects;
using $ext_safeprojectname$.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace $safeprojectname$.TodoLists
{
    public sealed class TodoList : AggregateRoot
    {
        public TodoListId Id { get; private set; }
        public TodoListName Name { get; private set; }

        private List<Todo> todos = new List<Todo>();
        public IReadOnlyList<Todo> Todos { get { return todos; } }
        public TodoListStatus Status { get; private set; }


        private TodoList(TodoListId id, TodoListName name)
        {
            Id = id;
            Name = name;
            Status = TodoListStatus.New;
        }

        #region Commands

        public static TodoList Create(TodoListName name)
        {
            var id = new TodoListId(Guid.NewGuid());

            var todoList = new TodoList(id, name);

            todoList.AddEvent(new TodoListCreatedEvent(id, name));

            return todoList;
        }

        public TodoList ChangeName(TodoListName name)
        {
            if (Status == TodoListStatus.Completed)
                throw new TodoListAlreadyCompletedException($"The todo list with id {Id.Value} was already completed, its name cannot be changed.");

            return Apply(AddEvent(new TodoListNameChangedEvent(name)));
        }

        public Todo AddTodo(TodoName todoName)
        {
            if (Status == TodoListStatus.Completed)
                throw new TodoListAlreadyCompletedException($"The todo list with id {Id.Value} was already completed, you cannot add new todos.");

            var todoId = new TodoId(Guid.NewGuid());

            return Apply(AddEvent(new TodoAddedEvent(todoId, todoName)));
        }

        public Todo CompleteTodo(TodoId todoId)
        {
            if (!Exist(todoId))
                throw new NotFoundException($"The todo with id {todoId.Value} doesn't exist in the todo list {Id.Value}");

            return Apply(AddEvent(new TodoCompletedEvent(todoId)));
        }

        public Todo RemoveTodo(TodoId todoId)
        {
            if (!Exist(todoId))
                throw new NotFoundException($"The todo with id {todoId.Value} doesn't exist in the todo list {Id.Value}");

            if (IsCompleted(todoId))
                throw new TodoAlreadyCompletedException($"The todo with id {todoId.Value} was already completed and cannot be removed.");

            return Apply(AddEvent(new TodoRemovedEvent(todoId)));
        }

        public Todo ChangeTodoName(TodoId todoId, TodoName todoName)
        {
            if (!Exist(todoId))
                throw new NotFoundException($"The todo with id {todoId.Value} doesn't exist in the todo list {Id.Value}");

            if (IsCompleted(todoId))
                throw new TodoAlreadyCompletedException($"The todo with id {todoId.Value} was already completed, its name cannot be changed.");

            return Apply(AddEvent(new TodoNameChangedEvent(todoId, todoName)));
        }

        #endregion

        #region Events

        public override void Apply(IDomainEvent domainEvent)
        {
            if (domainEvent is TodoListNameChangedEvent) Apply(domainEvent as TodoListNameChangedEvent);
            if (domainEvent is TodoAddedEvent) Apply(domainEvent as TodoAddedEvent);
            if (domainEvent is TodoCompletedEvent) Apply(domainEvent as TodoCompletedEvent);
            if (domainEvent is TodoRemovedEvent) Apply(domainEvent as TodoRemovedEvent);
            if (domainEvent is TodoNameChangedEvent) Apply(domainEvent as TodoNameChangedEvent);
        }

        public static TodoList CreateFromEvent(TodoListCreatedEvent domainEvent)
        {
            return new TodoList(domainEvent.TodoListId, domainEvent.TodoListName);
        }

        private TodoList Apply(TodoListNameChangedEvent domainEvent)
        {
            Name = domainEvent.TodoListName;

            return this;
        }

        private Todo Apply(TodoAddedEvent domainEvent)
        {
            var todo = Todo.Create(domainEvent.TodoId, domainEvent.TodoName);

            todos.Add(todo);

            UpdateStatus();

            return todo;
        }

        private Todo Apply(TodoCompletedEvent domainEvent)
        {
            var todo = GetTodo(domainEvent.TodoId);

            todo.Complete();

            UpdateStatus();

            return todo;
        }

        private Todo Apply(TodoRemovedEvent domainEvent)
        {
            var todo = GetTodo(domainEvent.TodoId);

            todos.Remove(todo);

            UpdateStatus();

            return todo;
        }

        private Todo Apply(TodoNameChangedEvent domainEvent)
        {
            var todo = GetTodo(domainEvent.TodoId);

            todo.ChangeName(domainEvent.TodoName);

            return todo;
        }

        #endregion

        #region Private Methods

        private bool Exist(TodoId id)
        {
            return todos.Any(m => m.Id == id);
        }
        private bool IsCompleted(TodoId id)
        {
            var todo = GetTodo(id);
            return todo?.Completed ?? false;
        }

        private Todo GetTodo(TodoId id)
        {
            return todos.FirstOrDefault(m => m.Id == id);
        }

        private void UpdateStatus()
        {
            if (Todos.Count == 0) Status = TodoListStatus.New;
            else if (Todos.Count(m => m.Completed) == 0) Status = TodoListStatus.Pending;
            else if (Todos.Count(m => !m.Completed) == 0) Status = TodoListStatus.Completed;
            else Status = TodoListStatus.InProgress;
        }

        #endregion

        #region Method to create an existing TodoList from the Datastore

        public static TodoList CreateFromDataStore(TodoListId id, TodoListName name, IEnumerable<Todo> todos)
        {
            var result = new TodoList(id, name);
            result.todos.AddRange(todos);
            result.UpdateStatus();
            return result;
        }

        #endregion
    }
}
