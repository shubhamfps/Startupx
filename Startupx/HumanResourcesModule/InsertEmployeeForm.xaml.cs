using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.SqlClient;
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

namespace Startupx.HumanResourcesModule
{

    /// <summary>
    /// Interaction logic for InsertEmployeeForm.xaml
    /// </summary>
    public partial class InsertEmployeeForm : Window
    {
        int flag;
        int employeeId; //global variable for updating Employee
        Startupx_dbDataContext dc;

        public InsertEmployeeForm()
        {
            InitializeComponent();
            dc = new Startupx_dbDataContext();

            // Populating combobox function
            PopulateCombobox();
            flag = 1;
        }

        //Overload Constructor for updating Employee
        public InsertEmployeeForm(
            int id,
            string emp_fname,
            string emp_lname,
            string emp_address,
            long emp_phone,
            double emp_salary,
            string emp_jobtitle,
            string emp_department,
            string emp_city,
            string emp_gender)
        {
            InitializeComponent();

            PopulateCombobox();
            employeeId = id;
            flag = 2;

            //loading values in components
            fName.Text = emp_fname;
            lName.Text = emp_lname;
            address.Text = emp_address;
            phone.Text = emp_phone.ToString();
            salary.Text = emp_salary.ToString();
            jobTitle_list.Text = emp_jobtitle;
            department_list.Text = emp_department;
            city_list.Text = emp_city;
            
            //Change the title of the view
            dialog_title.Content = "UPDATE EMPLOYEE";
            SubmitEvent.Content = "Update";

        }



        public void PopulateCombobox()
        {
            Startupx_dbDataContext dc = new Startupx_dbDataContext();
            // Populate list of Job title
            jobTitle_list.ItemsSource = from J in dc.Job_Titles select J.job_title1;

            // Populate list of department
            department_list.ItemsSource = from D in dc.Departments select D.department_name;

            // Populate list of cities
            city_list.ItemsSource = from C in dc.Cities select C.city_name;

        }

        private void SubmitEvent_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                var firstname = fName.Text;
                var lastname = lName.Text;
                var useraddress = address.Text;
                long phonenum = long.Parse(phone.Text);
                double monthsalary = double.Parse(salary.Text);
                var jobtitle = jobTitle_list.SelectedItem.ToString();
                var department = department_list.SelectedItem.ToString();
                var city = city_list.SelectedItem.ToString();
                var gender = (male.IsChecked == true) ? male.Content.ToString() : female.Content.ToString();

                if (firstname != ""
                 && lastname != ""
                 && useraddress != ""
                 && phonenum != 0
                 && monthsalary != 0
                 && jobtitle != ""
                 && department != ""
                 && city != "")
                {
                    if (flag == 1)
                    {
                        // Calling stored procedure for inserting an Employee
                        Startupx_dbDataContext dc = new Startupx_dbDataContext();
                        dc.sp_insert_employee1(firstname, lastname, useraddress, phonenum, department,
                        monthsalary, gender, jobtitle, city);

                        MessageBox.Show("Employee added successfully", "Startupx", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                    else
                    {
                        //Updating Employee
                        Startupx_dbDataContext dc = new Startupx_dbDataContext();
                        dc.sp_update_employee(employeeId, firstname, lastname, useraddress, phonenum, department,
                        monthsalary, gender, jobtitle, city);

                        MessageBox.Show("Employee updated successfully", "Startupx", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
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
            finally
            {
                this.Close();
            }

        }

        private void CancelEvent_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ClearFields()
        {
            fName.Text = "";
            lName.Text = "";
            address.Text = "";
            phone.Text = "";
            salary.Text = "";
            jobTitle_list.Text = "";
            department_list.Text = "";
            city_list.Text = "";
        }

    }
}
