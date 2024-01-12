using Microsoft.AspNetCore.Mvc;
namespace WebApp.Controllers;

public class Dkr : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(double nums, string first, string second)
    {
        ViewData["nums"] = nums;
        ViewData["first"] = first;
        ViewData["second"] = second;
        ViewData["result"] = Convertation(nums, first, second);
        return View("Views/Dkr/Index.cshtml"); // Optionally, return a view or redirect to another action.
    }

    public IActionResult Author()
    {
        return View("Views/Dkr/Author.cshtml");
    }

    public string Convertation(double nums, string first, string second)
    {
        if (first == "km" && second == "ps")
        {
            //double res = nums / ( 3.086*Math.E+13);
            double res = nums /  3.086e+13;
            return nums + " km = " + res + " parsecs";
        }
        if (first == "ps" && second == "km")
        {
            double res = nums * 3.086e+13;
            return nums + " parsecs = " + res + " km";
        }
        if (first == "km" && second == "ft")
        {
            double res = nums * 3281;
            return nums + " km = " + res + " feet";
        }
        if (first == "ft" && second == "km")
        {
            double res = nums / 3281;
            return nums + " feet = " + res + " km";
        }
        if (first == "ft" && second == "ps")
        {
            double res = nums / (1.012 * Math.Pow(10, 17));
            return nums + " feet = " + res + " parsecs";
        }
        if (first == "ps" && second == "ft")
        {
            double res = nums * (1.012 * Math.Pow(10, 17));
            return nums + " parsecs = " + res + " feet";
        }

        return "Error";
    }
}