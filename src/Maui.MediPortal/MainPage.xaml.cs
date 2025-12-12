using Maui.MediPortal.ViewModels;

namespace Maui.MediPortal;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
		BindingContext = new MainViewModel();
	}

	private void ManagePatientsClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//PatientsView");
	}

	private void ManagePhysiciansClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//PhysiciansView");
	}

	private void ManageAppointmentsClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//AppointmentsView");
	}
	
}

