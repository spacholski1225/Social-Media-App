using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Responses.Profile
{
    public class ProfileResponse
    {
        public string Id { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
