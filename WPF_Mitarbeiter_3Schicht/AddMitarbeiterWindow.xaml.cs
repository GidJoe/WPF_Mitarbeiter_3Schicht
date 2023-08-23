using System.Windows;

namespace WPF_Mitarbeiter_3Schicht
{
    public partial class WindowAddMitarbeiter : Window
    {
        DataAccessLayer _dataAccess = new DataAccessLayer();

        public WindowAddMitarbeiter()
        {
            InitializeComponent();
        }

        private void BTN_Add(object sender, RoutedEventArgs e)
        {
            Mitarbeiter newMitarbeiter = new Mitarbeiter
            {
                Vorname = VornameTextBox.Text,
                Nachname = NachnameTextBox.Text,
                Geburtstag = GeburtstagTextBox.Text,
                Age = int.Parse(AgeTextBox.Text),
                Strasse = StrasseTextBox.Text,
                Hausnummer = HausnummerTextBox.Text,
                Urlaubstage = double.Parse(UrlaubstageTextBox.Text),
                Krankheitstage = int.Parse(KrankheitstageTextBox.Text),
                Gehalt = double.Parse(GehaltTextBox.Text),
                Krankenkasse = KrankenkasseTextBox.Text,
                Parkplatz = ParkplatzTextBox.Text,
                Steuerklasse = SteuerklasseTextBox.Text
            };

            _dataAccess.AddMitarbeiter(newMitarbeiter);

            this.DialogResult = true;
            this.Close();
        }

        private void BTN_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
