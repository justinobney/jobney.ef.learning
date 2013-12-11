using Jobney.Core.Domain;

namespace Jobney.EF.Learning.Models
{
    public class Customer : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}