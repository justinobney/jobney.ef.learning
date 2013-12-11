using System.Linq;
using Envoc.Mediator;
using Jobney.Core.Domain.Interfaces;
using Jobney.EF.Learning.Models;

namespace Jobney.EF.Learning.Commands
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, Customer>
    {
        private readonly IUnitOfWork uow;

        public CreateUserCommandHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public Customer Handle(CreateUserCommand command)
        {
            var service = uow.GetRepository<Customer>();
            var vm = service.Query().First(x => x.Email.Contains("justin"));

            return vm;
        }
    }
}