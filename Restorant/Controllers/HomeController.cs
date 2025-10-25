using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restorant.Application.IServices;
using Restorant.Data;
using Restorant.Models;
using Restorant.ViewModels;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Restorant.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryService _catService;

        public HomeController(ILogger<HomeController> logger, ICategoryService catService)
        {
            _logger = logger;
            _catService = catService;
        }

        public async Task<IActionResult> Index()
        {
            var cat = await _catService.GetAllCategoriesAsync();
            return View(cat.ToList());
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
