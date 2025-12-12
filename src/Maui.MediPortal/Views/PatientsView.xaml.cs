using System.ComponentModel;
using Maui.MediPortal.ViewModels;

namespace Maui.MediPortal.Views;

public partial class PatientsView : ContentPage
{
	public PatientsView()
	{
		InitializeComponent();
		BindingContext = new PatientViewModel();
	}

	private void AddPatientClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//AddPatientsView?patientId=0");
	}

	private void EditPatientClicked(object sender, EventArgs e)
	{
		var selectedId = (BindingContext as PatientViewModel)?.SelectedPatient?.Id ?? 0;
		if (selectedId != 0)
		{
			Shell.Current.GoToAsync($"//AddPatientsView?patientId={selectedId}");
		}
		
	}
	private void CancelClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//MainPage");
	}

	private void PatientsView_NavigatedTo(object sender, NavigatedToEventArgs e)
	{
		(BindingContext as PatientViewModel)?.Refresh();
	}
	
	private void DeletePatientClicked(object sender, EventArgs e)
	{
		(BindingContext as PatientViewModel)?.Delete();
	}
}