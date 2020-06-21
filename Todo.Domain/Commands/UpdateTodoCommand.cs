using Flunt.Notifications;
using System;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands.Contract
{
    public class UpdateTodoCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string User { get; set; }

        public UpdateTodoCommand() { }

        public UpdateTodoCommand(string title, string user, DateTime date)
        {
            Title = title;
            User = user;
            Date = date;
        }

        public void Validate()
        {
            AddNotifications(
            new Flunt.Validations.Contract()
                .Requires()
                .HasMinLen(Title, 3, "Title", "Por favor, descreva melhor esta tarefa!")
                .HasMinLen(User, 6, "User", "Usuário inválido!")
        );
        }
    }
}