using GroupApp.Data;
using GroupApp.Data.Models;
using GroupApp.Data.Models.Enums;
using GroupApp.Services.Data.Interfaces;
using GroupApp.ViewModels.Group;
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

        public async Task<Group> AddGroupAsync(AddGroupInputModel model, string userId)
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
                TextChannels = new List<TextChannel>
                {
                    new TextChannel
                    {
                        Name = "General", // Default channel
                        CreatedAt = createdAt,
                        Description = "This channel is for all general things"
                    },
                    new TextChannel
                    {
                        Name="Annoucments",
                        CreatedAt = createdAt,
                        Description = "This channel is for announcing the events and important things"
                    },
                    new TextChannel
                    {
                        Name = "Introductions",
                        CreatedAt = createdAt,
                        Description = "This is a channel for introducing yourself".Trim()
                    }


                },
                GroupMembers = new List<GroupMember>
                {
                    new GroupMember
                    {
                        UserId = userId, // Owner as first member
                        Role = 0,
                        JoinedAt = createdAt,
                        NickName = "Owner"
                    }
                }
            };

            _context.Groups.Add(group);
            await _context.SaveChangesAsync();
            return group;
        }
        public async Task<Group> GetGroupByIdAsync(Guid groupId)
        {
            return await _context.Groups.FindAsync(groupId);
        }


        //public async Task<Group> DisplayGroup(string groupId)
        //{
        //    return await _context.Groups
        //        .Where(g=>g.Id.ToString() == groupId)
        //        .Select(groupId => new Group)

        //}
        //public async Task<Guid> GetGroupIdAsync(AddGroupInputModel model, string userId)
        //{
        //    return await _context.Groups
        //        .Where(g=>)
        //}
    }
}
