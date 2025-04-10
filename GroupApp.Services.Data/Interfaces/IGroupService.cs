using GroupApp.Data.Models;
using GroupApp.ViewModels.Group;


namespace GroupApp.Services.Data.Interfaces
{
    public interface IGroupService
    {
        Task<Group> AddGroupAsync(AddGroupInputModel model,string userId,string image);
        Task<Group> GetGroupByIdAsync(Guid groupId);

        Task<GroupViewModel> DisplayGroupAsync(Guid groupId);

        Task<List<GroupDisplayViewModel>> DisplayTop3GroupsByMembersCount();

        public Task AddPersoninGroupAsync(string userId, Guid groupId);

        public Task<List<GroupDisplayViewModel>> DisplayUserGroups(string userId);
    }
}
