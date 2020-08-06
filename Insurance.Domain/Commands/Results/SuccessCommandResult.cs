namespace Insurance.Domain.Commands.Results
{
    public class SuccessCommandResult : CommandResult
    {
        public SuccessCommandResult(string message, float data)
        {
            Success = true;
            Message = message;
            Data = data;
        }
    }
}