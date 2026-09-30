using Maui.MediPortal.ViewModels;

namespace Maui.MediPortal.Views;


public partial class AddAppointmentsView : ContentPage
{
	public AddAppointmentsView()
	{
		InitializeComponent();
		BindingContext = new AppointmentViewModel();
	}
}