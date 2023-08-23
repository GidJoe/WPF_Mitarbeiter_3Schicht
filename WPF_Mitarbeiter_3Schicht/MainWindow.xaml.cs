using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using BusinessLayerSec;

namespace WPF_Mitarbeiter_3Schicht
{
    public partial class MainWindow : Window
    {
        private readonly DataAccessLayer _businessLayer;
        ObservableCollection<Mitarbeiter> mitarbeiters;
        ICollectionView collectionView;

        public MainWindow()
        {
            InitializeComponent();


            _businessLayer = new DataAccessLayer();

            LoadData();
        }

        private void LoadData()
        {
            // Hole alle Mitarbeiter aus der Datenbank über die BusinessLayer
            mitarbeiters = new ObservableCollection<Mitarbeiter>(_businessLayer.GetAllMitarbeiter());

            // Datenquelle für das DataGrid festlegen
            mitarbeiterDataGrid.ItemsSource = mitarbeiters;
                        
            // Erstellen einer CollectionView für die Hauptmitarbeiterliste.
            collectionView = CollectionViewSource.GetDefaultView(mitarbeiterDataGrid.ItemsSource);
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (collectionView != null)
            {
                collectionView.Filter = (obj) =>
                {
                    if (String.IsNullOrEmpty(SearchBox.Text))
                        return true;

                    Mitarbeiter mitarbeiter = obj as Mitarbeiter;


                    return (mitarbeiter.Vorname.Contains(SearchBox.Text, StringComparison.OrdinalIgnoreCase) ||
                            mitarbeiter.Nachname.Contains(SearchBox.Text, StringComparison.OrdinalIgnoreCase) ||
                            mitarbeiter.Geburtstag.Contains(SearchBox.Text, StringComparison.OrdinalIgnoreCase) ||
                            mitarbeiter.Strasse.Contains(SearchBox.Text, StringComparison.OrdinalIgnoreCase) ||
                            mitarbeiter.Hausnummer.Contains(SearchBox.Text, StringComparison.OrdinalIgnoreCase) ||
                            mitarbeiter.Krankenkasse.Contains(SearchBox.Text, StringComparison.OrdinalIgnoreCase) ||
                            mitarbeiter.Parkplatz.Contains(SearchBox.Text, StringComparison.OrdinalIgnoreCase) ||
                            mitarbeiter.Steuerklasse.Contains(SearchBox.Text, StringComparison.OrdinalIgnoreCase) ||
                            mitarbeiter.Urlaubstage.ToString().Contains(SearchBox.Text) ||
                            mitarbeiter.Krankheitstage.ToString().Contains(SearchBox.Text) ||
                            mitarbeiter.Gehalt.ToString().Contains(SearchBox.Text));
                };
            }
        }


        private void Button_Add(object sender, RoutedEventArgs e)
        {
            var addWindow = new WPF_Mitarbeiter_3Schicht.WindowAddMitarbeiter();
            var wasNewItemAdded = addWindow.ShowDialog();

            // Wenn DialogResult true ist, dann wurde ein neues Item hinzugefügt.
            if (wasNewItemAdded.HasValue && wasNewItemAdded.Value)
            {
                RefreshData();
            }
        }

        private void RefreshData()
        {
            
            mitarbeiters = new ObservableCollection<Mitarbeiter>(_businessLayer.GetAllMitarbeiter());

            // Update DataGrid's ItemsSource.
            
            mitarbeiterDataGrid.ItemsSource = mitarbeiters;

            // Update CollectionView quelle
            
            collectionView = CollectionViewSource.GetDefaultView(mitarbeiterDataGrid.ItemsSource);
        }



        private void BTN_Remove(object sender, RoutedEventArgs e)
        {
            
            var selectedMitarbeiter = mitarbeiterDataGrid.SelectedItem as Mitarbeiter;

            if (selectedMitarbeiter != null)
            {
                
                var result = MessageBox.Show("Wirklich löschen?", "Löschen bestätigen", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    
                    _businessLayer.DeleteMitarbeiter(selectedMitarbeiter.MID);
                                        
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Bitte wählen Sie einen Eintrag zum Löschen aus.", "Keine Auswahl getroffen", MessageBoxButton.OK, MessageBoxImage.Information);
                
            }
        }

    }
}