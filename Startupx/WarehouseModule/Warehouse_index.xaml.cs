using Startupx.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace Startupx.WarehouseModule
{
    /// <summary>
    /// Interaction logic for Warehouse_index.xaml
    /// </summary>
    public partial class Warehouse_index : Window
    {
        Startupx_dbDataContext dc;        
        public Warehouse_index(string title)
        {
            InitializeComponent();            
            dc = new Startupx_dbDataContext();            
            dg_information.ItemsSource = dc.sp__item_list();//Getting the information in Data Grid
            this.Title = title;

        }

        private void Add_Item(object sender, RoutedEventArgs e)
        {
            Add_Item i = new Add_Item();
            i.ShowDialog();
        }

        private void Delete_Item(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to delete this Category?", "Startupx", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            // Process message box results
            switch (result)
            {
                case MessageBoxResult.Yes:
                    // User pressed Yes button if wants to delete the Category

                    Startupx_dbDataContext dc = new Startupx_dbDataContext();
                    int selectedIndex = dg_information.SelectedIndex;     
                    int id = dc.Items.ToList().ElementAt(selectedIndex).id;
                    //Query for getting the category
                    var item_query = (from i in dc.Items
                                    where i.id == id
                                    select i).Single();
                    try
                    {
                        dc.Items.DeleteOnSubmit(item_query);
                        dc.SubmitChanges();
                        MessageBox.Show("Item deleted successfully", "Startupx", MessageBoxButton.OK, MessageBoxImage.Information);

                        // Refreshing the DataGrid  with the new value
                        LoadItems();
                    }
                    catch
                    {
                        MessageBox.Show("The Category wasn't removed", "Startupx", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    break;

                case MessageBoxResult.No:
                    // User pressed No button                    
                    break;
            }

        }

        private void Update_Item(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to update this Item?", "Startupx", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            // Process message box results
            switch (result)
            {
                case MessageBoxResult.Yes:
                    // User pressed Yes button if wants to update the Category
                    try
                    {                        
                        int selectedIndex = dg_information.SelectedIndex;
                        var rowview = dg_information.SelectedItem as sp__item_listResult;    
                        
                        // getting the values of the fields
                        int id = dc.Items.ToList().ElementAt(selectedIndex).id;  // Accessing to the Item's id                      
                        var name = rowview.Name;
                        var description = rowview.Description;
                        var price = rowview.Price.ToString();
                        var date = rowview.Date.ToString();
                        var barcode = rowview.Barcode;
                        var brand = rowview.Brand;
                        var category = rowview.Category;
                        var warehouse = rowview.Warehouse;
                        var section = rowview.Section;

                        //Calling the overload constructor for updating the Item
                        Add_Item updateItem = new Add_Item( id, 
                                                            name, 
                                                            description, 
                                                            price, 
                                                            date, 
                                                            barcode, 
                                                            brand, 
                                                            category, 
                                                            section,
                                                            warehouse);
                        updateItem.ShowDialog();
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Please, make sure you enter the values ​​correctly", "Startupx", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    
                    break;

                case MessageBoxResult.No:
                    // User pressed No button                    
                    break;
            }

        }

        private void Increase_Stock(object sender, RoutedEventArgs e)
        {
            try
            {
                int selectedIndex = dg_information.SelectedIndex;
                var rowview = dg_information.SelectedItem as sp__item_listResult;
                var barcode = rowview.Barcode;

                Add_Stock a = new Add_Stock(barcode);
                a.ShowDialog();
            }
            catch (FormatException)
            {
                MessageBox.Show("Something wrong", "Startupx", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void LoadItems()
        {
            Startupx_dbDataContext d = new Startupx_dbDataContext(); 
            dg_information.ItemsSource = d.sp__item_list();
        }

        private void Refresh_View(object sender, RoutedEventArgs e)
        {
            LoadItems();
        }

        private void bt_Reports_Click(object sender, RoutedEventArgs e)
        {
            W_Report report = new W_Report();
            report.ShowDialog();
        }

        private void bt_Products_Click(object sender, RoutedEventArgs e)
        {
            dg_information.ItemsSource = dc.sp__item_list();//Getting the information in Data Grid
        }

 
        //Search bar filter
        private void bt_Search_Button(object sender, RoutedEventArgs e)
        {
            Startupx_dbDataContext d = new Startupx_dbDataContext();
            var query = from i in d.sp__item_list()
                        where i.Name.ToLower().Contains(txt_search.Text) 
                        || i.Description.ToLower().Contains(txt_search.Text)
                        select i;
            dg_information.ItemsSource = query;

        }

        private void bt_Categories_Click(object sender, RoutedEventArgs e)
        {
            Add_Category ac = new Add_Category();
            ac.ShowDialog();
        }

        private void bt_Brands_Click(object sender, RoutedEventArgs e)
        {
            Add_Brand ab = new Add_Brand();
            ab.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //This class contains a Crystal report viewer component
            ReportViewer viewer = new ReportViewer();
            string db_username = "sqluser8935";
            string db_password = "SQL_server8935";
            Rp_Item_General report0 = new Rp_Item_General();
            report0.Load("Rp_Item_General.rpt");
            report0.SetDatabaseLogon(db_username, db_password);
            report0.Refresh();
            viewer.report_viewer.ViewerCore.ReportSource = report0;
            viewer.ShowDialog();
        }
    }
}
