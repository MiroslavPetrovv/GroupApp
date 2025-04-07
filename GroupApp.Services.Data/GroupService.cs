using GroupApp.Data;
using GroupApp.Data.Models;
using GroupApp.Data.Models.Enums;
using GroupApp.Services.Data.Interfaces;
using GroupApp.ViewModels.Group;
using Microsoft.EntityFrameworkCore;
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


        public async Task<GroupViewModel> DisplayGroupAsync(Guid groupId)
        {
            var group = await _context.Groups
              .Include(g => g.Owner)
              .Include(g => g.TextChannels)
              .ThenInclude(tc => tc.Messages.OrderByDescending(m => m.CreatedAt).Take(50))
              .Include(g => g.GroupMembers)
              .ThenInclude(m => m.User)
              .FirstOrDefaultAsync(g => g.Id == groupId);

            if (group == null)
            {
                return null;

            }

            return new GroupViewModel
            {
                Id = group.Id,
                Title = group.Title,
                OwnerId = group.OwnerId,
                TextChannels = group.TextChannels.Select(tc => new GroupViewModel.TextChannelDto
                {
                    Id = tc.Id,
                    Name = tc.Name,
                   

                }).ToList(),
                GroupMembers = group.GroupMembers.Select(m => new GroupViewModel.MemberDto
                {
                    UserId = m.UserId,
                    UserName = m.User.UserName
                }).ToList()
            };

        }
        
    }
}
