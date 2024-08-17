using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcSong.Data;
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

    // GET: Movies/Details/5
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