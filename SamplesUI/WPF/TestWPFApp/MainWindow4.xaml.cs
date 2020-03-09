using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для MainWindow4.xaml
    /// </summary>
    public partial class MainWindow4 : Window
    {
        public MainWindow4()
        {
            InitializeComponent();
        }
        private void btnClickMe_Click(object sender, RoutedEventArgs e)
        {
            //lbResult.Items.Add(pnlMain.FindResource("strPanel").ToString());
            //lbResult.Items.Add(this.FindResource("strWindow").ToString());
            //lbResult.Items.Add(Application.Current.FindResource("strApp").ToString());
            //  В принципе, поиск ресурсов в предыдущем примере можно выполнять всегда на уровне панели. 
            //  Пока не ясно почему..
            lbResult.Items.Add(pnlMain.FindResource("strPanel").ToString());
            lbResult.Items.Add(pnlMain.FindResource("strWindow").ToString());
            lbResult.Items.Add(pnlMain.FindResource("strApp").ToString());

        }
    }
}
