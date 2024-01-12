using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using ResistanceCalculator;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    ApplicationDBContext db;
    private const string V = "";
    public int ring1;
    public int ring2;
    public int ring3;
    public int ring4 = 0;
    public double ring5;
    public double ring6;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ApplicationDBContext context)
    {
        db = context;
    }

    public IActionResult Index(int id)
    {
        var resistorsList = db.Resistors
        .OrderByDescending(x => x.Resistance).ToList();
        if (id != 0 && db.Resistors.Any(x => x.Id == id))
        {
            ViewBag.CurrentResistor = resistorsList.FirstOrDefault(x => x.Id == id);
        }
        else
        {
            ViewBag.CurrentResistor = new Resistor();
        }

        ViewBag.ResistorsList = resistorsList;

        return View();
    }
    public IActionResult DeleteFromDB(int id)
    {
        if (id != 0 && db.Resistors.Any(x => x.Id == id))
        {
            Resistor res = db.Resistors.First(r => r.Id == id);
            db.Remove(res);
            db.SaveChanges();
        }
        else
        {
            ViewBag.CurrentResistor = new Resistor();
        }
        if (db.Resistors.Any())
        {
            ViewBag.ResistorsList = db.Resistors;
        }
        return View("Views/Home/Index.cshtml");
    }

    public ActionResult Rings(int rings)
    {
        // Передати значення в представлення через ViewBag або Model
        ViewData["ring"] = rings;

        return View("Views/Home/Index.cshtml");
    }

    [HttpPost]

    public IActionResult AddToDatabase(string r1_color, string r2_color, string r3_color, string r4_color, string r5_color, string r6_color, int num_of_rings)
    {

        Resistor myResistor = new Resistor(r1_color, r2_color, r3_color, r4_color, r5_color, r6_color, num_of_rings);

        db.Add(myResistor);

        db.SaveChanges();

        return RedirectToAction("Index");

    }

    [HttpPost]

    public IActionResult Index(string r1_color, string r2_color, string r3_color, string r4_color, string r5_color, string r6_color, int num_of_rings)
    {
        ViewData["ring"] = num_of_rings;
        ViewData["r1_color"] = r1_color;
        ViewData["r2_color"] = r2_color;
        ViewData["r3_color"] = r3_color;
        ViewData["r4_color"] = r4_color;
        ViewData["r5_color"] = r5_color;
        ViewData["r6_color"] = r6_color;

        Resistor myResistor = new Resistor(r1_color, r2_color, r3_color, r4_color, r5_color, r6_color, num_of_rings);
        ViewData["resistance"] = myResistor.Resistance;
        ViewData["prefix"] = myResistor.prefixes;
        ViewData["deviationFor5"] = myResistor.deviationFor5;
        ViewData["Coefficient"] = myResistor.precisions;
        ViewBag.CurrentResistor = myResistor;
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
