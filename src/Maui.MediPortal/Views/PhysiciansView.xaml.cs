namespace Maui.MediPortal.Views;

public partial class PhysiciansView : ContentPage
{
	public PhysiciansView()
	{
		InitializeComponent();
	}
	private void CancelClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//MainPage");
	}
}