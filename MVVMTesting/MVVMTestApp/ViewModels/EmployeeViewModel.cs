using MVVMTestApp.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMTestApp.ViewModels
{
    class EmployeeViewModel : ViewModel
    {
        private int _Id;
        private string _SurName;
        private string _Name;
        private string _Patronymic;
        private DateTime _BirthDay;
        public string Name
        {
            get => _Name;
            set => Set(ref _Name, value);
        }
        public int Id
        {
            get => _Id;
            set => Set(ref _Id, value);
        }
        public string SurName
        {
            get => _SurName;
            set => Set(ref _SurName, value);
        }
        public string Patronymic
        {
            get => _Patronymic;
            set => Set(ref _Patronymic, value);
        }
        public DateTime BirthDay
        {
            get => _BirthDay;
            set => Set(ref _BirthDay, value);
        }
        public int Age => (int)Math.Floor((DateTime.Now - BirthDay).TotalDays / 365);


    }
}
