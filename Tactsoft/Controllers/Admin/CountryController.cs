using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Tactsoft.Controllers.Admin
{
    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;
        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }


        // GET: CountryController
        public async Task<ActionResult> Index()
        {
            var countries = await _countryService.GetAllAsync();
            return View(countries);
        }

        // GET: CountryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CountryController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CountryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Country country)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    await _countryService.InsertAsync(country);
                    
                }
                TempData["successAlert"] = "Country save successfull.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CountryController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var country = await _countryService.FindAsync(id);
            return View(country);
        }

        // POST: CountryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Country country)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    await _countryService.UpdateAsync(country);
                   
                }
                TempData["successAlert"] = "Country update successfull.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CountryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CountryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
