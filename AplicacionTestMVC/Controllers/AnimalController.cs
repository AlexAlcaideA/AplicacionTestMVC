using Animales.DAL;
using AplicacionTestMVC.Models;
using AplicacionTestMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace AplicacionTestMVC.Controllers
{
    public class AnimalController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            string json = TempData["Animal"] as string;

            DetailAnimalViewModel detailAnimal = JsonConvert.DeserializeObject<DetailAnimalViewModel>(json);

            if(detailAnimal == null)
            {
                ViewBag.NoAnimal = "No se ha conseguido encontrar al animal";
            }

            return View(detailAnimal);
        }

        public IActionResult CreateAnimal()
        {
            TipoAnimalDAL dal = new TipoAnimalDAL();

            List<TipoAnimal> listaTipoAnimal = dal.GetAll();

            CreateAnimalViewModel model = new CreateAnimalViewModel
            {
                AnimalTypes = listaTipoAnimal
                    .DistinctBy(x => x.IdTipoAnimal)
                    .ToList()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult InsertCreateAnimal(CreateAnimalViewModel animalToCreate)
        {
            AnimalDAL dal = new AnimalDAL();

            dal.Insert(animalToCreate.CreatedAnimal);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult EditAnimal()
        {
            AnimalDAL dalAnimal = new AnimalDAL();
            TipoAnimalDAL dalTipoAnimal = new TipoAnimalDAL();

            string json = TempData["Animal"] as string;

            EditAnimalViewModel model = JsonConvert.DeserializeObject<EditAnimalViewModel>(json);

            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateEditAnimal(EditAnimalViewModel animalToEdit)
        {
            AnimalDAL dal = new AnimalDAL();

            dal.Update(animalToEdit.EditedAnimal);

            return RedirectToAction("Index", "Home");
        }
    }
}
