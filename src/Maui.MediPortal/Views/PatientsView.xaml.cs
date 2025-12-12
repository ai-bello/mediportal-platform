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
		Shell.Current.GoToAsync("//AddPatientsView");
	}
	private void CancelClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//MainPage");
	}

	private void PatientsView_NavigatedTo(object sender, NavigatedToEventArgs e)
	{
		(BindingContext as PatientViewModel)?.Refresh();
    }
}