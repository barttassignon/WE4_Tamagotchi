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


            // TODO: naam vragen aan speler
            // nameWindow nameWindow = new NameWindow();

            tamagotchi = new Tamagotchi();

            UpdateGUI();
            tamagotchi.Honger--;

        }



        // deel 3
        private void UpdateGUI()
        {
            lblNaam.Content = tamagotchi.Naam;
            lblLevensstadium.Content = tamagotchi.Levensstadium;
            lblGeluk.Content = tamagotchi.Geluk;
            lblHonger.Content = tamagotchi.Honger;
            lblIntelligentie.Content = tamagotchi.Intelligentie;
            imgFoto.Source = eiImage;
        }

        private BitmapImage InitImage(byte[] imageData)
        {
            var image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = new MemoryStream(imageData);
            image.EndInit();

            return image;
        }
    }
}
