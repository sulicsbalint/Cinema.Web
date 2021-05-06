using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Cinema.Desktop.View
{
    /// <summary>
    /// Interaction logic for SeatEditorWindow.xaml
    /// </summary>
    public partial class SeatEditorWindow : Window
    {
        public SeatEditorWindow()
        {
            InitializeComponent();
        }

        private void TextBox_PreviewStatusInput(object sender, TextCompositionEventArgs e)
        {
            TextBox tb = sender as TextBox;
            string full = tb.Text + e.Text;
            Regex regex = new Regex("[^012]");
            if (full.Length > 1)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = regex.IsMatch(e.Text);
            }
        }

        private void TextBox_PreviewPhoneInput(object sender, TextCompositionEventArgs e)
        {
            //if (true)
            //{

            //}
            //TextBox tb = sender as TextBox;
            //string full = tb.Text + e.Text;
            ////Regex regex = new Regex(@"^(\+36[237]0([0 - 9]{ 7 }))");
            Regex regex = new Regex("");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
