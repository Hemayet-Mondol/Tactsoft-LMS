using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tactsoft.Core.Entities;
using Tactsoft.Service.Services;

namespace Tactsoft.Controllers.Admin
{
	public class CommentsController : Controller
	{
		private readonly ICommentService _commentService;
		public CommentsController(ICommentService commentService)
		{
			_commentService = commentService;
		}
		// GET: CommentsController
		public async Task<ActionResult> Index()
		{
			var comments = await _commentService.GetAllAsync();
			return View(comments);
		}

		// GET: CommentsController/Details/5
		public async Task<IActionResult> Details(int id)
		{
			var comments = await _commentService.FindAsync(id);
			return View(comments);
		}

		// GET: CommentsController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: CommentsController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Comments comments)
		{
			try
			{
				if (ModelState.IsValid)
				{
					await _commentService.InsertAsync(comments);
				}
				TempData["successAlert"] = "Comment save successfully.";
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: CommentsController/Edit/5
		public async Task<IActionResult> Edit(int id)
		{
			var comment = await _commentService.FindAsync(id);
			return View(comment);
		}

		// POST: CommentsController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(Comments comments)
		{
			try
			{
				if (ModelState.IsValid)
				{
					await _commentService.UpdateAsync(comments);
				}

				TempData["successAlert"] = "Comment update successfully.";
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: CommentsController/Delete/5
		public async Task<IActionResult> Delete(int id)
		{
			var comment = await _commentService.FindAsync(id);
			return View(comment);
		}

		// POST: CommentsController/Delete/5
		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var batch = await _commentService.FindAsync(id);
			if (batch != null)
			{
				await _commentService.DeleteAsync(batch);
				TempData["successAlert"] = "Comment remove successfull.";
			}
			return RedirectToAction(nameof(Index));
		}
	}
}
