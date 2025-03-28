using System;
using System.Windows;
using System.Windows.Media;

namespace kpyap24
{
    public partial class ColorMenuWindow : Window
    {
        private byte red = 255, green = 255, blue = 255;
        private bool changeLeft = false, changeRight = false;

        public ColorMenuWindow()
        {
            InitializeComponent();
        }

        private void InputColor_Click(object sender, RoutedEventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog(this);
            colorDialog.ShowDialog();
        }

        private void ChangeColor_Click(object sender, RoutedEventArgs e)
        {
            Color newColor = Color.FromRgb(red, green, blue);
            SolidColorBrush brush = new SolidColorBrush(newColor);

            if (changeLeft) LeftPanel.Background = brush;
            if (changeRight) RightPanel.Background = brush;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Use 'Input color' to set a color, then 'Change' to apply it.", "Help");
        }

        public void SetColor(byte r, byte g, byte b, bool left, bool right)
        {
            red = r;
            green = g;
            blue = b;
            changeLeft = left;
            changeRight = right;
        }
    }
}
