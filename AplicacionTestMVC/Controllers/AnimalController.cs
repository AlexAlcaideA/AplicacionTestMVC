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

        [HttpPost]
        public IActionResult CreateAnimal(CreateAnimalViewModel animalToCreate)
        {
            ModelState.Remove("CreatedAnimal.TipoDeAnimal.TipoDescripcion");


            if (ModelState.IsValid)
            {
                AnimalDAL dalAnimal = new AnimalDAL();

                dalAnimal.Insert(animalToCreate.CreatedAnimal);

                return RedirectToAction("Index", "Home");
            }

            TipoAnimalDAL dal = new TipoAnimalDAL();

            List<TipoAnimal> listaTipoAnimal = dal.GetAll();

            CreateAnimalViewModel model = new CreateAnimalViewModel
            {
                AnimalTypes = listaTipoAnimal
            };

            ViewBag.Error = "No se ha posido crear el animal.";

            return View(model);
        }

        
        public IActionResult InsertCreateAnimal(CreateAnimalViewModel animalToCreate)
        {
            if(ModelState.IsValid)
            {
                AnimalDAL dal = new AnimalDAL();

                dal.Insert(animalToCreate.CreatedAnimal);

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "No se ha posido crear el animal.";

            return RedirectToAction("CreateAnimal");
        }

        [HttpGet]
        public IActionResult EditAnimal()
        {
            TipoAnimalDAL dalTipoAnimal = new TipoAnimalDAL();

            string json = TempData["Animal"] as string;

            EditAnimalViewModel model = JsonConvert.DeserializeObject<EditAnimalViewModel>(json);

            model.AnimalTypes = dalTipoAnimal.GetAll();

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
