using GroupApp.Data;
using GroupApp.Data.Models;
using GroupApp.Data.Models.Enums;
using GroupApp.Data.Repository.Interfaces;
using GroupApp.Services.Data.Interfaces;
using GroupApp.ViewModels.Group;
using GroupApp.ViewModels.Models;


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
            Group group = new Group()
            {
                Title = model.Title,
                Description = model.Description,
                Banner = model.Banner,
                Category = category,
                OwnerId = userId
            };

            _context.Groups.Add(group);
            await _context.SaveChangesAsync();
        }
    }
}
