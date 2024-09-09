namespace PassportDetailsTEB
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnEntryNumerTextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateImages();
        }

        private void OnOkButtonClicked(object sender, EventArgs e)
        {
            string imie = EntryImie.Text;
            string nazwisko = EntryNazwisko.Text;
            string kolorOczu = RadioNiebieskie.IsChecked ? "niebieskie" :
                RadioZielone.IsChecked ? "zielone" : "piwne";

            if (string.IsNullOrWhiteSpace(imie) || string.IsNullOrWhiteSpace(nazwisko))
            {
                DisplayAlert("Błąd", "Wprowadź dane", "OK");
            }
            else
            {
                DisplayAlert("Dane paszportowe", $"{imie} {nazwisko} kolor oczu {kolorOczu}", "OK");
                UpdateImages();
            }
        }

        private void UpdateImages()
        {
            string numer = EntryNumer.Text;
            string projectDirectory = @"C:\Users\admin\source\repos\PassportDetailsTEB\PassportDetailsTEB";
            string zdjeciePath = Path.Combine(projectDirectory, "Resources", "Images", $"zdjecie{numer}.png");
            string odciskPath = Path.Combine(projectDirectory, "Resources", "Images", $"odcisk{numer}.png");
            string nullzdjecie = Path.Combine(projectDirectory, "Resources", "Images", "nullzdjecie.jpg");
            string nullodcisk = Path.Combine(projectDirectory, "Resources", "Images", "nullodcisk.png");

            if (File.Exists(zdjeciePath))
            {
                ImageZdjecie.Source = ImageSource.FromFile(zdjeciePath);
            }
            else
            {
                ImageZdjecie.Source = ImageSource.FromFile(nullzdjecie);
            }

            if (File.Exists(odciskPath))
            {
                ImageOdcisk.Source = ImageSource.FromFile(odciskPath);
            }
            else
            {
                ImageOdcisk.Source = ImageSource.FromFile(nullodcisk);
            }
        }
    }

}
