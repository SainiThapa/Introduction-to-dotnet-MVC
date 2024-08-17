using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcSong.Data;
using MvcSong.Models;
using System.Text.Encodings.Web;

namespace MvcSong.Controllers;

public class SongController : Controller
{
    
    private readonly MvcSongContext _context;

    public SongController(MvcSongContext context)
    {
        _context = context;
    }

    // GET: /HelloWorld/
    // public IActionResult Index()
    // {
    //     return View();
    // }

    // GET: Movies
    public async Task<IActionResult> Index()
    {
        return View(await _context.Song.ToListAsync());
    }

    // 
    // GET: /HelloWorld/Welcome/ 
    public IActionResult Welcome(string name, int num=7)
    {
        ViewData["Message"]="Hello "+name;
        ViewData["num"]=num;
        return View();

    }


// GET: Movies/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var song = await _context.Song.FindAsync(id);
        if (song == null)
        {
            return NotFound();
        }
        return View(song);
    }

// POST: Movies/Edit/5
// To protect from overposting attacks, enable the specific properties you want to bind to.
// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] Song song)
{
    if (id != song.Id)
    {
        return NotFound();
    }

    if (ModelState.IsValid)
    {
        try
        {
            _context.Update(song);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!SongExists(song.Id))
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
    return View(song);
}

    private bool SongExists(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var song = await _context.Song
            .FirstOrDefaultAsync(m => m.Id == id);
        if (song == null)
        {
            return NotFound();
        }

        return View(song);
    }

}