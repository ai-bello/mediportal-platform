namespace Maui.MediPortal.Views;

public partial class PatientsView : ContentPage
{
	public PatientsView()
	{
		InitializeComponent();
	}

	private void AddPatientClicked(object sender, EventArgs e)
	{

	}
	private void CancelClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//MainPage");
	}
}