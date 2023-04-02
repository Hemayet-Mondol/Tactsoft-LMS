using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
    public class VenueController : Controller
    {
        private readonly IVenueService _venueService;

        public VenueController(IVenueService venueService)
        {
            this._venueService = venueService;
        }


        // GET: VenueController
        public async Task<IActionResult> Index()
        {
            var venue = await _venueService.GetAllAsync();
            return View(venue);
        }

		// GET: VenueController/Details/5
		public async Task<IActionResult> Details(int Id)
		{
			var userType = await _venueService.FindAsync(Id);
			return View(userType);
		}

		// GET: VenueController/Create
		public ActionResult Create()
        {
            return View();
        }

        // POST: VenueController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Venue venue)
		{
			try
			{
				if (ModelState.IsValid)
				{
					await _venueService.InsertAsync(venue);
					TempData["successAlert"] = "Venue Save Successfull.";
					return RedirectToAction("Index");
				}
				return View(venue);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		// GET: VenueController/Edit/5
		public async Task<IActionResult> Edit(int Id)
		{
			var venue = await _venueService.FindAsync(Id);
			return View(venue);
		}

		// POST: VenueController/Edit/5
		[HttpPost]
        [ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(Venue venue)
		{
			try
			{
				if (ModelState.IsValid)
				{
					await _venueService.UpdateAsync(venue);
					TempData["successAlert"] = "Venue Update Successfull.";
					return RedirectToAction("Index");
				}
				return View(venue);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		// GET: VenueController/Delete/5
		public async Task<IActionResult> Delete(int id)
		{
			var venue = await _venueService.FindAsync(id);
			if (venue == null)
			{
				return NotFound();
			}


			return View(venue);
		}

        // POST: VenueController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var venue = await _venueService.FindAsync(id);
			if (venue != null)
			{
				await _venueService.DeleteAsync(venue);
				TempData["successAlert"] = "user Type remove successfull.";
			}

			return RedirectToAction(nameof(Index));
		}
	}
}
