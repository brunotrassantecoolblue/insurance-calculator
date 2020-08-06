using Insurance.Shared.Commands;

namespace Insurance.Domain.Commands
{
    public class CalculateInsurance : ICommand
    {
        public int ProductId { get; set; }
    }
}
