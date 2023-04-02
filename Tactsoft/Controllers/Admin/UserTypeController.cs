using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class UserTypeController : Controller
    {
        private readonly IUserTypeService _userTypeService;
        public UserTypeController(IUserTypeService userTypeService)
        {
            _userTypeService = userTypeService;
        }

        // GET: UserTypeController
        public async Task<IActionResult>Index()
        {
            var registration = await _userTypeService.GetAllAsync();
            return View(registration);
        }

        // GET: UserTypeController/Details/5
        public async Task<IActionResult> Details(int Id)
        {
            var userType = await _userTypeService.FindAsync(Id);
            return View(userType);
        }

        // GET: UserTypeController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CUserTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserType userType)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _userTypeService.InsertAsync(userType);
                    TempData["successAlert"] = "Registration Save Successfull.";
                    return RedirectToAction("Index");
                }
                return View(userType);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: UserTypeController/Edit/5
        public async Task<IActionResult> Edit(int Id)
        {
            var userType = await _userTypeService.FindAsync(Id);
            return View(userType);
        }

        // POST: UserTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserType userType)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _userTypeService.UpdateAsync(userType);
                    TempData["successAlert"] = "Registration Update Successfull.";
                    return RedirectToAction("Index");
                }
                return View(userType);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: UserTypeController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var userType = await _userTypeService.FindAsync(id);
            if (userType == null)
            {
                return NotFound();
            }
           

            return View(userType);
        }

        // POST: UserTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userType = await _userTypeService.FindAsync(id);
            if (userType != null)
            {
                await _userTypeService.DeleteAsync(userType);
                TempData["successAlert"] = "user Type remove successfull.";
            }

            
            return RedirectToAction(nameof(Index));
        }
    }
}
