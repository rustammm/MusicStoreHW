using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClassLibrary;


namespace MusicStore
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            products = new List<IProduct>();
            pianos = new List<Piano>();
            guitars = new List<Guitar>();
            MusicStoreInstrumentsGrid.ItemsSource = products;
            
            // MusicStoreInstrumentsGrid.
            //TODO: Show products properly
            // Delete error(is there any handler). Done
            // refreshing.
        }

        private List<IProduct> products;
        private List<Piano> pianos;
        private List<Guitar> guitars;

        private void addGuitarButton_Click(object sender, RoutedEventArgs e)
        {
            Guitar product = new Guitar(products.Count);
            products.Add(product);
            guitars.Add(product);
            MusicStoreInstrumentsGrid.Items.Refresh();

        }

        private void addPianoButton_Click(object sender, RoutedEventArgs e)
        {
            Piano product = new Piano(products.Count);
            products.Add(product);
            pianos.Add(product);
            MusicStoreInstrumentsGrid.Items.Refresh();
        }

        private void dealWithShowCheckboxClicks()
        {
            if (MusicStoreShowGuitarCheckbox.IsChecked == true && MusicStoreShowPianoCheckbox.IsChecked ==true)
            {
                MusicStoreInstrumentsGrid.ItemsSource = products;
                MusicStoreInstrumentsGrid.CanUserDeleteRows = false;
                return;
            }

            MusicStoreInstrumentsGrid.CanUserDeleteRows = true;
            if (MusicStoreShowGuitarCheckbox.IsChecked == true)
            {
                MusicStoreInstrumentsGrid.ItemsSource = guitars;
                return;
            }

            if (MusicStoreShowPianoCheckbox.IsChecked == true)
            {
                MusicStoreInstrumentsGrid.ItemsSource = pianos;
                return;
            }
            MusicStoreInstrumentsGrid.ItemsSource = null;
        }

        private void MusicStoreShowPianoCheckbox_Click(object sender, RoutedEventArgs e)
        {
            dealWithShowCheckboxClicks();
        }

        private void MusicStoreShowGuitarCheckbox_Click(object sender, RoutedEventArgs e)
        {
            dealWithShowCheckboxClicks();
        }

        private void MusicStoreInstrumentsGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.Key == Key.Delete)
            {
                DataGrid grid = (DataGrid)sender;

                if (grid.ItemsSource == products)
                {
                    MessageBox.Show("You can't delete in this view." +
                        " You need to choose either pianos or guitars view in order to delete");
                    return;
                }

                if (grid.SelectedItems.Count > 0)
                {
                    foreach (var row in grid.SelectedItems)
                    {
                        IProduct product = row as IProduct;
                        products.Remove(product);
                    }
                }
            }
        }

        
    }
}
