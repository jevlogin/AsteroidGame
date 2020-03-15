using MVVMTestApp.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MVVMTestApp.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        private string _Title = "Заголовок окна проекта MVVM";
        public string Title
        {
            get
            {
                return _Title;
            }
            //set
            //{
            //    if (Equals(_Title, value)) return;
            //    _Title = Title;
            //    OnPropertyChanged(nameof(Title));
            //}
            set => Set(ref _Title, value);
        }

        private ObservableCollection<EmployeeViewModel> _Employees = new ObservableCollection<EmployeeViewModel>();

        public ObservableCollection<EmployeeViewModel> Employees
        {
            get => _Employees;
            set => Set(ref _Employees, value);
        }
        private EmployeeViewModel _SelectedEmployee;
        public EmployeeViewModel SelectedEmployee
        {
            get => _SelectedEmployee;
            set => Set(ref _SelectedEmployee, value);
        }
        public MainWindowViewModel()
        {
            foreach (var employee in Enumerable.Range(1, 100).Select(i => new EmployeeViewModel
            {
                Id = i,
                Name = $"Имя {i}",
                SurName = $"Фамилия {i}",
                Patronymic = $"Отчество {i}",
                BirthDay = DateTime.Now
            }))
            {
                _Employees.Add(employee);
            }
        }
    }
}
