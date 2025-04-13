using GroupApp.Data.Models;
using GroupApp.ViewModels.Group;


namespace GroupApp.Services.Data.Interfaces
{
    public interface IGroupService
    {
        Task AddPersoninGroupAsync(string userId, Guid groupId);
        Task<Group> AddGroupAsync(AddGroupInputModel model,string userId,string image);
        Task<Group> GetGroupByIdAsync(Guid groupId);

        Task<GroupTextChannelViewModel> DisplayGroupAsync(Guid groupId);

        Task<List<GroupDisplayViewModel>> DisplayTop3GroupsByMembersCount();


        Task<List<GroupDisplayViewModel>> DisplayUserGroups(string userId);

        Task<GroupCoursesDisplayViewModel> DisplayClassroomAsync(Guid groupId);
    }
}
