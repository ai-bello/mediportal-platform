using System.Security.AccessControl;
using Library.MediPortal;
using Library.MediPortal.Services;

namespace Maui.MediPortal.Views;

public partial class AddPatientsView : ContentPage
{
	public AddPatientsView()
	{
		InitializeComponent();
	}

	private void CancelClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//PatientsView");
	}
	private void SaveClicked(object sender, EventArgs e)
	{
		PatientServiceProxy.Current.Create(BindingContext as Patient);
		//go back to PatientsView
		Shell.Current.GoToAsync("//PatientsView");

	}

	private void AddPatientsView_NavigatedTo(object sender, NavigatedToEventArgs e)
	{
		BindingContext = new Patient();
    }
}