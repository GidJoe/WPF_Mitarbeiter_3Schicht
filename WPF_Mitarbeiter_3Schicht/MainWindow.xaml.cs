using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using BusinessLayerSec;  // Ensure you include the necessary namespaces

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

            // Provide the path to your database when initializing
            _businessLayer = new DataAccessLayer();

            LoadData();
        }

        private void LoadData()
        {
            // Get data from the business layer
            mitarbeiters = new ObservableCollection<Mitarbeiter>(_businessLayer.GetAllMitarbeiter());

            // Set the data source for the DataGrid
            mitarbeiterDataGrid.ItemsSource = mitarbeiters;

            // Create a CollectionView for the main employee list.
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

                    // Adjust and expand the filtering to cover all columns
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
    }
}