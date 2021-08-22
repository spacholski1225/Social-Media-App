using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Post
{
    public class CommentPostRequest
    {
        public Guid PostId { get; set; }
        public string Author { get; set; }
        public string Comment { get; set; }
    }
}
