namespace AplicacionTestMVC.Models.ViewModels
{
    public class AnimalViewModel
    {
        public List<Animal> Animales { get; set; } = new List<Animal>();
        //public List<string> Animales { get; set; } = new List<string>();

        public AnimalViewModel() 
        {
            /*Animales = new List<string>
            {
                "Elefante",
                "Tigre",
                "León",
                "Jirafa",
                "Rinoceronte",
                "Oso Panda",
                "Koala",
                "Cephalopodo",
                "Canguro",
                "Águila"
            };*/
        }
    }
}
