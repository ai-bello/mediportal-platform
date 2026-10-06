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
    public class PatientRowViewModel
    {
        public Patient? Model { get; set; }
        public ICommand? DeleteCommand { get; set; }
        public ICommand? EditCommand { get; set; }

        public PatientRowViewModel()
        {
            Model = new Patient();
            SetUpCommands();
        }

        public PatientRowViewModel(Patient? model)
        {
            Model = model;
            SetUpCommands();
        }

        private void SetUpCommands()
        {
            DeleteCommand = new Command(DoDelete);
            EditCommand = new Command((p) => DoEdit(p as PatientRowViewModel));
        }

        private void DoDelete()
        {
            if (Model?.Id > 0)
            {
                PatientServiceProxy.Current.Delete(Model.Id);
                Shell.Current.GoToAsync("//PatientsView");
            }
        }

        private void DoEdit(PatientRowViewModel? pvm)
        {
            if (pvm == null)
            {
                return;
            }
            var selectedPatientId = pvm?.Model?.Id ?? 0;
            Shell.Current.GoToAsync($"//AddPatientsView?patientId={selectedPatientId}");
        }
    }
}
