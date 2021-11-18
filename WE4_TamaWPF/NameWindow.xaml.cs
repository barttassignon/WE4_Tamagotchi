using System.Windows;

namespace WE4_TamaWPF
{
    /// <summary>
    /// Interaction logic for NameWindow.xaml
    /// </summary>
    public partial class NameWindow : Window
    {
        public string TamaName { get; set; }

        public NameWindow()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Gelieve een naam in te voegen", "Ongeldige invoer.", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                TamaName = txtName.Text;
                DialogResult = true;
                Close();
            }
        }
    }
}
