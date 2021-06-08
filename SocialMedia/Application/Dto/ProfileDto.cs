using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProfileDto //have to extent identity user class with some properties like first last name, city, image etc.
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    
    }
}
