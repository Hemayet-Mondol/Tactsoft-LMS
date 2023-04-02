using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class BatchController : Controller
    {
        private readonly IBatchService _batchService;
        private readonly ICourseService _courseService;
        private readonly IClassRoomService _classRoomService;
        private readonly ITrainerService _trainerService;
        private readonly IVenueService _venueService;
        

        public BatchController(IBatchService batchService, ICourseService courseService, 
            IClassRoomService classRoomService, ITrainerService trainerService,IVenueService venueService)
        {
            _batchService = batchService;
            _courseService = courseService;
            _classRoomService = classRoomService;
            _trainerService = trainerService;
            _venueService = venueService;
        }

        // GET: BatchController
        public async Task<IActionResult> Index()
        {
            var bt = await _batchService.GetAllAsync(x => x.Course, x => x.ClassRoom, x => x.Trainer, x=>x.Venue);
            return View(bt);
        }

        // GET: BatchController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var bt = await _batchService.FindAsync(x => x.Id == id, x => x.Course, x => x.ClassRoom, x => x.Trainer, x => x.Venue);
            if (bt == null)
            {
                return NotFound();
            }
            return View(bt);
        }

        // GET: BatchController/Create
        public IActionResult Create()
        {
            ViewData["ClassRoomId"] = _classRoomService.Dropdown();
            ViewData["TrainerId"] = _trainerService.Dropdown();
            ViewData["VenueId"] = _venueService.Dropdown();
            ViewData["CourseId"] = _courseService.Dropdown();
            return View();
        }

        // POST: BatchController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Batch batch)
        {
            if (ModelState.IsValid)
            {
                await _batchService.InsertAsync(batch);
                TempData["successAlert"] = "Batch save successfull.";
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassRoomId"] = _classRoomService.Dropdown();
            ViewData["TrainerId"] = _trainerService.Dropdown();
            ViewData["VenueId"] = _venueService.Dropdown();
            ViewData["CourseId"] = _courseService.Dropdown();

            TempData["errorAlert"] = "Operation failed.";
            return View(batch);
        }

        // GET: BatchController/Edit/5
        public async Task<IActionResult> Edit(long id)
        {
            var batch= await _batchService.FindAsync(id);
            if (batch == null) 
            {
                return NotFound();
            }
            ViewData["ClassRoomId"] = _classRoomService.Dropdown();
            ViewData["TrainerId"] = _trainerService.Dropdown();
            ViewData["VenueId"] = _venueService.Dropdown();
            ViewData["CourseId"] = _courseService.Dropdown();
            return View(batch);
        }

        // POST: BatchController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(Batch batch)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var editedBatch = await _batchService.FindAsync(batch.Id);

                    editedBatch.BatchName = batch.BatchName;
                    editedBatch.Slote = batch.Slote;
                    editedBatch.StartDate = batch.StartDate;
                    editedBatch.EndDate = batch.EndDate;
                    editedBatch.Remarks = batch.Remarks;
                    editedBatch.CourseId = batch.CourseId;
                    editedBatch.ClassRoomId = batch.ClassRoomId;
                    editedBatch.TrainerId = batch.TrainerId;


                    await _batchService.UpdateAsync(editedBatch);
                    TempData["successAlert"] = "Batch update successfull.";
                }
                catch
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassRoomId"] = _classRoomService.Dropdown();
            ViewData["TrainerId"] = _trainerService.Dropdown();
            ViewData["CourseId"] = _courseService.Dropdown();

            TempData["errorAlert"] = "Operation failed.";
            return View(batch);
        }

        // GET: BatchController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var batch = await _batchService.FindAsync(e => e.Id == e.Id, e => e.ClassRoom, e => e.Trainer, e => e.Course);
            
            ViewData["ClassRoomId"] = _classRoomService.Dropdown();
            ViewData["TrainerId"] = _trainerService.Dropdown();
            ViewData["CourseId"] = _courseService.Dropdown();

            return View(batch);
        }
        // POST: BatchController/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var batch = await _batchService.FindAsync(id);
            if (batch != null)
            {
                await _batchService.DeleteAsync(batch);
                TempData["successAlert"] = "Batch remove successfull.";
            }
            TempData["errorAlert"] = "Operation failed.";
            return RedirectToAction(nameof(Index));
        }

    }
}
