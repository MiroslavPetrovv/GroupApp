using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupApp.ViewModels.Group
{
    using static GroupApp.Common.EntityValidationConstants.Group;
    using static GroupApp.Common.EntityValidationMessages.Group;
    public class AddGroupInputModel
    {
        public AddGroupInputModel()
        {
            this.CreatedAt = DateTime.UtcNow.ToString(ReleaseDateFormat);
        }
        [Required(ErrorMessage = TitleRequiredMessage)]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage =DescriptionRequiredMessage)]
        [MaxLength(descriptionMaxLenght)]
        [MinLength(DescriptionMinlength)]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "Please select an image")]
        public IFormFile Banner { get; set; } = null!;

        

        [Required(ErrorMessage =ReleaseDateRequiredMessage)]
        public string CreatedAt { get; set; }

        [Required]//Add errormessage
        public string Category { get; set; }
    }
}
