using Maui.MediPortal.ViewModels;

namespace Maui.MediPortal.Views;

public partial class PhysiciansView : ContentPage
{
	public PhysiciansView()
	{
		InitializeComponent();
		BindingContext = new PhysicianViewModel();
	}
	private void AddClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//AddPhysiciansView?physicianId=0");
	}

	private void EditClicked(object sender, EventArgs e)
	{
		var selectedId = (BindingContext as PhysicianViewModel)?.SelectedPhysician?.Id ?? 0;
		if (selectedId != 0)
		{
			Shell.Current.GoToAsync($"//AddPhysiciansView?physicianId={selectedId}");
		}
		
	}
	private void CancelClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//MainPage");
	}

	private void PhysiciansView_NavigatedTo(object sender, NavigatedToEventArgs e)
	{
		(BindingContext as PhysicianViewModel)?.Refresh();
	}
	
	private void DeleteClicked(object sender, EventArgs e)
	{
		(BindingContext as PhysicianViewModel)?.Delete();
	}
}