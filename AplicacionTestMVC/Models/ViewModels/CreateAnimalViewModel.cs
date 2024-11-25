namespace AplicacionTestMVC.Models.ViewModels
{
    public class CreateAnimalViewModel
    {
        public Animal CreatedAnimal { get; set; } = new Animal();
        public List<TipoAnimal> AnimalTypes { get; set; } = new List<TipoAnimal>();
    }
}
