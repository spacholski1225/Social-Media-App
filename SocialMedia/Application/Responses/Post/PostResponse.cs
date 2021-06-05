using System;
using System.Collections.Generic;

namespace Application.Responses
{
    public class PostResponse
    {
        public Guid Id { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
