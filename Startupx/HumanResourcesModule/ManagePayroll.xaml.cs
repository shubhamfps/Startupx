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

namespace Startupx.HumanResourcesModule
{
    /// <summary>
    /// Interaction logic for ManagePayroll.xaml
    /// </summary>
    public partial class ManagePayroll : Window
    {
        Startupx_dbDataContext dc;
        public ManagePayroll()
        {
            InitializeComponent();
            dc = new Startupx_dbDataContext();
            dg_payroll_information.ItemsSource = dc.sp_payroll_list();
        }

        private void delete_payroll_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to delete this Payroll?", "Startupx", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            // Process message box results
            switch (result)
            {
                case MessageBoxResult.Yes:
                    // User pressed Yes button if wants to delete the Payroll

                    Startupx_dbDataContext dc = new Startupx_dbDataContext();
                    int selectedIndex = dg_payroll_information.SelectedIndex;
                    int id = dc.sp_payroll_list().ElementAt(selectedIndex).PayrollId;
                    //Query for getting the Payroll
                    var payroll_query = (from s in dc.Salaries
                                          where s.id == id
                                          select s).Single();
                    try
                    {
                        dc.Salaries.DeleteOnSubmit(payroll_query);
                        dc.SubmitChanges();
                        MessageBox.Show("Payroll deleted successfully", "Startupx", MessageBoxButton.OK, MessageBoxImage.Information);

                        // Refreshing the DataGrid  with the new value
                        dg_payroll_information.ItemsSource = dc.sp_payroll_list();
                    }
                    catch
                    {
                        MessageBox.Show("The Payroll wasn't removed", "Message", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    break;

                case MessageBoxResult.No:
                    // User pressed No button                    
                    break;
            }
        }

        private void update_payroll_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to update this Payroll?", "Startupx", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            // Process message box results
            switch (result)
            {
                case MessageBoxResult.Yes:
                    // User pressed Yes button if wants to update the payroll details
                    try
                    {
                        Startupx_dbDataContext dc = new Startupx_dbDataContext();

                        //get data
                        int selectedIndex = dg_payroll_information.SelectedIndex;

                        var rowview = dg_payroll_information.SelectedItem as sp_payroll_listResult;
                        
                        // getting the values of the fields                        
                        int payrollId = dc.sp_payroll_list().ElementAt(selectedIndex).PayrollId;  // Accessing to the payroll's id                      

                        int workingHours = int.Parse(rowview.WorkingHours.ToString());
                        float pf = 5; // took static pf rate
                        float basictax = 2; //basic tax rate
                        DateTime startDate = DateTime.Parse(rowview.SalaryIniPeriod.ToString());
                        DateTime endDate = DateTime.Parse(rowview.SalaryEndPeriod.ToString());
                        float bonus = float.Parse(rowview.AdjustmentPercent.ToString());
                        int selectedEmployeeId = dc.sp_payroll_list().ElementAt(selectedIndex).EmployeeId;
                        float employeeSalaryPerHr = float.Parse(rowview.SalaryPerHr.ToString());

                        Payroll payroll = new Payroll(workingHours, pf, basictax, startDate, endDate, bonus, payrollId, selectedEmployeeId, employeeSalaryPerHr); ;
                        payroll.ShowDialog();
                        dg_payroll_information.ItemsSource = dc.sp_payroll_list();
                     } 
                    catch(FormatException)
                    {
                        MessageBox.Show("Please, make sure you enter the values ​​correctly", "Startupx", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Incorrect Operation. Please, make sure you enter the values ​​correctly", "Startupx", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    break;
                case MessageBoxResult.No:
                    // User pressed No button                    
                    break;
            }

        }
    }
}
