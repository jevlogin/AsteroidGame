using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для MainWindow2.xaml
    /// </summary>
    public partial class MainWindow2 : Window
    {
        public MainWindow2()
        {
            InitializeComponent();
        }

        private void OpenFileHandler(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Title = "Выбор файла",
                Filter = "*.txt|*txt"
            };
            if (dialog.ShowDialog() != true)
            {
                return;
            }
            var file_path = dialog.FileName;
            if (!File.Exists(file_path))
            {
                return;
            }
            var file_text = File.ReadAllText(file_path);
            TextEditor.Text = file_text;
        }

        private void OnMouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is Button button)
            {
                button.Background = Brushes.Red;
            }
        }
        private void OnMouseExit(object sender, MouseEventArgs e)
        {
            if (sender is Button button)
            {
                button.Background = Brushes.Blue;
            }
        }

        private void ExitHandler(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
