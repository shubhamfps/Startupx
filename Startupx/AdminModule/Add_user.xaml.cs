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
    /// Interaction logic for Add_user.xaml
    /// </summary>
    public partial class Add_user : Window
    {
        public Add_user()
        {
            InitializeComponent();
            //Loading employeed combobox
            Startupx_dbDataContext dc = new Startupx_dbDataContext();

            //Loading Data Grid with existing users
            dg_users.ItemsSource = dc.sp_list_user();

            //Loading Combobox with employees
            cb_employees.ItemsSource = from e in dc.Employees                                     
                                       select e.first_name + " " + e.first_name;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Startupx_dbDataContext dc = new Startupx_dbDataContext();
            try
            {
                List<Employee> employees = new List<Employee>();
                employees = dc.Employees.ToList();
                string user = txt_username.Text;
                string password = txt_password.Password;
                int employee_id = employees[cb_employees.SelectedIndex].id;
                dc.sp_insert_user(user, password, employee_id);
                dg_users.ItemsSource = dc.sp_list_user(); // Adding a user to the database
                Clean_Fields();
                MessageBox.Show("User added successfully", "Startupx", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please, make sure you enter the values ​​correctly", "Startupx", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show("Something Wrong!", "Startupx", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            

        }

        private void Clean_Fields()
        {
            txt_username.Text = "";
            txt_password.Password = "";
            cb_employees.Text = "";
        }
    }
}
