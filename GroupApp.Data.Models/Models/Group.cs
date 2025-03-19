
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GroupApp.Data.Data.Models
{
    using static GroupApp.Constants.Group;
    public class Group
    {
        public Group()
        {
            Members = new List<Member>();
            TextChannels = new List<TextChannel>();
        }
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(nameMaxLength)]
        public string Name{ get; set; }

        [Required]
        [MaxLength(descriptionMaxLenght)]
        public string Description{ get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        
        public string OwnerId { get; set; }

        [ForeignKey(nameof(OwnerId))]
        public virtual IdentityUser Owner{ get; set; }

        public virtual List<Member> Members { get; set; } 
        public virtual List<TextChannel> TextChannels { get; set; }
    }
}
