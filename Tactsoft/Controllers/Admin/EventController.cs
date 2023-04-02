using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
	public class EventController : Controller
	{
		private readonly IEventService _eventService;

		public EventController(IEventService eventService)
		{
			_eventService = eventService;
		}

		// GET: VenueController
		public async Task<IActionResult> Index()
		{
			var events = await _eventService.GetAllAsync();
			return View(events);
		}

		// GET: EventController/Details/5
		public async Task<IActionResult> Details(int Id)
		{
			var events = await _eventService.FindAsync(Id);
			return View(events);
		}

		// GET: EventController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: EventController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Event events, IFormFile eventPictureFile)
        {
            if (ModelState.IsValid)
            {
                if (eventPictureFile != null && eventPictureFile.Length > 0)
                {
                    var PicturePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/EventPicture",
                     eventPictureFile.FileName);

                    using (var stream = new FileStream(PicturePath, FileMode.Create))
                    {
                        eventPictureFile.CopyTo(stream);
                    }
                    events.EventPicture = $"{eventPictureFile.FileName}";
                }


                await _eventService.InsertAsync(events);
                TempData["successAlert"] = "Event save successfull.";
                return RedirectToAction(nameof(Index));
            }
           
            TempData["errorAlert"] = "Operation failed.";
            return View(events);
        }

        // GET: EventController/Edit/5
        public async Task<IActionResult> Edit(int Id)
        {
            var events = await _eventService.FindAsync(Id);
            if (events == null)
            {
                return NotFound();
            }
            return View(events);
        }

        // POST: EventController/Edit/5
        [HttpPost]
		[ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync(Event events, IFormFile eventPictureFile)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var editevents = await _eventService.FindAsync(events.Id);

                    if (eventPictureFile != null && eventPictureFile.Length > 0)
                    {
                        var PicturePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/EventPicture",
                         eventPictureFile.FileName);

                        using (var stream = new FileStream(PicturePath, FileMode.Create))
                        {
                            eventPictureFile.CopyTo(stream);
                        }
                        events.EventPicture = $"{eventPictureFile.FileName}";
                    }
                    else
                    {
                        
                       editevents.EventPicture = events.EventPicture;
                       
                    }
                    editevents.EventName = events.EventName;
                    editevents.EventDescription = events.EventDescription;
                    editevents.EventPicture = events.EventPicture;
                    

                    await _eventService.UpdateAsync(editevents);
                    TempData["successAlert"] = "Event update successfull.";
                }
                catch
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }

            TempData["errorAlert"] = "Operation failed.";
            return View(events);
        }

        // GET: EventController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var events = await _eventService.FindAsync(id);
            if (events == null)
            {
                return NotFound();
            }


            return View(events);
        }

        // POST: EventController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var events = await _eventService.FindAsync(id);
            if (events != null)
            {
                await _eventService.DeleteAsync(events);
                TempData["successAlert"] = "Event remove successfull.";
            }

            //TempData["errorAlert"] = "Operation failed.";
            return RedirectToAction(nameof(Index));
        }
    }
}
