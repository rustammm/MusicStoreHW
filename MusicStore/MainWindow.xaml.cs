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
using System.IO;
using ClassLibrary;
using System.Runtime.Serialization.Formatters.Binary;

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
            getSerializedData();
            MusicStoreInstrumentsGrid.ItemsSource = storeData.products;
            dealWithShowCheckboxClicks();

            // MusicStoreInstrumentsGrid.
            //TODO: Show products properly
            // Delete error(is there any handler). Done
            // refreshing.
        }

        private string serializedDataPath = "storeData.bin";
        private StoreData storeData;
        
        private void addGuitarButton_Click(object sender, RoutedEventArgs e)
        {
            Guitar product = new Guitar(storeData.products.Count);
            storeData.products.Add(product);
            storeData.guitars.Add(product);
            MusicStoreInstrumentsGrid.Items.Refresh();

        }
        
        private void addPianoButton_Click(object sender, RoutedEventArgs e)
        {
            Piano product = new Piano(storeData.products.Count);
            storeData.products.Add(product);
            storeData.pianos.Add(product);
            MusicStoreInstrumentsGrid.Items.Refresh();
        }

        private void dealWithShowCheckboxClicks()
        {
            if (MusicStoreShowGuitarCheckbox.IsChecked == true && MusicStoreShowPianoCheckbox.IsChecked ==true)
            {
                MusicStoreInstrumentsGrid.ItemsSource = storeData.products;
                MusicStoreInstrumentsGrid.CanUserDeleteRows = false;
                return;
            }

            MusicStoreInstrumentsGrid.CanUserDeleteRows = true;
            if (MusicStoreShowGuitarCheckbox.IsChecked == true)
            {
                MusicStoreInstrumentsGrid.ItemsSource = storeData.guitars;
                return;
            }

            if (MusicStoreShowPianoCheckbox.IsChecked == true)
            {
                MusicStoreInstrumentsGrid.ItemsSource = storeData.pianos;
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

                if (grid.ItemsSource == storeData.products)
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
                        storeData.products.Remove(product);
                    }
                }
            }

            foreach (DataGridColumn column in MusicStoreInstrumentsGrid.Columns)
            {
                if (column.Header.Equals("ID"))
                {
                    column.IsReadOnly = true;
                }
            }

        }


        private void serializeData()
        {
            //TODO: Ask
            // var result = MessageBoxResult.OK.("Do you want to save it");
            try
            {
                using (Stream stream = File.Open(serializedDataPath, FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, storeData);
                }
            }
            catch (IOException)
            {
                Console.WriteLine("MusicStore Serialization | Trying to write to a file, an error occured");
            }
        }


        private void getSerializedData()
        {
            try
            {
                using (Stream stream = File.Open(serializedDataPath, FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    
                    storeData = (StoreData)bin.Deserialize(stream);
                }
            }
            catch (IOException)
            {
                storeData = new StoreData();
                Console.WriteLine("MusicStore Serialization | Trying to read to a file, an error occured");
            }
        }

        private void MusicStoreMainWindow_Closed(object sender, EventArgs e)
        {
            serializeData();
        }

        private void MusicSaveButton_Click(object sender, RoutedEventArgs e)
        {
            serializeData();
            MessageBox.Show("Your data is saved");
        }

        private void MusicStoreCalculateButton_Click(object sender, RoutedEventArgs e)
        {
            DataGrid grid = MusicStoreInstrumentsGrid;
            long sum = 0;
            if (grid.SelectedItems.Count > 0)
            {
                foreach (var row in grid.SelectedItems)
                {
                    IProduct product = row as IProduct;
                    sum += product.getPrice();
                }
            }
            MessageBox.Show("Selected total is " + sum);

        }
    }
}
