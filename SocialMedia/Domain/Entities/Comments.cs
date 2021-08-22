using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Comments
    {
        [Key]
        public Guid Id { get; set; }
        public string Author { get; set; }
        [ForeignKey(nameof(Author))]
        public IdentityUser User { get; set; }
        public string Comment { get; set; }

        public Guid PostId { get; set; }
        [ForeignKey(nameof(PostId))]
        public Post Post { get; set; }
        
    }
}
