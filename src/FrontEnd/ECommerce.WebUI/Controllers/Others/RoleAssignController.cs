using ECommerce.EntityLayer.Concrete;
using ECommerce.WebUI.Dtos.RoleAssignDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.Controllers.Others
{
    [Authorize(Roles = "Admin")]
    public class RoleAssignController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        public RoleAssignController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public IActionResult Index()
        {
            var values = _userManager.Users.ToList();
            return View(values);
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            TempData["userid"] = user.Id;
            var roles = _roleManager.Roles.ToList();
            var userRoles = await _userManager.GetRolesAsync(user);
            List<RoleAssignDto> assignments = new List<RoleAssignDto>();
            foreach (var item in roles)
            {
                RoleAssignDto roleAssignDto = new RoleAssignDto();
                roleAssignDto.RoleId = item.Id;
                roleAssignDto.RoleName = item.Name;
                roleAssignDto.RoleStatus = userRoles.Contains(item.Name);
                assignments.Add(roleAssignDto);
            }
            return View(assignments);
        }
        //------------------------------------------------------------------------------------------------------------------------------
        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignDto> roleAssignDto)
        {
            var userId = (int)TempData["userid"];
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userId);
            foreach (var item in roleAssignDto)
            {
                if (item.RoleStatus)
                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                }

            }
            return RedirectToAction("Index");
        }
        //------------------------------------------------------------------------------------------------------------------------------
    }
}
