using GroupApp.Services.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GroupApp.Web.Infra.Extensions;
using GroupApp.Data.Models.Enums;
using GroupApp.ViewModels.Group;
namespace GroupApp.Controllers
{
    public class GroupController : BaseController
    {
        private readonly IGroupService _groupService;
        public GroupController(IGroupService _groupService)
        {
            this._groupService = _groupService;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Create()
        {
            if (!User.Identity.IsAuthenticated)
            {
               
                TempData["Message"] = "You must be logged in to start for free. Please register.";

                
                return RedirectToAction("Register", "Account");
            }
            var model = new AddGroupInputModel
            {
                Category = GroupCategory.Business.ToString()  // Default value (this can be changed)
            };
            return this.View(model);       
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(AddGroupInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            Guid userGuid = Guid.Empty;
            bool isValid = this.IsGuidValid(User.GetId(), ref userGuid);
            if (!isValid)
            {
                return this.RedirectToAction(nameof(Index));
            }
            string userId = User.GetId();



            await this._groupService.AddGroupAsync(model, userId);
                return this.View(model);
        }
    }
}
