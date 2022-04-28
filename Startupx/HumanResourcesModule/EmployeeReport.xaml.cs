using CrystalDecisions.Shared;
using Startupx.Reports;
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
    /// Interaction logic for EmployeeReport.xaml
    /// </summary>
    public partial class EmployeeReport : Window
    {
        
        public EmployeeReport()
        {
            InitializeComponent();
            Startupx_dbDataContext dc = new Startupx_dbDataContext();
            cb_reports.ItemsSource = from r in dc.Reports
                                     where r.module.Equals(3)
                                     select r.report_name;
            HideComponents();
        }

        private void Generate_Report(object sender, RoutedEventArgs e)
        {
            //This class contains a Crystal report viewer component
            EmployeeReportViewer viewer = new EmployeeReportViewer();
            string db_username = "sqluser8935";
            string db_password = "SQL_server8935";
            try
            {
                
                switch (cb_reports.SelectedIndex)
                {
                    case 0:
                        //Loading EmployeeDetails by id report
                        EmployeeDetails report = new EmployeeDetails();
                        report.Load("EmployeeReport.rpt");
                        report.SetDatabaseLogon(db_username, db_password);
                        report.Refresh();
                        report.SetParameterValue(0, cb_employee_list.SelectedItem.ToString());
                        viewer.employee_report_viewer.ViewerCore.ReportSource = report;
                        HideComponents();
                        break;

                    default:
                        MessageBox.Show("This report does not exist", "Startupx", MessageBoxButton.OK, MessageBoxImage.Warning);
                        break;
                }
                
                //Displaying the window with the report
                viewer.ShowDialog();

            }
            catch (Exception)
            {
                MessageBox.Show("Something wrong when opening the report", "Startupx", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        //Hidding the search criteria components
        private void HideComponents()
        {
            cb_employee_list.Visibility = Visibility.Hidden;
        }

        
        //Controlling the changes values in the combobox for displaying the search criteria component
        
        private void cb_reports_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Startupx_dbDataContext dc = new Startupx_dbDataContext();
            switch (cb_reports.SelectedIndex)
            {
                case 0:
                    HideComponents();
                    cb_employee_list.ItemsSource = from s in dc.Salaries select s.employee_id;
                    cb_employee_list.Visibility = Visibility.Visible;
                    break;
                default:
                    break;
            }
        }

    }
}
