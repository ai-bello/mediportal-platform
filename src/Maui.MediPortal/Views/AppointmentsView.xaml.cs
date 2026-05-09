using Maui.MediPortal.ViewModels;

namespace Maui.MediPortal.Views;

public partial class AppointmentsView : ContentPage
{
	public AppointmentsView()
	{
		InitializeComponent();
		BindingContext = new AppointmentViewModel();
	}

	private void CancelClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//MainPage");
	}

	private void AddClicked(object sender, EventArgs e)
	{

	}
}