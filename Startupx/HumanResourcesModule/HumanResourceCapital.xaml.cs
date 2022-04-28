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
using Startupx.HumanResourcesModule;

namespace Startupx.HumanResourceModule
{

    /// <summary>
    /// Interaction logic for HumanResourceCapital.xaml
    /// </summary>
    public partial class HumanResourceCapital : Window
    {
        Startupx_dbDataContext dc;

        public HumanResourceCapital(string title)
        {
            InitializeComponent();
            this.Title = title;
            dc = new Startupx_dbDataContext();
            dg_hr_information.ItemsSource = dc.sp_employee_list2();//Getting the information in Data Grid
        }

        public HumanResourceCapital()
        {
            InitializeComponent();           
            dc = new Startupx_dbDataContext();
            dg_hr_information.ItemsSource = dc.sp_employee_list2();//Getting the information in Data Grid
        }

        private void bt_capital_Click(object sender, RoutedEventArgs e)
        {
            dg_hr_information.ItemsSource = dc.sp_employee_list2();//Getting the information in Data Grid
        }

        private void bt_payroll_Click(object sender, RoutedEventArgs e)
        {
            Payroll payroll = new Payroll();
            int selectedIndex = dg_hr_information.SelectedIndex;
            int id = dc.sp_employee_list2().ElementAt(selectedIndex).Id;
            float salary_per_hr =  float.Parse(dc.sp_employee_list2().ElementAt(selectedIndex).salary.ToString());
            //var rowview = dg_hr_information.SelectedItem as sp_employee_listResult2;
            payroll.getEmployee(id, salary_per_hr);
            payroll.ShowDialog();
            
            
        }

        private void InsertEmployeeAction_Click(object sender, RoutedEventArgs e)
        {
            InsertEmployeeForm insertEmployee = new InsertEmployeeForm();
            insertEmployee.ShowDialog();
            dg_hr_information.ItemsSource = dc.sp_employee_list2();
        }

        private void Update_Employee(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to update this Employee?", "Startupx", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            // Process message box results
            switch (result)
            {
                case MessageBoxResult.Yes:
                    // User pressed Yes button if wants to update the employee details
                    try
                    {

                        int selectedIndex = dg_hr_information.SelectedIndex;
                        var rowview = dg_hr_information.SelectedItem as sp_employee_listResult2;

                        // getting the values of the fields                        
                        int id = dc.sp_employee_list2().ElementAt(selectedIndex).Id;  // Accessing to the employee's id                      
                        var firstname = rowview.fName;
                        var lastname = rowview.lName;
                        var gender = rowview.Gender;
                        var department = rowview.Department;
                        var jobTitle = rowview.JobTitle;
                        var phone = long.Parse(rowview.Phone.ToString());
                        var address = rowview.Address;
                        var city = rowview.City;
                        var salary = double.Parse(rowview.salary.ToString());


                        //Calling the overload constructor for updating the Item
                        InsertEmployeeForm updateItem = new InsertEmployeeForm(id,
                                                            firstname,
                                                            lastname,
                                                            address,
                                                            phone,
                                                            salary,
                                                            jobTitle,
                                                            department,
                                                            city,
                                                            gender);
                        updateItem.ShowDialog();
                        LoadItems();
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Please, make sure you enter the values ​​correctly", "Message", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }

                    break;

                case MessageBoxResult.No:
                    // User pressed No button                    
                    break;
            }

        }

        private void Delete_Employee(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to delete this Empployee?", "Startupx", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            // Process message box results
            switch (result)
            {
                case MessageBoxResult.Yes:
                    // User pressed Yes button if wants to delete the Employee

                    Startupx_dbDataContext dc = new Startupx_dbDataContext();
                    int selectedIndex = dg_hr_information.SelectedIndex;
                    int id = dc.sp_employee_list2().ElementAt(selectedIndex).Id;
                    //Query for getting the Employee
                    var employee_query = (from emp in dc.Employees
                                      where emp.id == id
                                      select emp).Single();
                    try
                    {
                        dc.Employees.DeleteOnSubmit(employee_query);
                        dc.SubmitChanges();
                        MessageBox.Show("Employee deleted successfully", "Startupx", MessageBoxButton.OK, MessageBoxImage.Information);

                        // Refreshing the DataGrid  with the new value
                        LoadItems();
                    }
                    catch
                    {
                        MessageBox.Show("The Employee wasn't removed", "Message", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    break;

                case MessageBoxResult.No:
                    // User pressed No button                    
                    break;
            }
        }

        private void LoadItems()
        {
            Startupx_dbDataContext d = new Startupx_dbDataContext();
            dg_hr_information.ItemsSource = d.sp_employee_list2();
        }

        private void Print_Event(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(dg_hr_information, "Employee List");

            }
        }

        //Search bar filter
        private void bt_Search_Button(object sender, RoutedEventArgs e)
        {
            Startupx_dbDataContext d = new Startupx_dbDataContext();
            var query = from emp in dc.sp_employee_list2()
                        where emp.FullName.ToLower().Contains(txt_search.Text)
                        || emp.JobTitle.ToLower().Contains(txt_search.Text)
                        || emp.Department.ToLower().Contains(txt_search.Text)
                        || emp.Address.ToLower().Contains(txt_search.Text)
                        || emp.City.ToLower().Contains(txt_search.Text)
                        select emp;
            dg_hr_information.ItemsSource = query;

        }

        private void bt_payroll_list_Click(object sender, RoutedEventArgs e)
        {
            ManagePayroll managePayroll = new ManagePayroll();
            managePayroll.ShowDialog();
            
        }

        private void bt_Reports_Click(object sender, RoutedEventArgs e)
        {
            EmployeeReport report = new EmployeeReport();
            report.ShowDialog();
        }

        private void bt_refresh_view_Click(object sender, RoutedEventArgs e)
        {
            LoadItems();
        }

        private void bt_refresh_view_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}