using System.Security.AccessControl;
using Library.MediPortal;
using Library.MediPortal.Services;
using Library.MediPortal.Models;
namespace Maui.MediPortal.Views;

[QueryProperty(nameof(PhysicianId), "physicianId")]
public partial class AddPhysiciansView : ContentPage
{
	public AddPhysiciansView()
	{
		InitializeComponent();
	}
	public int PhysicianId { get; set; }
	private void CancelClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//PhysiciansView");
	}
	private void SaveClicked(object sender, EventArgs e)
	{
		PhysicianServiceProxy.Current.Create(BindingContext as Physician);
		//go back to PhysiciansView
		Shell.Current.GoToAsync("//PhysiciansView");

	}

	private void AddPhysiciansView_NavigatedTo(object sender, NavigatedToEventArgs e)
	{
		if (PhysicianId == 0)
		{
			BindingContext = new Physician();
		}
		else
		{
			BindingContext = new Physician(PhysicianId);
		}

	}
}