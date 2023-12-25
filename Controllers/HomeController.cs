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

    // public HomeController(ILogger<HomeController> logger)
    // {
    //     _logger = logger;
    // }
    public HomeController(ApplicationDBContext context)

    {

        db = context;

    }

    public IActionResult Index()
    {
        return View();
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
    
    public IActionResult Index(string r1_color, string r2_color, string r3_color, string r4_color, string r5_color, string r6_color, int ring)
    {
        ViewData["ring"] =  ring;
        ViewData["r1_color"] = r1_color;
        ring1 = findNumber(r1_color);

        ViewData["r2_color"] = r2_color;
        ring2 = findNumber(r2_color);

        ViewData["r3_color"] = r3_color;
        ring3 = findNumber(r3_color);

        if (ring>=4)
        {
            ViewData["r4_color"] = r4_color;
            ring4 = findNumber(r4_color);
        }

        if (ring >= 5)
        {
            ViewData["r5_color"] = r5_color;
            ring5 = deviation(r5_color);
        }

        if (ring>=6)
        {
            ViewData["r6_color"] = r6_color;
            ring6 = coefficient(r6_color);
        }
        string result = "";
        if (ring == 3)
        {
            double res = ((ring1 * 100) + (ring2 * 10)) * Math.Pow(10, ring3);
            result = $"{prefix(res).Item1} {prefix(res).Item2} ";
        }
        if (ring == 4)
        {
            double res = ((ring1 * 100) + (ring2 * 10) + (ring3)) * Math.Pow(10, ring4);
            result = $"{prefix(res).Item1} {prefix(res).Item2}";
        }
        if (ring == 5)
        {
            double res = ((ring1 * 100) + (ring2 * 10) + (ring3)) * Math.Pow(10, ring4);
            result = $"{prefix(res).Item1} {prefix(res).Item2} \n deviation: +-{ring5}";
        }
        if (ring == 6)
        {
            double res = ((ring1 * 100) + (ring2 * 10) + (ring3)) * Math.Pow(10, ring4);
            result = $"{prefix(res).Item1} {prefix(res).Item2} \n deviation: +-{ring5} \n coefficient: {ring6}";
        }
        ViewData["resistance"] = result;
        
        return View();
    }
        
        public (double, string) prefix(double resistance)
        {
            int temp = 0;
            string str = resistance + "";
            temp = str.Length;
            string word = "";
            if (temp <= 3 ) 
            {
                word = " Om";
                temp = 1;
            }
            if (temp > 3 && temp <= 6)
            {
                word = " kOm";
                temp = 3;
            }
            if (temp > 6 && temp <=9)
            {
                word = " MOm";
                temp = 6;
            }
            if (temp > 9 && temp <= 12)
            {
                word = " GOm";
                temp = 9;
            }
            if (temp > 12)
            {
                word = " TOm";
                temp = 12;
            }
            resistance /= Math.Pow(10, temp);
            return (resistance, word);

        }
        public int findNumber(string ring)
        {
            if (ring == "black") return 0;
            if (ring == "brown") return 1;
            if (ring == "red") return 2;
            if (ring == "orange") return 3;
            if (ring == "yellow") return 4;
            if (ring == "green") return 5;
            if (ring == "blue") return 6;
            if (ring == "purple") return 7;
            if (ring == "grey") return 8;
            if (ring == "white") return 9;
            return 0;
        }
        public double deviation(string ring_value)
        {
            switch (ring_value)
            {
            case "red":
                    return ring5 = 2;
            case "blue":
                    return ring5 = 0.25;
                    break;
            case "green":
                    return ring5 = 0.5;
                    break;
            case "brown":
                    return ring5 = 1;
                    break;
            case "grey":
                    return ring5 = 0.05;
                    break;
            case "gold":
                    return ring5 = 5;
                    break;
            case "purple":
                    return ring5 = 0.1;
                    break;
            case "silver":
                    return ring5 = 10;
                    break;
            default:
                    return ring5 = 0;
                    break;
            }
            return ring5;
        }
        public double coefficient(string ring_value)
        {
            switch (ring_value)
            {
                case "red":
                    return ring6 = 50;
                    break;
                case "blue":
                    return ring6 = 10;
                    break;
                case "orange":
                    return ring6 = 15;
                    break;
                case "brown":
                    return ring6 = 100;
                    break;
                case "yellow":
                    return ring6 = 25;
                    break;
                case "purple":
                    return ring6 = 5;
                break;
            case "white":
                    return ring6 = 1;
                    break;
                default:
                    return ring6 = 0;
                    break;
            }
            return ring6;
        }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
