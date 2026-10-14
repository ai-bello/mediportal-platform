using Library.MediPortal.Models;
using Library.MediPortal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Maui.MediPortal.ViewModels
{
    public class PhysicianRowViewModel
    {
        public Physician? Model { get; set; }
        public ICommand? DeleteCommand { get; set; }
        public ICommand? EditCommand { get; set; }

        public PhysicianRowViewModel()
        {
            Model = new Physician();
            SetUpCommands();
        }

        public PhysicianRowViewModel(Physician? model)
        {
            Model = model;
            SetUpCommands();
        }


        private void SetUpCommands()
        {
            DeleteCommand = new Command(DoDelete);
            EditCommand = new Command((p) => DoEdit(p as PhysicianRowViewModel));
        }

        private void DoDelete()
        {
            if (Model?.Id > 0)
            {
                PhysicianServiceProxy.Current.Delete(Model.Id);
                Shell.Current.GoToAsync("//PhysiciansView");
            }
        }

        private void DoEdit(PhysicianRowViewModel? pvm)
        {
            if (pvm == null)
            {
                return;
            }
            var selectedPhysicianId = pvm?.Model?.Id ?? 0;
            Shell.Current.GoToAsync($"//AddPhysiciansView?physicianId={selectedPhysicianId}");
        }
    }
}
