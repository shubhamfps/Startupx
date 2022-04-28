using Startupx.Reports;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Startupx.AdminModule
{
    /// <summary>
    /// Interaction logic for Admin_Index.xaml
    /// </summary>
    public partial class Admin_Index : Window
    {
        public Admin_Index(string title)
        {
            InitializeComponent();
            this.Title = title;
            Startupx_dbDataContext dc = new Startupx_dbDataContext();
            dg_users.ItemsSource = dc.sp_list_user();
        }

        private void bt_Products_Click(object sender, RoutedEventArgs e)
        {
            Startupx_dbDataContext dc = new Startupx_dbDataContext();
            dg_users.ItemsSource = dc.sp_list_user();
        }


        //Search bar filter
        private void bt_Search_Button(object sender, RoutedEventArgs e)
        {
            Startupx_dbDataContext dc = new Startupx_dbDataContext();
            var query = from u in dc.sp_list_user()
                        where u.Username.ToLower().Contains(txt_search.Text)
                        || u.Employee.ToLower().Contains(txt_search.Text)
                        select u;
            dg_users.ItemsSource = query;

        }

        private void Refresh_View(object sender, RoutedEventArgs e)
        {
            LoadUsers();
        }

        private void LoadUsers()
        {
            Startupx_dbDataContext dc = new Startupx_dbDataContext();
            dg_users.ItemsSource = dc.sp_list_user();
        }

        private void Add_User(object sender, RoutedEventArgs e)
        {
            Add_user u = new Add_user();
            u.ShowDialog();
        }

       

        private void Delete_User(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to delete this User?", "Startupx", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            // Process message box results
            switch (result)
            {
                case MessageBoxResult.Yes:
                    // User pressed Yes button if wants to delete the Category
                    Startupx_dbDataContext dc = new Startupx_dbDataContext();
                    int selectedIndex = dg_users.SelectedIndex;
                    int id = dc.Users.ToList().ElementAt(selectedIndex).id;
                    //Query for getting the category
                    var item_query = (from u in dc.Users
                                      where u.id == id
                                      select u).Single();
                    try
                    {
                        dc.Users.DeleteOnSubmit(item_query);
                        dc.SubmitChanges();
                        MessageBox.Show("User deleted successfully", "Startupx", MessageBoxButton.OK, MessageBoxImage.Information);

                        // Refreshing the DataGrid  with the new value
                        LoadUsers();
                    }
                    catch
                    {
                        MessageBox.Show("The User wasn't removed", "Startupx", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    break;

                case MessageBoxResult.No:
                    // User pressed No button                    
                    break;
            }

        }
        private void Give_permission(object sender, RoutedEventArgs e)
        {
            Startupx_dbDataContext dc = new Startupx_dbDataContext();
            string user = dc.Users.ToList().ElementAt(dg_users.SelectedIndex).username;
            Give_Permission_User u = new Give_Permission_User(user);
            u.ShowDialog();

        }

        private void bt_Categories_Click(object sender, RoutedEventArgs e)
        {
            Add_Permission p = new Add_Permission();
            p.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //This class contains a Crystal report viewer component
            ReportViewer viewer = new ReportViewer();
            string db_username = "sqluser8935";
            string db_password = "SQL_server8935";
            Rp_Users_permissions report0 = new Rp_Users_permissions();
            report0.Load("Rp_Users_permissions.rpt");
            report0.SetDatabaseLogon(db_username, db_password);
            report0.Refresh();            
            viewer.report_viewer.ViewerCore.ReportSource = report0;
            viewer.ShowDialog();
        }
    }
}
