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
using Startupx.Helpers;

namespace Startupx.WarehouseModule
{
    /// <summary>
    /// Interaction logic for Add_Item.xaml
    /// </summary>
    public partial class Add_Item : Window
    {
        int flag;
        int itemId;//global variable for updating Item
        bool barcodeFlag = true;

        public Add_Item()
        {
            InitializeComponent();            
            PopulateCombobox();
            flag = 1;
        }

        //Overload Constructor for updating Item
        public Add_Item(
            int id,
            string name,
            string description,
            string price,
            string date,
            string barcode, 
            string brand, 
            string category, 
            string section,
            string warehouse)
        {
            InitializeComponent();

            PopulateCombobox();
            itemId = id;
            flag = 2;

            //loading values in components
            txt_productName.Text = name;
            txt_description.Text = description;
            txt_productPrice.Text = price;
            dp_date.Text = date;
            cb_brand.Text = brand;
            cb_category.Text = category;
            cb_warehouse.Text = warehouse;            
            cb_section.Text = section;
            //loading barcode
            Barcode barcodeG = new Barcode();
            barcodeG.GenerateBarcode(barcode, img_barcode, lb_barcode);
            barcodeFlag = false;

            //Change the title of the view
            lb_title.Content = "UPDATE ITEM";
            bt_insert_button.Content = "Update Item";
            
        }

        //Loading values in combobox
        private void PopulateCombobox() {
            Startupx_dbDataContext dc = new Startupx_dbDataContext();
            // Populating combobox categories
            cb_category.ItemsSource = from C in dc.Item_categories select C.category_name;
            // Populating combobox brands
            cb_brand.ItemsSource = from B in dc.Item_brands select B.brand_name;
            // Populating combobox warehouse
            cb_warehouse.ItemsSource = from W in dc.Warehouses select W.name;       
            
        }

   
        //Inserting Item
        private void Insert_Item(object sender, RoutedEventArgs e)
        {
           
                Startupx_dbDataContext dc = new Startupx_dbDataContext();
                try
                {
                    var barcode = lb_barcode.Content.ToString();
                    var productName = txt_productName.Text;
                    var description = txt_description.Text;
                    var price = double.Parse(txt_productPrice.Text);
                    var date = Convert.ToDateTime(dp_date.SelectedDate);
                    var category = cb_category.SelectedItem.ToString();
                    var brand = cb_brand.SelectedItem.ToString();
                    var section = cb_section.SelectedValue.ToString();

                    if (productName != ""
                        && description != ""
                        && price >= 0
                        && category.Length > 0
                        && brand.Length > 0
                        && section.Length > 0){

                        if(flag == 1)
                        {
                            // Calling stored procedure for inserting an Item
                            dc.sp_insert_item(
                                    barcode,
                                    productName,
                                    description,
                                    price,
                                    date,
                                    category,
                                    brand,
                                    section);

                            MessageBox.Show("Item added successfully", "Startupx", MessageBoxButton.OK, MessageBoxImage.Information);

                        }
                        else
                        {
                            //Updating Item
                            dc.sp_update_item(itemId, 
                                productName, 
                                description, 
                                price, 
                                date, 
                                category, 
                                brand, 
                                section);

                            MessageBox.Show("Item updated successfully", "Startupx", MessageBoxButton.OK, MessageBoxImage.Information);                                                       
                            this.Close();
                            return;
                        }
                        
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Please, fill all the fields", "Startupx", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Please, make sure you enter the values ​​correctly", "Startupx", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                catch (Exception)
                {
                    MessageBox.Show("Incorrect Operation. Please, make sure you enter the values ​​correctly", "Startupx", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
        }


        // Populating combobox section when SelectionChanged event is executed  
        private void cb_warehouse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Startupx_dbDataContext dc = new Startupx_dbDataContext();

            //inner join query for getting the sections by warehouse
            var query = from s in dc.Sections
                        join w in dc.Warehouses on s.warehouse_id equals w.id
                        where w.name == cb_warehouse.SelectedItem.ToString()
                        select s.section_name;
            cb_section.ItemsSource = query;
        }

        
        // Generating the barcode when SelectionChanged event is executed   in  Category combobox 
        private void cb_category_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Startupx_dbDataContext dc = new Startupx_dbDataContext();
            //Using Barcode class for generating the barcode
            if(cb_category.SelectedItem.ToString() == "")
            {
                return;
            }
            if (barcodeFlag) {
                try
                {
                    string barCode = dc.fn_generate_barcode(cb_category.SelectedItem.ToString());
                    Barcode barcode = new Barcode();
                    barcode.GenerateBarcode(barCode, img_barcode, lb_barcode);

                }
                catch (Exception)
                {
                    MessageBox.Show("The barcode was not generated correctly", "Startupx", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                barcodeFlag = true;
                return;
            }
            
            
        }

        // Showing Add_Category Dialog
        private void Add_Category(object sender, RoutedEventArgs e)
        {
            Add_Category ac = new Add_Category();
            ac.ShowDialog();
        }

        private void ClearFields()
        {
            txt_productName.Text = "";
            txt_description.Text = "";
            txt_productPrice.Text = "";
            cb_brand.Text = "";
            cb_category.Text = "";
            cb_category.Text = "";
            lb_barcode.Content = "";
            dp_date.Text = "Select a date";
        }

        //Update Button
        private void Refresh_View(object sender, RoutedEventArgs e)
        {
            PopulateCombobox();
        }

        private void Add_Brand(object sender, RoutedEventArgs e)
        {
            Add_Brand ab = new Add_Brand();
            ab.ShowDialog();
        }
    }
}
