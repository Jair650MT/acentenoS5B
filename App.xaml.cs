using acentenoS5B.Model;

namespace acentenoS5B
{
    public partial class App : Application
    {
        public static PersonaRepository personRepo { get; set; }
        public App(PersonaRepository personaRepository)
        {
            InitializeComponent();

            MainPage = new Views.Principal();
            personRepo = personaRepository;
        }
    }
}
