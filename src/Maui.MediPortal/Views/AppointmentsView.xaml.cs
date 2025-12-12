namespace Maui.MediPortal.Views;

public partial class AppointmentsView : ContentPage
{
	public AppointmentsView()
	{
		InitializeComponent();
	}

	private void CancelClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//MainPage");
	}
}