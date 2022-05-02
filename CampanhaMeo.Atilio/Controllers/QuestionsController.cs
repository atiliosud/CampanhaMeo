#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CampanhaMeo.Atilio.Data;
using CampanhaMeo.Atilio.Models;
using CampanhaMeo.Atilio.ModelViews;
using CampanhaMeo.Atilio.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace CampanhaMeo.Atilio.Controllers
{
    [Authorize]
    public class QuestionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuestionsController(ApplicationDbContext context)
        {
            _context = context;
        }



        // GET: Questions/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Questions
                .Include(q => q.CreateBy)
                .Include(q => q.Survey)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // GET: Questions/Create
        public IActionResult CreateFreeText(Guid? surveyId)
        {

            if (surveyId == null)
            {
                return NotFound();
            }
            return View(new QuestionCreateFreeText(surveyId.Value));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFreeText(QuestionCreateFreeText questionMV)
        {
            if (ModelState.IsValid)
            {
                var question = questionMV.ToModel();
                question.CreateById = User.GetUserId();
                question.CreateAt = DateTimeOffset.Now;
                _context.Add(question);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Surveys", new { id = question.SurveyId.ToString() });
            }
            return View(questionMV);
        }

        public IActionResult CreateSingleSelect(Guid? surveyId, int numbOptions)
        {

            if (surveyId == null)
            {
                return NotFound();
            }
            return View(new QuestionCreateSingleSelect(surveyId.Value, numbOptions));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSingleSelect(QuestionCreateSingleSelect questionMV)
        {
            if (ModelState.IsValid)
            {
                var question = questionMV.ToModel();
                question.CreateById = User.GetUserId();
                question.CreateAt = DateTimeOffset.Now;
                _context.Add(question);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Surveys", new { id = question.SurveyId.ToString() });
            }
            return View(questionMV);
        }

        public IActionResult CreateMultiSelect(Guid? surveyId, int numbOptions)
        {

            if (surveyId == null)
            {
                return NotFound();
            }
            return View(new QuestionCreateMultiSelect(surveyId.Value, numbOptions));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMultiSelect(QuestionCreateMultiSelect questionMV)
        {
            if (ModelState.IsValid)
            {
                var question = questionMV.ToModel();
                question.CreateById = User.GetUserId();
                question.CreateAt = DateTimeOffset.Now;
                _context.Add(question);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Surveys", new { id = question.SurveyId.ToString() });
            }
            return View(questionMV);
        }

        // GET: Questions/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Questions
                .Include(q => q.CreateBy)
                .Include(q => q.Survey)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var question = await _context.Questions.FindAsync(id);
            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionExists(Guid id)
        {
            return _context.Questions.Any(e => e.Id == id);
        }
    }
}
