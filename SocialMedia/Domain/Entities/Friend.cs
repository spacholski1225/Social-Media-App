using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Friend
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string FriendId { get; set; }

        [ForeignKey(nameof(UserId))]
        public IdentityUser IdentityUser { get; set; }
    }
}
