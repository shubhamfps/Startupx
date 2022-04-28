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
using System.Windows.Shapes;

namespace Startupx.WarehouseModule
{
    /// <summary>
    /// Interaction logic for Add_Brand.xaml
    /// </summary>
    public partial class Add_Brand : Window
    {
        public Add_Brand()
        {
            InitializeComponent();
            Startupx_dbDataContext dc = new Startupx_dbDataContext();
            dg_Brand.ItemsSource = dc.Item_brands;
        }

        //Adding a brand to the database
        private void Add_Brand_X(object sender, RoutedEventArgs e)
        {
            if (txt_brand.Text != "" )
            {
                Startupx_dbDataContext dc = new Startupx_dbDataContext();

                int checkBrand= (int)dc.fn_exist_brand(txt_brand.Text);
                if (checkBrand == 0)
                {
                    Item_brand ib = new Item_brand();
                    ib.brand_name = txt_brand.Text;
                    try
                    {
                        // Calling insertOnSubmit(Item_Brand Object) method from Startupx_db.designer.cs
                        dc.Item_brands.InsertOnSubmit(ib);
                        dc.SubmitChanges();
                        MessageBox.Show("Brand added successfully", "Startupx", MessageBoxButton.OK, MessageBoxImage.Information);

                        //Cleaning the Texboxes
                        txt_brand.Text = "";

                        // Refreshing the DataGrid  with the new value
                        LoadBrands();

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Operation no concluded", "Startupx", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                   
                }
                else
                {
                    MessageBox.Show("This Brand already exists", "Startupx", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Please, fill all the fields", "Startupx", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        //Deleting brand from the database
        private void Delete_Brand(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to delete this Brand?", "Startupx", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            // Process message box results
            switch (result)
            {
                case MessageBoxResult.Yes:
                    // User pressed Yes button if wants to delete the Brand

                    Startupx_dbDataContext dc = new Startupx_dbDataContext();
                    Item_brand itemBrand = dg_Brand.SelectedItem as Item_brand;
                    var id = itemBrand.id;
                    //Query for getting the brand
                    var brand = (from b in dc.Item_brands
                                    where b.id == id
                                    select b).Single();
                    try
                    {
                        dc.Item_brands.DeleteOnSubmit(brand);
                        dc.SubmitChanges();
                        MessageBox.Show("Brand deleted successfully", "Startupx", MessageBoxButton.OK, MessageBoxImage.Information);

                        // Refreshing the DataGrid  with the new value
                        LoadBrands();
                    }
                    catch
                    {
                        MessageBox.Show("The Brand wasn't removed", "Message", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    break;

                case MessageBoxResult.No:
                    // User pressed No button                    
                    break;
            }

        }

        //Updating brand from the database
        private void Update_Brand(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to update this Brand?", "Startupx", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            // Process message box results
            switch (result)
            {
                case MessageBoxResult.Yes:
                    // User pressed Yes button if wants to update the Brand
                    try
                    {
                        Startupx_dbDataContext dc = new Startupx_dbDataContext();
                        Item_brand itemRow = dg_Brand.SelectedItem as Item_brand;
                        var id = itemRow.id;
                        var brand = (from b in dc.Item_brands
                                        where b.id == id
                                        select b).Single();
                        brand.brand_name = itemRow.brand_name;                        
                        dc.SubmitChanges();
                        MessageBox.Show("Brand updated successfully", "Startupx", MessageBoxButton.OK, MessageBoxImage.Information);
                        LoadBrands();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("The Brand wasn't updated", "Message", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    break;

                case MessageBoxResult.No:
                    // User pressed No button                    
                    break;
            }

        }

        private void LoadBrands()
        {
            Startupx_dbDataContext dc = new Startupx_dbDataContext(); ;
            dg_Brand.ItemsSource = dc.Item_brands;
        }

        //Search bar filter
        private void bt_Search_Button(object sender, RoutedEventArgs e)
        {
            Startupx_dbDataContext dc = new Startupx_dbDataContext(); 
            var query = from i in dc.Item_brands
                        where i.brand_name.ToLower().Contains(txt_search.Text)                        
                        select i;
            dg_Brand.ItemsSource = query;
        }

        private void Refresh_View(object sender, RoutedEventArgs e)
        {
            LoadBrands();
        }
    }
}
