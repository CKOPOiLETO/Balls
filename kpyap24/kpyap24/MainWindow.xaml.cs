using System.Windows;
using System.Windows.Controls;

namespace kpyap24
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                button.IsEnabled = false; 
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            foreach (UIElement element in ((Grid)Content).Children)
            {
                if (element is StackPanel stackPanel)
                {
                    foreach (UIElement child in stackPanel.Children)
                    {
                        if (child is Button button)
                        {
                            button.IsEnabled = true; 
                        }
                    }
                }
            }
        }
        private void OpenColorMenu_Click(object sender, RoutedEventArgs e)
        {
            ColorMenuWindow colorMenu = new ColorMenuWindow();
            colorMenu.Show();
        }
    }
}
