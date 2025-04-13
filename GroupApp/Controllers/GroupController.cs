using GroupApp.Data.Models.Enums;
using GroupApp.Services.Data.Interfaces;
using GroupApp.ViewModels.Group;
using GroupApp.Web.Infra.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
namespace GroupApp.Controllers
{
    public class GroupController : BaseController
    {
        private readonly IGroupService _groupService;
        
        public GroupController(IGroupService _groupService)
        {
            this._groupService = _groupService;
            
        }

        public async Task<IActionResult> Index()
        {
            var topGroups = await _groupService.DisplayTop3GroupsByMembersCount();
            ViewData["Title"] = "Home Page";
            ViewData["Message"] = "Welocome to the Community";
            return View(topGroups);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Create()
        {
            if (!User.Identity.IsAuthenticated)
            {

                TempData["Message"] = "You must be logged in to start for free. Please register.";


                return View("Index");
            }
            var model = new AddGroupInputModel
            {
                Category = GroupCategory.Business.ToString(),

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
           string imageBase64 = string.Empty;
            using (var stream = model.Banner.OpenReadStream())
            {
                using (var memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);
                    imageBase64 = Convert.ToBase64String(memoryStream.ToArray());
                    
                }
            }
                
            

            TempData["Message"] = "File uploaded successfully";
            string fileform =  model.Banner.ContentType;
            Guid userGuid = Guid.Empty;
            bool isValid = this.IsGuidValid(User.GetId(), ref userGuid);
            if (!isValid)
            {
                return View("Index");
            }
            
            string userId = User.GetId();
            var group =await this._groupService.AddGroupAsync(model, userId, imageBase64);
            return RedirectToAction("Display", new {groupId = group.Id});
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Display(Guid groupId)
        {
            
            var groupModel = await _groupService.DisplayGroupAsync(groupId);
            if (groupModel == null)
            {
                return NotFound();
            }

            return View(groupModel);

        }

        [HttpGet]
        [Authorize]

        public async Task<IActionResult> JoinGroup(Guid groupId)
        {
            if (!User.Identity.IsAuthenticated)
            {

                TempData["Message"] = "You must be logged in to start for free. Please register.";


                return RedirectToAction("Register", "Account");
            }
            string userId = User.GetId();
            await _groupService.AddPersoninGroupAsync(userId, groupId);
            return RedirectToAction("Display", new { groupId = groupId });
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> DisplayAllUserGroups()
        {
            if (!User.Identity.IsAuthenticated)
            {

                TempData["Message"] = "You must be logged in to start for free. Please register.";


                return View("Index");
            }
            string userId = User.GetId();
            var userGroups= await _groupService.DisplayUserGroups(userId);
            return View(userGroups);

        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> DisplayClassRoom(Guid groupId)
        {
            var groupClasroom = await _groupService.DisplayClassroomAsync(groupId);

            return View(groupClasroom);
        }

       
    }
}
