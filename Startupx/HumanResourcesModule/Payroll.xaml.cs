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
    /// Interaction logic for Payroll.xaml
    /// </summary>
    public partial class Payroll : Window
    {
        int selectedEmployeeId, payrollId;
        float employeeSalaryPerHr;
        int flag;
        float pf, basictax;
        public Payroll()
        {
            InitializeComponent();
            flag = 1;
        }

        public Payroll(int workingHours, float pf,float basictax,DateTime startDate,DateTime endDate,float bonus, 
           int payrollId, int selectedEmployeeId, float employeeSalaryPerHr)
        {
            InitializeComponent();

            flag = 2;

            //loading values in components
            working_hours.Text = workingHours.ToString();
            this.pf = pf;
            this.basictax = basictax;
            start_date.Text = startDate.ToString();
            end_date.Text = endDate.ToString();
            increment.Text = bonus.ToString();
            this.payrollId = payrollId;
            this.selectedEmployeeId = selectedEmployeeId;
            this.employeeSalaryPerHr = employeeSalaryPerHr;

            //Change the title of the view
            dialog_title.Content = "UPDATE PAYROLL";
            generate_payroll.Content = "Update";

        }

        public void getEmployee(int employeeId, float salary_per_hr)
        {
            selectedEmployeeId = employeeId;
            employeeSalaryPerHr = salary_per_hr;
        }

        private void generate_payroll_Click(object sender, RoutedEventArgs e)
        {
            //get data
            
            int workingHours = int.Parse(working_hours.Text);
            float pf = float.Parse(epf.Text);
            float basictax = float.Parse(tax.Text);
            DateTime startDate = DateTime.Parse(start_date.SelectedDate.ToString());
            DateTime endDate = DateTime.Parse(end_date.SelectedDate.ToString());
            float bonus = float.Parse(increment.Text);
            if (flag == 1)
            {
                //Insert a payroll for employee
                InsertUpdatePayroll(workingHours, pf, basictax, startDate, endDate, bonus, 0, selectedEmployeeId, employeeSalaryPerHr);
            }
            else {
                //update a payroll for employee
                InsertUpdatePayroll(workingHours, pf, basictax, startDate, endDate, bonus, payrollId, 
                    selectedEmployeeId, employeeSalaryPerHr);
            }

        }

        public void InsertUpdatePayroll(int workingHours, float pf, float basictax, DateTime startDate,
            DateTime endDate, float bonus, int payrollId, int selectedEmployeeId, float employeeSalaryPerHr)
        {
     
            //Calculating days
            int totaldays = 1 + Convert.ToInt32((endDate - startDate).TotalDays);
            
            float grossSalary = workingHours * totaldays * employeeSalaryPerHr;
            
            if (bonus > 0)
            {
                grossSalary = workingHours * totaldays * (employeeSalaryPerHr + bonus);
            }

            //Deduction
            float deductPF = (grossSalary * pf) / 100;
            float deductTax = (grossSalary * basictax) / 100;

            //net salary 
            float netSalary = grossSalary - deductPF - deductTax;
            
            if (workingHours > 0 
                && employeeSalaryPerHr > 0 
                && grossSalary > 0
                && netSalary > 0)
            {
                // Calling stored procedure for inserting an Payroll
                Startupx_dbDataContext dc = new Startupx_dbDataContext();
                if (flag == 1)
                {
                    dc.sp_generate_payroll_for_employee_id(selectedEmployeeId,
                        workingHours,
                        grossSalary,
                        netSalary,
                        startDate,
                        endDate,
                        bonus);

                    MessageBox.Show("Payroll Generate Successfully", "Startupx", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else {
                    
                    dc.sp_update_payroll(payrollId, selectedEmployeeId,
                        workingHours,
                        grossSalary,
                        netSalary,
                        startDate,
                        endDate,
                        bonus);
                    MessageBox.Show("Payroll Updated Successfully", "Startupx", MessageBoxButton.OK, MessageBoxImage.Information);
                    
                }

                this.Close();             
            } else {
                MessageBox.Show("Please, fill all the fields", "Startupx", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private void CancelEvent_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
