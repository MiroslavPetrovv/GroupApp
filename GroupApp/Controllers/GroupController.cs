using GroupApp.Services.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GroupApp.Web.Infra.Extensions;
using GroupApp.Data.Models.Enums;
using GroupApp.ViewModels.Group;
using System.Reflection;
namespace GroupApp.Controllers
{
    public class GroupController : BaseController
    {
        private readonly IGroupService _groupService;
        private readonly IWebHostEnvironment _environment;
        public GroupController(IGroupService _groupService, IWebHostEnvironment environment)
        {
            this._groupService = _groupService;
            _environment = environment;
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
                Category = GroupCategory.Business.ToString(),
                
            };
            return  this.View(model);       
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(AddGroupInputModel model)
        {

            if (!ModelState.IsValid)
            {
                
                return this.View(model);
            }
            string uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");

            // Create uploads directory if it doesn't exist
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            // Generate unique filename
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Banner.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            // Save file
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await model.Banner.CopyToAsync(fileStream);
            }
            TempData["Message"] = "File uploaded successfully";

            // You can save the file path to your database here if needed
            // Example: _context.Images.Add(new Image { Path = uniqueFileName });
            // await _context.SaveChangesAsync();
            Guid userGuid = Guid.Empty;
            bool isValid = this.IsGuidValid(User.GetId(), ref userGuid);
            if (!isValid)
            {
                return this.RedirectToAction(nameof(Index));
            }
            string userId = User.GetId();
            await this._groupService.AddGroupAsync(model, userId);
            return RedirectToAction("Index", "Home");    
        }
    }
}
