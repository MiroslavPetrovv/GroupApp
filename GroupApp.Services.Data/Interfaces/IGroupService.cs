using GroupApp.Data.Models;
using GroupApp.ViewModels.Group;


namespace GroupApp.Services.Data.Interfaces
{
    public interface IGroupService
    {
        Task<Group> AddGroupAsync(AddGroupInputModel model,string userId);
        Task<Group> GetGroupByIdAsync(Guid groupId);
    }
}
