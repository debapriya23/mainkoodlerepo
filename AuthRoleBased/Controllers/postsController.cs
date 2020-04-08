using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AuthRoleBased.Data;
using KOODLE.Models;

namespace KOODLE.Controllers
{
    public class postsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public postsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: posts
        public async Task<IActionResult> Index()
        {
            return View(await _context.posts.ToListAsync());
        }

        // GET: posts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posts = await _context.posts
                .FirstOrDefaultAsync(m => m.post_id == id);
            if (posts == null)
            {
                return NotFound();
            }

            return View(posts);
        }

        // GET: posts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("post_id,post_titel,post_txt,post_date,post_like")] posts posts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(posts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(posts);
        }

        // GET: posts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posts = await _context.posts.FindAsync(id);
            if (posts == null)
            {
                return NotFound();
            }
            return View(posts);
        }

        // POST: posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("post_id,post_titel,post_txt,post_date,post_like")] posts posts)
        {
            if (id != posts.post_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(posts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!postsExists(posts.post_id))
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
            return View(posts);
        }

        // GET: posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posts = await _context.posts
                .FirstOrDefaultAsync(m => m.post_id == id);
            if (posts == null)
            {
                return NotFound();
            }

            return View(posts);
        }

        // POST: posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var posts = await _context.posts.FindAsync(id);
            _context.posts.Remove(posts);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool postsExists(int id)
        {
            return _context.posts.Any(e => e.post_id == id);
        }
    }
}
