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
using Startupx.WarehouseModule;
using Startupx.HumanResourceModule;
using Startupx.Billing;
using Startupx.AdminModule;



namespace Startupx.Login
{
    /// <summary>
    /// Interaction logic for Login_Form.xaml
    /// </summary>
    public partial class Login_Form : Window
    {
        public Login_Form()
        {
            InitializeComponent();
            Startupx_dbDataContext dc = new Startupx_dbDataContext();
            cb_modules.ItemsSource = from p in dc.Permissions select p.description;

        }

        private void bt_Login(object sender, RoutedEventArgs e)
        {
            Startupx_dbDataContext dc = new Startupx_dbDataContext();
            try
            {
                string username = txt_username.Text;
                string password = txt_password.Password;
                var permission = (from p in dc.Permissions
                                  where p.description.Equals(cb_modules.SelectedItem.ToString())
                                  select p).Single();
                var module_id = permission.id;
                int okCredentials = (int)dc.fn_login_user(username, password);//check user and password calling an sql user defined function
                int havePermission = (int)dc.fn_login_user_permission(username, module_id);//check user and module calling an sql user defined function

                if (okCredentials == 1)
                {
                    if (havePermission == 1)
                    {
                        switch (module_id)
                        {
                            case 1:
                                //open Administration module
                                Admin_Index a = new Admin_Index("Administration module - Current User: " + username);
                                a.ShowDialog();
                                break;
                            case 2:
                                //open Warehouse module                            
                                Warehouse_index w = new Warehouse_index("Warehouse module - Current User: " + username);
                                w.ShowDialog();
                                break;
                            case 3:
                                //open Payroll module
                                HumanResourceCapital h = new HumanResourceCapital("Payroll module - Current User: " + username);
                                h.ShowDialog();
                                break;
                            case 4:
                                //open Billing module
                                BillingModule bi = new BillingModule();
                                bi.ShowDialog();
                                break;

                            default:
                                break;
                        }
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Access denied", "Startupx", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Wrong user and/or password", "Startupx", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something Wrong!", "Startupx", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }
    }
}
