using Animales.DAL;
using AplicacionTestMVC.Models;
using AplicacionTestMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace AplicacionTestMVC.Controllers
{
    public class AnimalController : Controller
    {
        [HttpGet]
        public IActionResult Index(int idAnimal)
        {
            AnimalDAL dal = new AnimalDAL();
            DetailAnimalViewModel animalDetail = new DetailAnimalViewModel();

            animalDetail.AnimalDetail = dal.GetById(idAnimal);

            return View(animalDetail);
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
    }
}
