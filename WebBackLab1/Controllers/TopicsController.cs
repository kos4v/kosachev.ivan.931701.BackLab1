using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebBackLab1.Models;

namespace WebBackLab1.Controllers
{
    public class TopicsController : Controller
    {
        private readonly AppdbContext _context;

        public TopicsController(AppdbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> AllTopics([Bind("Id")] Forum forum)
         {
            if (forum.Id == 0)
                forum.Id = _context.Forums.First(t => t.Id > 0).Id;
            ViewData["ForumName"] = _context.Forums.FirstOrDefault(t => t.Id == forum.Id).Name;
            ViewData["ForumDescription"] = _context.Forums.FirstOrDefault(t => t.Id == forum.Id).Description;
            ViewBag.ForumId = forum.Id;
            return View(await _context.Topics.Where(t => t.ForumID == forum.Id).ToListAsync());

        }
        public async Task<IActionResult> Index()
        {
            var appdbContext = _context.Topics.Include(t => t.Forum);
            return View(await appdbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topic = await _context.Topics
                .Include(t => t.Forum)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (topic == null)
            {
                return NotFound();
            }

            return View(topic);
        }

        public IActionResult Create(int? id)
        {
            ViewBag.ForumId = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Reply")] Topic topic, int? id)
        {
            if (ModelState.IsValid)
            {
                DateTime date1 = DateTime.Now;
                topic.DateCreate = "" + date1.DayOfWeek + ", "
                    + date1.ToLongDateString() + ", "
                    + date1.ToLongTimeString();
                topic.Forum = topic.Forum = _context.Forums.FirstOrDefault(t => t.Id == id);
                _context.Add(topic);
                await _context.SaveChangesAsync();  
                return RedirectToAction(nameof(Index));
            }
            return View(topic);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topic = await _context.Topics.FindAsync(id);
            if (topic == null)
            {
                return NotFound();
            }
            ViewData["ForumID"] = new SelectList(_context.Forums, "Id", "Description", topic.ForumID);
            return View(topic);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Reply,ForumID,Date")] Topic topic)
        {
            if (id != topic.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(topic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TopicExists(topic.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ForumID"] = new SelectList(_context.Forums, "Id", "Description", topic.ForumID);
            return View(topic);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topic = await _context.Topics
                .Include(t => t.Forum)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (topic == null)
            {
                return NotFound();
            }

            return View(topic);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var topic = await _context.Topics.FindAsync(id);
            _context.Topics.Remove(topic);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool TopicExists(int id)
        {
            return _context.Topics.Any(e => e.Id == id);
        }
    }
}
