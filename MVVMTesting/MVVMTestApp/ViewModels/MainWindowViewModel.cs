using MVVMTestApp.ViewModels.Base;
using System;
using System.Collections.Generic;
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

        public MainWindowViewModel()
        {
           
        }
    }
}
