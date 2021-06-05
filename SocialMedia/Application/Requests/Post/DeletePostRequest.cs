using System;
using System.Collections.Generic;

namespace Application.Requests.Post
{
    public class DeletePostRequest
    {
        public Guid Id { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
