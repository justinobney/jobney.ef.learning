using System;
using Jobney.Core.Domain;

namespace Jobney.EF.Learning.Models
{
    public class ApiToken:Entity
    {
        public string Key { get; set; }
        public int UserId { get; set; }
        public DateTime Created { get; set; }
        public DateTime ValidUntil { get; set; }
        public DateTime ExplicitExpirationData { get; set; }
    }
}