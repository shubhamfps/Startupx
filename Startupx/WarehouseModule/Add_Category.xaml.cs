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
    /// Interaction logic for Add_Category.xaml
    /// </summary>
    public partial class Add_Category : Window
    {
        public Add_Category()
        {
            InitializeComponent();
            Startupx_dbDataContext dc = new Startupx_dbDataContext();
            dg_categories.ItemsSource = dc.Item_categories;//Loading DataGrid
        }

        //Adding a category to the database
        private void Add_Category_X(object sender, RoutedEventArgs e)
        {
            if (txt_category.Text != "" && txt_prefix.Text != "")
            {
                Startupx_dbDataContext dc = new Startupx_dbDataContext();

                int checkCategory = (int)dc.fn_exist_category(txt_category.Text);
                if (checkCategory == 0)
                {
                    Item_category ic = new Item_category();
                    ic.category_name = txt_category.Text;
                    ic.category_pref = txt_prefix.Text;
                    try
                    {
                        // Calling insertOnSubmit(Item_Category Object) method from Startupx_db.designer.cs
                        dc.Item_categories.InsertOnSubmit(ic);
                        dc.SubmitChanges();
                        MessageBox.Show("Category added successfully", "Startupx", MessageBoxButton.OK, MessageBoxImage.Information);

                        //Cleaning the Texboxes
                        ClearFields();

                        // Refreshing the DataGrid  with the new value
                        LoadCategories();

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Operation no concluded", "Startupx", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                   

                }
                else
                {
                    MessageBox.Show("This Category already exists", "Startupx", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else {
                MessageBox.Show("Please, fill all the fields", "Startupx", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
         
        }

        //Deleting category from the database
        private void Delete_Category(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to delete this Category?", "Startupx", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            // Process message box results
            switch (result)
            {
                case MessageBoxResult.Yes:
                    // User pressed Yes button if wants to delete the Category

                    Startupx_dbDataContext dc = new Startupx_dbDataContext();
                    Item_category itemCategory = dg_categories.SelectedItem as Item_category;
                    var id = itemCategory.id;
                    //Query for getting the category
                    var category = (from cat in dc.Item_categories
                                    where cat.id == id
                                    select cat).Single();
                    try
                    {
                        dc.Item_categories.DeleteOnSubmit(category);
                        dc.SubmitChanges();
                        MessageBox.Show("Category deleted successfully", "Startupx", MessageBoxButton.OK, MessageBoxImage.Information);

                        // Refreshing the DataGrid  with the new value
                        LoadCategories();
                    }
                    catch
                    {
                        MessageBox.Show("The Category wasn't removed", "Message", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    break;

                case MessageBoxResult.No:
                    // User pressed No button                    
                    break;                
            }

        }

        //Updating category from the database
        private void Update_Category(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to update this Category?", "Startupx", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            // Process message box results
            switch (result)
            {
                case MessageBoxResult.Yes:
                    // User pressed Yes button if wants to update the Category
                    try
                    {
                        Startupx_dbDataContext dc = new Startupx_dbDataContext();
                        Item_category itemRow = dg_categories.SelectedItem as Item_category;
                        var id = itemRow.id;
                        var category = (from cat in dc.Item_categories
                                        where cat.id == id
                                        select cat).Single();
                        category.category_name = itemRow.category_name;
                        category.category_pref = itemRow.category_pref;                        
                        dc.SubmitChanges();
                        MessageBox.Show("Category updated successfully", "Startupx", MessageBoxButton.OK, MessageBoxImage.Information);
                        LoadCategories();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("The Category wasn't updated", "Message", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    break;

                case MessageBoxResult.No:
                    // User pressed No button                    
                    break;
            }

        }

        private void ClearFields()
        {
            txt_category.Text = "";
            txt_prefix.Text = "";
        }

        private void LoadCategories()
        {
            Startupx_dbDataContext dc = new Startupx_dbDataContext(); ;
            dg_categories.ItemsSource = dc.Item_categories;
        }


        //Search bar filter
        private void bt_Search_Button(object sender, RoutedEventArgs e)
        {
            Startupx_dbDataContext dc = new Startupx_dbDataContext(); ;
            var query = from i in dc.Item_categories
                        where i.category_name.ToLower().Contains(txt_search.Text)
                        || i.category_pref.ToLower().Contains(txt_search.Text)
                        select i;
            dg_categories.ItemsSource = query;
        }

        private void Refresh_View(object sender, RoutedEventArgs e)
        {
            LoadCategories();
        }
    }
}
