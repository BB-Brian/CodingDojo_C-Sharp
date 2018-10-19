using System;
using ProfessionalNetwork.Models;

namespace ProfessionalNetwork
{
    public class BaseEntity
    {
        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;

    }
}