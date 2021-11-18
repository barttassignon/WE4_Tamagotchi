using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using WE4_Tamagotchi;

namespace WE4_TamaWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public readonly Tamagotchi tamagotchi;
        private readonly BitmapImage doodImage;
        private readonly BitmapImage seniorImage;
        private readonly BitmapImage eiImage;
        private readonly BitmapImage babyImage;
        private readonly BitmapImage kindImage;
        private readonly BitmapImage puberImage;
        private readonly BitmapImage volwassenImage;


        public MainWindow()
        {
            InitializeComponent();

            // initialiseren images
            eiImage = InitImage(Properties.Resources.tamagotchi_ei);
            babyImage = InitImage(Properties.Resources.tamagotchi_baby);
            kindImage = InitImage(Properties.Resources.tamagotchi_kind);
            puberImage = InitImage(Properties.Resources.tamagotchi_puber);
            volwassenImage = InitImage(Properties.Resources.tamagotchi_volwassen);
            seniorImage = InitImage(Properties.Resources.tamagotchi_volwassen);
            doodImage = InitImage(Properties.Resources.tamagotchi_dood);

            NameWindow nameWindow = new NameWindow();

            if (nameWindow.ShowDialog().GetValueOrDefault())
            {
                tamagotchi = new Tamagotchi(nameWindow.TamaName);
                UpdateGUI();
                tamagotchi.LevensstadiumChangedEvent += Tamagotchi_LevensstadiumChangedEvent;
                tamagotchi.ParameterChangedEvent += Tamagotchi_ParameterChangedEvent;
            }
            else
            {
                Close();
            }
        }



        // deel 3
        private void UpdateGUI()
        {
            lblNaam.Content = tamagotchi.Naam;
            lblLevensstadium.Content = tamagotchi.Levensstadium;
            lblGeluk.Content = tamagotchi.Geluk;
            lblHonger.Content = tamagotchi.Honger;
            lblIntelligentie.Content = tamagotchi.Intelligentie;

        }

        private BitmapImage InitImage(byte[] imageData)
        {
            var image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = new MemoryStream(imageData);
            image.EndInit();

            return image;
        }

        private void Tamagotchi_LevensstadiumChangedEvent(Levensstadium levensstadium)
        {
            var newImage = levensstadium switch
            {
                Levensstadium.Ei => eiImage,
                Levensstadium.Kind => kindImage,
                Levensstadium.Puber => puberImage,
                Levensstadium.Volwassen => volwassenImage,
                Levensstadium.Senior => volwassenImage,
                Levensstadium.Dood => doodImage,
                _ => volwassenImage,
            };

            Dispatcher.Invoke(() =>
            {
                imgTamagotchi.Source = newImage;
                if (Levensstadium.Dood == levensstadium)
                {
                    btnEten.IsEnabled = false;
                    btnLeren.IsEnabled = false;
                    btnSpelen.IsEnabled = false;
                }
            });
        }

        private void Tamagotchi_ParameterChangedEvent()
        {
            Dispatcher.Invoke(() => UpdateGUI());
        }

        private void btnSpelen_Click(object sender, RoutedEventArgs e)
        {
            tamagotchi.Geluk++;
            UpdateGUI();
        }

        private void btnEten_Click(object sender, RoutedEventArgs e)
        {
            tamagotchi.Honger++;
            UpdateGUI();
        }

        private void btnLeren_Click(object sender, RoutedEventArgs e)
        {
            tamagotchi.Intelligentie++;
            UpdateGUI();
        }
    }
}
