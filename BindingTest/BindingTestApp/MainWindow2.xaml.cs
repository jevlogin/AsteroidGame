using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace BindingTestApp
{
    public partial class MainWindow2
    {
        public MainWindow2()
        {
            InitializeComponent();

            var horizontal_binding = new Binding();
            horizontal_binding.ElementName = "HorizontalSlider";
            horizontal_binding.Path = new PropertyPath("Value");
            HorizontalValue.SetBinding(TextBlock.TextProperty, horizontal_binding);

            var vertical_binding = new Binding();
            vertical_binding.ElementName = "VerticalSlider";
            vertical_binding.Path = new PropertyPath("Value");
            VerticalValue.SetBinding(TextBlock.TextProperty, vertical_binding);
        }
    }
}
