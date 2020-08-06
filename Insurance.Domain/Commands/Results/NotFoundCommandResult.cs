namespace Insurance.Domain.Commands.Results
{
    public class NotFoundCommandResult : CommandResult
    {
        public NotFoundCommandResult(string message)
        {
            Success = true;
            Message = message;
            Data = null;
        }
    }
}