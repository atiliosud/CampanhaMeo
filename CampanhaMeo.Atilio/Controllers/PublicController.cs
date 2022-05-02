using CampanhaMeo.Atilio.Data;
using CampanhaMeo.Atilio.Helpers;
using CampanhaMeo.Atilio.Models;
using CampanhaMeo.Atilio.ModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CampanhaMeo.Atilio.Controllers
{
    public class PublicController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PublicController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Reply(string id)
        {
            if (String.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var survey = await _context.Surveys
                .Include(s => s.Questions)
                .Include(s => s.CreateBy)
                .FirstOrDefaultAsync(m => m.FriendlyUrl == id);
            if (survey == null)
            {
                return NotFound();
            }

            ViewData["Title"] = survey.Title;
            ViewData["Description"] = survey.Description;

            survey.Questions = survey.Questions.OrderBy(x => x.Order).ToList();
            return View(survey.GenerateEmptyAnswers());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reply(IEnumerable<QuestionGenericToAnswer> answers)
        {

            if (ModelState.IsValid)
            {
                var dateNow = DateTimeOffset.Now;
                var internetUserKey = Guid.NewGuid();
                var metadata = JsonConvert.SerializeObject(Request.Headers);
                foreach (var item in answers)
                {
                    Answer a = item.ToModel();
                    a.Id = Guid.NewGuid();
                    a.InternetUserKey= internetUserKey;
                    a.Metadata = metadata;
                    a.CreateAt = dateNow;
                    _context.Add(a);

                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Success));
            }
            return View(answers);
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
