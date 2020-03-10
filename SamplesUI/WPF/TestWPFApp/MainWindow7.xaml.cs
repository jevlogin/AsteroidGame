using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TestWPFApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow7.xaml
    /// </summary>
    public partial class MainWindow7 : Window
    {
        ObservableCollection<Employee> items = new ObservableCollection<Employee>();
        public MainWindow7()
        {
            InitializeComponent();
            FillList();
        }

        private void FillList()
        {
            items.Add(new Employee() { Id = 1, Name = "Константин", Age = 28, Salary = 3000 });
            items.Add(new Employee() { Id = 1, Name = "Максим", Age = 26, Salary = 3000 });
            items.Add(new Employee() { Id = 1, Name = "Олег", Age = 30, Salary = 3000 });
            LbEmployee.ItemsSource = items;
        }

        private void LbEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
