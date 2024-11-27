using Animales.DAL;
using AplicacionTestMVC.Models;
using AplicacionTestMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace AplicacionTestMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            AnimalDAL dal = new AnimalDAL();

            AnimalViewModel viewModel = new AnimalViewModel();
            viewModel.Animales = dal.GetAll();

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DetailAnimal(int idAnimal)
        {
            AnimalDAL dal = new AnimalDAL();

            DetailAnimalViewModel viewModel = new DetailAnimalViewModel
            {
                AnimalDetail = dal.GetById(idAnimal)
            };
            TempData["Animal"] = JsonConvert.SerializeObject(viewModel);

            return RedirectToAction("Index", "Animal");
        }

        [HttpPost]
        public IActionResult CreateAnimal()
        {
            return RedirectToAction("CreateAnimal", "Animal");
        }

        [HttpPost]
        public IActionResult EditAnimal(int idAnimal)
        {
            AnimalDAL dal = new AnimalDAL();

            EditAnimalViewModel viewModel = new EditAnimalViewModel
            {
                EditedAnimal = dal.GetById(idAnimal)
            };

            TempData["Animal"] = JsonConvert.SerializeObject(viewModel);

            return RedirectToAction("EditAnimal", "Animal");
        }

        [HttpPost]
        public IActionResult EliminateAnimal(int idAnimal)
        {
            AnimalDAL dal = new AnimalDAL();

            dal.Delete(idAnimal);

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
