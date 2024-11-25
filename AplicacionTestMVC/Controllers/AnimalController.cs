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

            List<DetailAnimalViewModel> listaAnimales = listaTipoAnimal
            .GroupBy(x => new { x.IdTipoAnimal})
            .Where(g => g.Count() > 1)
            .Select(g =>
            {
                // Creamos la instancia de DetailAnimalViewModel
                var detalle = new DetailAnimalViewModel();

                // Asignamos valores al objeto Animal dentro de AnimalDetail
                detalle.AnimalDetail.TipoDeAnimal = dal.GetById(g.Key.IdTipoAnimal);

                return detalle;
            })
            .ToList();

            return View(listaTipoAnimal);
        }

        [HttpPost]
        public IActionResult InsertCreateAnimal(DetailAnimalViewModel animalToCreate)
        {
            AnimalDAL dal = new AnimalDAL();
            DetailAnimalViewModel animalDetail = new DetailAnimalViewModel
            {
                AnimalDetail = animalToCreate.AnimalDetail
            };

            return RedirectToAction("Index", "Home");
        }
    }
}
