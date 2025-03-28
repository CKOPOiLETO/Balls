using kpyap24;
using System;
using System.Windows;

namespace kpyap24
{
    public partial class ColorDialog : Window
    {
        private ColorMenuWindow mainWindow;

        public ColorDialog(ColorMenuWindow main)
        {
            InitializeComponent();
            mainWindow = main;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (byte.TryParse(RedInput.Text, out byte r) &&
                byte.TryParse(GreenInput.Text, out byte g) &&
                byte.TryParse(BlueInput.Text, out byte b))
            {
                mainWindow.SetColor(r, g, b, LeftCheck.IsChecked == true, RightCheck.IsChecked == true);
                Close();
            }
            else
            {
                MessageBox.Show("Enter valid values (0-255) for RGB.", "Error");
            }
        }
    }
}
