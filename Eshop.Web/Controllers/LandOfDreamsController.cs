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
    
    public async Task<IActionResult> Index()
    {
        var data = await _databaseHelper.GetDataAsync("SELECT TOP 10 * FROM Hotels");
        return View(data); // Pass data to the view
    }
}