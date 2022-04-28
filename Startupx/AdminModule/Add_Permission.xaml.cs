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

namespace Startupx.AdminModule
{
    /// <summary>
    /// Interaction logic for Add_Permission.xaml
    /// </summary>
    public partial class Add_Permission : Window
    {
        public Add_Permission()
        {
            InitializeComponent();
            Startupx_dbDataContext dc = new Startupx_dbDataContext();
            dg_permissions.ItemsSource = dc.Permissions;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string permission_description = txt_description.Text;
                if(permission_description != "")
                {
                    Startupx_dbDataContext dc = new Startupx_dbDataContext();
                    Permission p = new Permission();
                    p.description = permission_description;
                    dc.Permissions.InsertOnSubmit(p); //Inserting in database
                    dc.SubmitChanges(); //Inserting in database
                    MessageBox.Show("Permission added sucessfully", "Startupx", MessageBoxButton.OK, MessageBoxImage.Warning);
                    txt_description.Text = "";
                    dg_permissions.ItemsSource = dc.Permissions;
                    
                }
                else
                {
                    MessageBox.Show("Please, enter the information", "Startupx", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Something wrong", "Startupx", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
    }
}
