namespace AplicacionTestMVC.Models.ViewModels
{
    public class EditAnimalViewModel
    {
        public Animal EditedAnimal { get; set; } = new Animal();
        public List<TipoAnimal> AnimalTypes { get; set; } = new List<TipoAnimal>();
    }
}
