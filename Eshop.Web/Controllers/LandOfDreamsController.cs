using EShop.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Eshop.Web.Controllers;

public class LandOfDreamsController :Controller
{
    private readonly DatabaseHelper _databaseHelper;


    public LandOfDreamsController(ILogger<HomeController> logger, DatabaseHelper databaseHelper)
    {
        _databaseHelper = databaseHelper;
    }
    
    /*
    public async Task<IActionResult> Index()
    {
        var hotels = await _databaseHelper.GetDataAsync("SELECT TOP 10 Name, Price, Location, Map, Description, ImageUrl FROM Hotels");
        var apartments = await _databaseHelper.GetDataAsync("SELECT TOP 10 Name, Price, Location, Map, Description, ImageUrl FROM Apartments");

        var combinedData = new List<Dictionary<string, object>>();
        
        foreach (var hotel in hotels)
        {
            combinedData.Add(hotel);
        }

        foreach (var apartment in apartments)
        {
            combinedData.Add(apartment);
        }
        return View(combinedData); 
    }
    */
    public async Task<IActionResult> Index()
    {
        var query = "SELECT Name, Price, Location, Map, Description, ImageUrl FROM Hotels " +
                    "UNION ALL " +
                    "SELECT Name, Price, Location, Map, Description, ImageUrl FROM Apartments";

        var combinedData = await _databaseHelper.GetDataAsync(query);
        return View(combinedData);
    }

}