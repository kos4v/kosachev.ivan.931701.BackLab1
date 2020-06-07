﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
            if (forum.Id == 0 || forum == null)
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
                topic.ForumID = _context.Forums.FirstOrDefault(t => t.Id == id).Id;
                topic.Reply = 0;
                _context.Add(topic);
                await _context.SaveChangesAsync();
                return RedirectToAction("AllTopics", "Topics", new { id = topic.ForumID });
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

            return View(topic);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name")] Topic topic)
        {
            if (ModelState["Name"].ValidationState == ModelValidationState.Valid)
            {
                Topic t = _context.Topics.Find(id);
                try
                {
                    t.Name = topic.Name;
                    _context.Update(t);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TopicExists(t.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("AllTopics", "Topics", new { id = t.ForumID });
            }
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
            int ForumId = topic.ForumID;
            if (topic == null)
            {
                return NotFound();
            }
            _context.Topics.Remove(topic);
            await _context.SaveChangesAsync();
            return RedirectToAction("AllTopics", "Topics", new { id = ForumId });
        }

        private bool TopicExists(int id)
        {
            return _context.Topics.Any(e => e.Id == id);
        }
    }
}
