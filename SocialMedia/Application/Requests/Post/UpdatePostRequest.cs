using System;

namespace Application.Requests.Post
{
    public class UpdatePostRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
