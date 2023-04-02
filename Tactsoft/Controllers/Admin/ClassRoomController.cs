using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class ClassRoomController : Controller
    {
        private readonly IClassRoomService _classRoomService;

        public ClassRoomController(IClassRoomService classRoomService)
        {
            _classRoomService = classRoomService;
        }
        // GET: ClassRoomController
        public async Task<IActionResult> Index()
        {
            var classRoom = await _classRoomService.GetAllAsync();
            return View(classRoom);
        }

        // GET: ClassRoomController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var classRoom = await _classRoomService.FindAsync(m => m.Id == id);
            if (classRoom == null)
            {
                return NotFound();
            }

            return View(classRoom);
        }

        // GET: ClassRoomController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClassRoomController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClassRoom classRoom)
        {
            if (ModelState.IsValid)
            {
                await _classRoomService.InsertAsync(classRoom);
                TempData["successAlert"] = "ClassRoom save successfull.";
                return RedirectToAction(nameof(Index));
            }
            
                TempData["errorAlert"] = "Operation failed.";
                return View(classRoom);
        }

        // GET: ClassRoomController/Edit/5
        public async Task<IActionResult> Edit(long id)
        {
            var classRoom = await _classRoomService.FindAsync(id);
            if (classRoom == null)
            {
                return NotFound();
            }
            //ViewData["CourseId"] = _courseService.Dropdown();


            return View(classRoom);
        }

        // POST: ClassRoomController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(ClassRoom classRoom)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var editclassRoom = await _classRoomService.FindAsync(classRoom.Id);


                    editclassRoom.ClassRoomNumber = classRoom.ClassRoomNumber;
                    editclassRoom.ClassRoomName = classRoom.ClassRoomName;
                    

                    await _classRoomService.UpdateAsync(editclassRoom);
                    TempData["successAlert"] = "Lesson update successfull.";
                }
                catch
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            //ViewData["CourseId"] = _courseService.Dropdown();


            TempData["errorAlert"] = "Operation failed.";
            return View(classRoom);
        }

        // GET: ClassRoomController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var classRoom = await _classRoomService.FindAsync(id);
            if (classRoom == null)
            {
                return NotFound();
            }
            //ViewData["CourseId"] = _courseService.Dropdown();


            return View(classRoom);
        }

        // POST: ClassRoomController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classRoom = await _classRoomService.FindAsync(id);
            if (classRoom != null)
            {
                await _classRoomService.DeleteAsync(classRoom);
                TempData["successAlert"] = "ClassRoom remove successfull.";
            }

            TempData["errorAlert"] = "Operation failed.";
            return RedirectToAction(nameof(Index));
        }
    }
}
