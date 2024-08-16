using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcSong.Controllers;

public class SongController : Controller
{
    // 
    // GET: /HelloWorld/
    public IActionResult Index()
    {
        return View();
    }
    // 
    // GET: /HelloWorld/Welcome/ 
    public IActionResult Welcome(string name, int num=7)
    {
        ViewData["Message"]="Hello "+name;
        ViewData["num"]=num;
        return View();

    }
}