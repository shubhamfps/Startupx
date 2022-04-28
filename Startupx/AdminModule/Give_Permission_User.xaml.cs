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
    /// Interaction logic for Give_Permission_User.xaml
    /// </summary>
    public partial class Give_Permission_User : Window
    {
        List<int> permissions;
        int id_user;
        string user;
        public Give_Permission_User(string user)
        {
            InitializeComponent();

            this.user = user;
            Startupx_dbDataContext dc = new Startupx_dbDataContext();            
            lb_user.Content = user;

            //Loading combobox
            cb_permissions.ItemsSource = from p in dc.Permissions
                                         select p.description;

            //getting the user id
            id_user = Convert.ToInt32((from u in dc.Users
                                          where u.username.Equals(user)
                                          select u.id).Single());

            //Showing permission by the user            
            dg_permission.ItemsSource = dc.sp_list_permission_by_user(user); 
            
            //Getting the permission
            permissions = (from p in dc.Permissions
                          join pu in dc.User_has_permissions 
                          on p.id equals pu.permission_id
                          join u in dc.Users
                          on pu.user_id equals u.id                           
                          where u.username.Equals(user)
                          select p.id).ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Startupx_dbDataContext dc = new Startupx_dbDataContext();
                int permission_id = dc.Permissions.ToList().ElementAt(cb_permissions.SelectedIndex).id;
                dc.sp_insert_user_permission(id_user, permission_id, 1);
                dg_permission.ItemsSource = dc.sp_list_permission_by_user(user);
                MessageBox.Show("Permission activated", "Startupx", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Something wrong", "Startupx", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            

        }

        private void Delete_Permission(object sender, RoutedEventArgs e)
        {
            try
            {
                Startupx_dbDataContext dc = new Startupx_dbDataContext();
                dynamic row = dg_permission.SelectedItem;
                string description = row.Description;
                dc.sp_remove_permission(id_user, description);
                MessageBox.Show("Permission removed", "Startupx", MessageBoxButton.OK, MessageBoxImage.Information);
                dg_permission.ItemsSource = dc.sp_list_permission_by_user(user);

            }
            catch (Exception)
            {
                MessageBox.Show("Something wrong", "Startupx", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        
    }
}
