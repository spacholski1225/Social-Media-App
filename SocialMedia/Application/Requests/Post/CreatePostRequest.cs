using System;

namespace Application.Requests.Post
{
    public class CreatePostRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
