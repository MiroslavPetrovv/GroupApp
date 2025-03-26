using GroupApp.ViewModels.Group;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupApp.Services.Data.Interfaces
{
    public interface IGroupService
    {
        Task AddGroupAsync(AddGroupInputModel model,string userId);
    }
}
