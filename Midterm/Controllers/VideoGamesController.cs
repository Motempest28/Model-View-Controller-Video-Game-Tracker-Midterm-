using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Midterm.Data;
using Midterm.Models;

namespace Midterm.Controllers
{
    public class VideoGamesController : Controller
    {
        private readonly VideoGameContext _context;

        public VideoGamesController(VideoGameContext context)
        {
            _context = context;
        }

        // GET: VideoGames
        public async Task<IActionResult> Index(string VideoGameGenre, string searchString)
        {
            //return _context.VideoGame != null ? 
            //            View(await _context.VideoGame.ToListAsync()) :
            //            Problem("Entity set 'VideoGameContext.VideoGame'  is null.");


            if (_context.VideoGame == null)
            {
                return Problem("Entity set 'VideoGameContext.VideoGames'  is null.");
            }

            IQueryable<string> genreQuery = from vg in _context.VideoGame
                                            orderby vg.Genre
                                            select vg.Genre;

            var VideoGames = from vg in _context.VideoGame
                         select vg;

            if (!String.IsNullOrEmpty(searchString))
            {
                VideoGames = VideoGames.Where(s => s.Title!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(VideoGameGenre))
            {
                VideoGames = VideoGames.Where(x => x.Genre == VideoGameGenre);
            }

            var videoGameGenreVM = new VideoGameGenreViewModel
            {
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
                VideoGames = await VideoGames.ToListAsync()
            };

            return View(videoGameGenreVM);
        }

        // GET: VideoGames/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.VideoGame == null)
            {
                return NotFound();
            }

            var videoGame = await _context.VideoGame
                .FirstOrDefaultAsync(m => m.Id == id);
            if (videoGame == null)
            {
                return NotFound();
            }

            return View(videoGame);
        }

        // GET: VideoGames/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VideoGames/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Publisher,Genre,MSRP,ReleaseDate,Summary,Rating")] VideoGame videoGame)
        {
            if (ModelState.IsValid)
            {
                _context.Add(videoGame);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(videoGame);
        }

        // GET: VideoGames/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.VideoGame == null)
            {
                return NotFound();
            }

            var videoGame = await _context.VideoGame.FindAsync(id);
            if (videoGame == null)
            {
                return NotFound();
            }
            return View(videoGame);
        }

        // POST: VideoGames/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Publisher,Genre,MSRP,ReleaseDate,Summary,Rating")] VideoGame videoGame)
        {
            if (id != videoGame.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(videoGame);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VideoGameExists(videoGame.Id))
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
            return View(videoGame);
        }

        // GET: VideoGames/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.VideoGame == null)
            {
                return NotFound();
            }

            var videoGame = await _context.VideoGame
                .FirstOrDefaultAsync(m => m.Id == id);
            if (videoGame == null)
            {
                return NotFound();
            }

            return View(videoGame);
        }

        // POST: VideoGames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.VideoGame == null)
            {
                return Problem("Entity set 'VideoGameContext.VideoGame'  is null.");
            }
            var videoGame = await _context.VideoGame.FindAsync(id);
            if (videoGame != null)
            {
                _context.VideoGame.Remove(videoGame);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VideoGameExists(int id)
        {
          return (_context.VideoGame?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
