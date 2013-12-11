using Envoc.Mediator;
using Jobney.EF.Learning.Models;

namespace Jobney.EF.Learning.Commands
{
    public class CreateUserCommand : ICommand<Customer>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}