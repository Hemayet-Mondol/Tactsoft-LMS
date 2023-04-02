using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserTypeService _userTypeService;

        public UserController(IUserService userService, IUserTypeService userTypeService)
        {
            _userService = userService;
            _userTypeService = userTypeService;
        }
        // GET: UserController
        public async Task<IActionResult> Index()
        {
            var user = await _userService.GetAllAsync(x => x.UserType);
            return View(user);
        }

        // GET: UserController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var user = await _userService.FindAsync(m => m.Id == id, e => e.UserType);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: UserController/Create
        public IActionResult Create()
        {
            ViewData["UserTypeId"] = _userTypeService.Dropdown();
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {


                await _userService.InsertAsync(user);
                TempData["successAlert"] = "User save successfull.";
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserTypeId"] = _userTypeService.Dropdown();


            TempData["errorAlert"] = "Operation failed.";
            return View(user);
        }

        // GET: UserController/Edit/5
        public async Task<IActionResult> Edit(long id)
        {
            var user = await _userService.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ViewData["UserTypeId"] = _userTypeService.Dropdown();


            return View(user);
        }


        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(User user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var us = await _userService.FindAsync(user.Id);

                    us.UserName = user.UserName;
                    us.Password = user.Password;
                    us.UserTypeId = user.UserTypeId;
                    await _userService.UpdateAsync(us);
                    TempData["successAlert"] = "User update successfull.";
                }
                catch
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserTypeId"] = _userTypeService.Dropdown();


            TempData["errorAlert"] = "Operation failed.";
            return View(user);
        }
        // GET: UserController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var user = await _userService.FindAsync(m => m.Id == id, e => e.UserType);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _userService.FindAsync(id);
            if (user != null)
            {
                await _userService.DeleteAsync(user);
                TempData["successAlert"] = "User remove successfull.";
            }

           
            return RedirectToAction(nameof(Index));
        }
    }
}