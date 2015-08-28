using ListViewExample.DataModel;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.ComponentModel;
using System.Collections.Specialized;

namespace ListViewExample
{

    public sealed partial class MainPage : Page
    {
        public ObservableCollection<Address> AddressItems { get; set; }

        public MainPage()
        {
            //I hardcoded two locations for this demo
            Address address1 = new Address();
            address1.City = "Munich";
            address1.Name = "Hoover & Floyd";
            Address address2 = new Address();
            address2.City = "Munich";
            address2.Name = "Lola Bar";
            

            AddressItems = new ObservableCollection<Address>();
            AddressItems.CollectionChanged += ContentCollectionChanged;
            AddressItems.Add(address1);
            AddressItems.Add(address2);

            this.InitializeComponent();
            DataContext = this;
            
        }

        /// <summary>
        /// Registers and unregisters items inside collection for property changes. 
        /// Added items will fire <seealso cref="addressChanged(object sender, PropertyChangedEventArgs e)">addressChanged</seealso> when a property was changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContentCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (Address item in e.OldItems)
                {
                    //Removed items
                    item.PropertyChanged -= addressChanged;
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (Address item in e.NewItems)
                {
                    //Added items
                    item.PropertyChanged += addressChanged;
                }
            }
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //TODO React when an item is selected
            Debug.WriteLine("Selection changed");
        }

        /// <summary>
        /// Changes the name of the first item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, RoutedEventArgs e)
        {

            // Change the value of the Name property for the  
            // first item in the list.           
            AddressItems.FirstOrDefault().Name = "Killians Irish Pub";
            
         }

        private void addressChanged(object sender, PropertyChangedEventArgs e)
        {
            Debug.WriteLine("The property:'" + e.PropertyName + "' was changed");
           
        }
    }
    




}


