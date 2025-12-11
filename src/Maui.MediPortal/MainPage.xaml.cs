using Maui.MediPortal.ViewModels;

namespace Maui.MediPortal;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
		BindingContext = new MainViewModel();
	}

	private void AddPatientClicked(object sender, EventArgs e)
	{
		
	}
	
}

