using GroupApp.Data;
using GroupApp.Data.Models;
using GroupApp.Data.Models.Enums;
using GroupApp.Data.Repository.Interfaces;
using GroupApp.Services.Data.Interfaces;
using GroupApp.ViewModels.Group;
using GroupApp.ViewModels.Models;
using System.Diagnostics.Contracts;
using System.Globalization;


namespace GroupApp.Services.Data
{
    public class GroupService :BaseService, IGroupService
    {
        private readonly ApplicationDbContext _context;

        public GroupService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddGroupAsync(AddGroupInputModel model, string userId)
        {
            GroupCategory category = (GroupCategory)Enum.Parse(typeof(GroupCategory), model.Category);
            string format = "MM-dd-yy";

            var createdAt = DateTime.ParseExact(model.CreatedAt.ToString(), format, CultureInfo.InvariantCulture,
                DateTimeStyles.None);
            
            Group group = new Group()
            {
                Title = model.Title,
                Description = model.Description,
                Banner = model.Banner.ToString(),
                Category = category,
                OwnerId = userId,
                CreatedAt = createdAt,
            };

            _context.Groups.Add(group);
            await _context.SaveChangesAsync();
        }
    }
}
