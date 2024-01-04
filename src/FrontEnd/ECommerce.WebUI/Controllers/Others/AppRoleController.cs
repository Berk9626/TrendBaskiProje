using ECommerce.EntityLayer.Concrete;
using ECommerce.WebUI.Dtos.AppRoleDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Versioning;

namespace ECommerce.WebUI.Controllers.Others
{
    [Authorize(Roles = "Admin")]
    public class AppRoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;

        public AppRoleController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public IActionResult Index()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }
        //------------------------------------------------------------------------------------------------------------------------------
        [HttpGet]
        public IActionResult AddAppRole()
        {
            return View();
        }
        //------------------------------------------------------------------------------------------------------------------------------
        [HttpPost]
        public async Task<IActionResult> AddAppRole(CreateAppRoleDto createAppRoleDto)
        {
            AppRole role = new AppRole()
            {
                Name = createAppRoleDto.AppRoleName
            };
            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            return View(result);
        }
        //------------------------------------------------------------------------------------------------------------------------------
        [HttpGet]
        public async Task<IActionResult> UpdateAppRole(int id)
        {
            var yakaladigimDbdekiRol = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            UpdateAppRoleDto updatemodel = new UpdateAppRoleDto()
            {
                RoleId = yakaladigimDbdekiRol.Id,
                AppRoleName = yakaladigimDbdekiRol.Name,
            };
            return View(updatemodel);
        }
        //------------------------------------------------------------------------------------------------------------------------------
        [HttpPost]
        public async Task<IActionResult> UpdateAppRole(UpdateAppRoleDto updatemodel)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == updatemodel.RoleId);
            values.Name = updatemodel.AppRoleName;
            await _roleManager.UpdateAsync(values);
            return RedirectToAction("Index");
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public async Task<IActionResult> DeleteAppRole(int id)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            await _roleManager.DeleteAsync(values);
            return RedirectToAction("Index");
        }
        //------------------------------------------------------------------------------------------------------------------------------


    }
}
