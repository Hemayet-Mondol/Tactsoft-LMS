using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class LinkController : Controller
    {
        private readonly ILinkService _linkService;
        private readonly IBatchService _batchService;
        private readonly ICourseService _courseService;
        public LinkController(ILinkService linkService, IBatchService batchService, ICourseService courseService)
        {
            this._linkService = linkService;
            this._batchService = batchService;
            this._courseService = courseService;
        }

        // GET: LinkController
        public async Task<IActionResult> Index()
        {
            var link = await _linkService.GetAllAsync(x => x.Batch,x=>x.Course );
            return View(link);
        }

        // GET: LinkController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var link = await _linkService.FindAsync(m => m.Id == id, e => e.Batch,e=>e.Course);
            if (link == null)
            {
                return NotFound();
            }

            return View(link);
        }

        // GET: LinkController/Create
        public IActionResult Create()
        {
            ViewData["BatchId"] = _batchService.Dropdown();
            
            return View();
        }

        // POST: LinkController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Link link)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _linkService.InsertAsync(link);
                    TempData["successAlert"] = "Registration Save Successfull.";
                    return RedirectToAction("Index");
                }
                ViewData["BatchId"] = _batchService.Dropdown();
                ViewData["CourseId"] = _courseService.Dropdown();
                return View(link);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // GET: LinkController/Edit/5
        public async Task<IActionResult> Edit(long id)
        {
            var link = await _linkService.FindAsync(id);
            if (link == null)
            {
                return NotFound();
            }
            ViewData["BatchId"] = _batchService.Dropdown();
            ViewData["CourseId"] = _courseService.Dropdown();


            return View(link);
        }

        // POST: LinkController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Link link)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _linkService.UpdateAsync(link);
                    TempData["successAlert"] = "Registration Update Successfull.";
                    return RedirectToAction("Index");
                }
                ViewData["BatchId"] = _batchService.Dropdown();
                ViewData["CourseId"] = _courseService.Dropdown();
                return View(link);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // GET: LinkController/Delete/5
        
        public async Task<IActionResult> Delete(int id)
        {
            var link = await _linkService.FindAsync(id);
            if (link == null)
            {
                return NotFound();
            }
            ViewData["BatchId"] = _batchService.Dropdown();
            ViewData["CourseId"] = _courseService.Dropdown();

            return View(link);
        }

        // POST: LinkController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var link = await _linkService.FindAsync(id);
            if (link != null)
            {
                await _linkService.DeleteAsync(link);
                TempData["successAlert"] = "Link remove successfull.";
            }

            ////TempData["errorAlert"] = "Operation failed.";
            return RedirectToAction(nameof(Index));
        }
    }
}
