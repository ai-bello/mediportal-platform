using Maui.MediPortal.ViewModels;
using Library.MediPortal.Services;
using Library.MediPortal.Models;

namespace Maui.MediPortal.Views;

[QueryProperty(nameof(AppointmentId), "appointmentId")]
public partial class AddAppointmentsView : ContentPage
{
	public AddAppointmentsView()
	{
		InitializeComponent();
		BindingContext = new AppointmentViewModel();
	}

	public int AppointmentId { get; set; }

	private async void SaveClicked(object sender, EventArgs e)
	{
		if (BindingContext is not AppointmentViewModel viewModel)
			return;
		if (viewModel.SelectedPhysician == null||viewModel.SelectedPatient == null||viewModel.SelectedDate==null||viewModel.SelectedTime==null)
		{
			await DisplayAlert("Missing information",
			"Select a patient, physician, and date.","OK");
            return;
        }
		var appointment = new Appointment
		{
			Id =AppointmentId,
			Patient = viewModel.SelectedPatient,
			Physician = viewModel.SelectedPhysician,
			PatientId = viewModel.SelectedPatient.Id,
			PhysicianId = viewModel.SelectedPhysician.Id,
			DateTime = viewModel.SelectedDate.Value.Date.Add(viewModel.SelectedTime.Value)
		};

		var savedAppointment = AppointmentServiceProxy.Current.Create(appointment);
        if(savedAppointment != null) 
			await Shell.Current.GoToAsync("//AppointmentsView");
    }

    private void CancelClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//AppointmentsView");
	}
    private void AddAppointmentsView_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
		if(AppointmentId==0)
		{
            BindingContext = new AppointmentViewModel();
        } else
		{
			BindingContext = new AppointmentViewModel(AppointmentId);
		}
		

    }
}