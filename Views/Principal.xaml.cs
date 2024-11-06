using acentenoS5B.Model;

namespace acentenoS5B.Views;

public partial class Principal : ContentPage
{
	public Principal()
	{
		InitializeComponent();
	}
    private void RefreshList()
    {
        List<Persona> personas = App.personRepo.GetAllPeople();
        listPersona.ItemsSource = personas;
    }
    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
        lblStatusMessage.Text = " ";
        App.personRepo.addNewPerson(txtNombre.Text);
        lblStatusMessage.Text = App.personRepo.statusMessage;
    }

    private void btnObtener_Clicked(object sender, EventArgs e)
    {
        lblStatusMessage.Text = " ";

        List<Persona> personas = App.personRepo.GetAllPeople();
        listPersona.ItemsSource= personas;
    }

    private async void Button_Editar_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var person = button?.CommandParameter as Persona;
        if (person == null) return;

        string newName = await DisplayPromptAsync("Editar Persona", "Ingrese el nuevo nombre:", initialValue: person.Nombre);
        if (!string.IsNullOrWhiteSpace(newName))
        {
            App.personRepo.UpdatePerson(person.Id, newName);
            lblStatusMessage.Text = App.personRepo.statusMessage;
            RefreshList(); // Refresca la lista después de la edición
        }
    }

    private async void Button_Eliminar_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        int personId = (int)button?.CommandParameter;

        bool confirm = await DisplayAlert("Confirmar Eliminación", "¿Está seguro de eliminar esta persona?", "Sí", "No");
        if (confirm)
        {
            App.personRepo.DeletePerson(personId);
            lblStatusMessage.Text = App.personRepo.statusMessage;
            RefreshList(); // Refresca la lista después de la eliminación
        }
    }
}