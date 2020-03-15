using EmployeesManager.Data;
using System.Windows.Controls;

namespace EmployeesManager
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            //EmployeesList.Items.Add(new ListViewItem());  //  так не эффективно.
            //EmployeesList.ItemsSource = TestData.Employees; //  также малоэффективно...

        }
    }
}
