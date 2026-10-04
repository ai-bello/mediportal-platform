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

	private void AddAppointmentClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//AddAppointmentsView?appointmentId=0");
	}

    private void EditClicked(object sender, EventArgs e)
    {
        var selectedId = (BindingContext as AppointmentViewModel)?.SelectedAppointment?.Id ?? 0;
        if (selectedId != 0)
        {
            Shell.Current.GoToAsync($"//AddAppointmentsView?appointmentId={selectedId}");
        }
    }
   private void DeleteClicked(object sender, EventArgs e)
    {
        (BindingContext as AppointmentViewModel)?.Delete();
    }

    private void AppointmentsView_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as AppointmentViewModel)?.Refresh();
    }
}