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

        public async Task<Group> AddGroupAsync(AddGroupInputModel model, string userId, string imageB64)
        {
            bool category = Enum.TryParse(model.Category , out GroupCategory result);
            string format = "MM-dd-yy";

            DateTime createdAt = DateTime.ParseExact(model.CreatedAt.ToString(), format, CultureInfo.InvariantCulture,
                DateTimeStyles.None);
            
            
            Group group = new Group()
            {
                Title = model.Title,
                Description = model.Description,
                Banner = imageB64,
                Category = result,
                OwnerId = userId,
                CreatedAt = createdAt,
                TextChannels = new List<TextChannel>
                {
                    new TextChannel
                    {
                        Name = "General", // Default channel
                        CreatedAt = createdAt,
                        Description = "This channel is for all general things"
                    }


                },
                GroupMembers = new List<GroupMember>
                {
                    new GroupMember
                    {
                        UserId = userId, // Owner as first member
                        Role = 0,
                        JoinedAt = createdAt,
                        
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

        public async Task<List<GroupDisplayViewModel>> DisplayTop3GroupsByMembersCount()
        {
            List<GroupDisplayViewModel> topGroups = await _context.Groups
                .Select(g=> new GroupDisplayViewModel
                {
                    Id = g.Id.ToString(),
                    Title = g.Title,
                    Description = g.Description,
                    Banner = g.Banner,
                    GroupMemberCount = g.GroupMembers.Count()
                })
                .OrderBy(g=>g.GroupMemberCount)
                .ThenBy(g=>g.Title)
                .Take(3)
                .ToListAsync();

            return topGroups;
        }

        public async Task AddPersoninGroupAsync(string userId, Guid groupId)
        {
            
            
            var group = await _context.Groups.Include(g=>g.GroupMembers).FirstOrDefaultAsync(g=>g.Id == groupId);
            var person = await _context.Users.FindAsync(userId);
            var IsPersonIn = group.GroupMembers.FirstOrDefault(x => x.Id.ToString() == userId);
            if (IsPersonIn != null)
            {
                return;
            }
            var membership = new GroupMember
            {
                JoinedAt = DateTime.Now,
                GroupId = groupId,
                UserId = userId,
                Role = GroupRole.Member
            };
            group.GroupMembers.Add(membership);
            person.GroupMemberships.Add(membership);
            _context.SaveChanges();
            
        }
        public async Task<List<GroupDisplayViewModel>> DisplayUserGroups(string userId)
        {
            var userGroups = await _context.GroupMembers
                .Include(gm=>gm.Group)
                .Where(gm=> gm.UserId == userId)
                .Select(gm=> new GroupDisplayViewModel
                {
                    Id = gm.GroupId.ToString(),
                    Description = gm.Group.Description,
                    Title = gm.Group.Title,
                    Banner = gm.Group.Banner,
                    GroupMemberCount = gm.Group.GroupMembers.Count()
                })
                .OrderBy(gm=>gm.GroupMemberCount)
                .ThenBy(gm=>gm.Title)
                .ToListAsync();

            if (userGroups == null)
            {
                
            }

            return userGroups;
        }
        

        
    }
}
