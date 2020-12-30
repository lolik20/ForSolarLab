
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication12.Models;

using Microsoft.EntityFrameworkCore;

namespace WebApplication12.Controllers {
	public class HomeController: Controller {
		private ApplicationContext db;
		public HomeController(ApplicationContext context) {
			db = context;
		}
		public async Task < IActionResult > Edit(int ? id) {
			if (id != null) {
				UserTask user = await db.userTasks.FirstOrDefaultAsync(p = >p.id == id);
				if (user != null) {
					return View(user);
				}
			}
			return NotFound();
		} [HttpPost]
		public async Task < IActionResult > Edit(UserTask userTask) {
			db.userTasks.Update(userTask);
			await db.SaveChangesAsync();
			return RedirectToAction("Index");
		}
		public async Task < IActionResult > Index() {
			return View(await db.userTasks.ToListAsync());
		} [HttpGet]
		public IActionResult AddTask() {
			return View();
		} [HttpPost]

		public async Task < IActionResult > AddTask(UserTask task) {
			db.userTasks.Add(task);
			await db.SaveChangesAsync();
			return RedirectToAction("Index");
		}

		[HttpGet][ActionName("Delete")]
		public async Task < IActionResult > CheckForDelete(int ? id) {
			if (id != null) {
				UserTask userTask = await db.userTasks.FirstOrDefaultAsync(p = >p.id == id);
				if (userTask != null)

				return View(userTask);

			}

			return NotFound();

		} [HttpPost]
		public async Task < IActionResult > Delete(int ? id) {
			if (id != null) {
				UserTask userTask = await db.userTasks.FirstOrDefaultAsync(p = >p.id == id);
				if (userTask != null) {
					db.userTasks.Remove(userTask);
					await db.SaveChangesAsync();
					return RedirectToAction("Index");
				}
			}
			return NotFound();
		} [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error() {
			return View(new ErrorViewModel {
				RequestId = Activity.Current ? .Id ? ?HttpContext.TraceIdentifier
			});
		}
	}
}