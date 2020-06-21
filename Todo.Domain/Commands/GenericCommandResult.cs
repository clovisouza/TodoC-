using Todo.Domain.Commands.Contracts;
namespace Todo.Domain.Commands
{
    public class GenericCommandResult : ICommandResult
    {

        public GenericCommandResult()
        {

        }
      
        public GenericCommandResult(bool sucess, string message, object data)
        {
            this.Sucess = sucess;
            this.Message = message;
            this.Data = data;

        }
        public bool Sucess { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }


    }
}