using Business.Contracts;
using Entities.Dtos;
using Markdig;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CozaStore_AspNetCore6.Areas.Admin.Controllers
{
    [Authorize]
    [Authorize(Policy = "AdminOnly")]
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public AboutController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        // GET: About
        public IActionResult Index()
        {
            var abouts = _serviceManager.AboutService.FindAllAbouts();
            if (!abouts.Any())
            {
                ViewBag.EmptyMessage = "There are no about entries to display.";
            }
            else
            {
                foreach (var about in abouts)
                {
                    about.OurStory = Markdown.ToHtml(about.OurStory ?? string.Empty);
                    about.OurMission = Markdown.ToHtml(about.OurMission ?? string.Empty);
                }
            }
            return View(abouts);
        }

        public IActionResult Edit(int id)
        {
            var model = _serviceManager.AboutService.GetAboutByIdForUpdate(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromForm]AboutForUpdateDto aboutForUpdate)
        {

            if (ModelState.IsValid)
            {
                _serviceManager.AboutService.UpdateAbout(aboutForUpdate);
                return RedirectToAction(nameof(Index));
            }
            return View(aboutForUpdate);
        }

    }
}
