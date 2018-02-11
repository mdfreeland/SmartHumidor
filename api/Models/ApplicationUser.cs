using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace aspnetCoreReactTemplate.Models
{
    public class ApplicationUser: IdentityUser
    {
        public ICollection<Humidor> Humidors {get; set;}

        public string LastName { get; set; }

        public string FirstName { get; set; }
    }
}
