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

namespace Startupx.WarehouseModule
{
    /// <summary>
    /// Interaction logic for W_Report.xaml
    /// </summary>
    public partial class W_Report : Window
    {
        
        public W_Report()
        {
            InitializeComponent();
            Startupx_dbDataContext dc = new Startupx_dbDataContext();
            cb_reports.ItemsSource = from r in dc.Reports
                                     where r.module.Equals(2)
                                     select r.report_name;
            HideComponents();
        }

        private void Generate_Report(object sender, RoutedEventArgs e)
        {
            //This class contains a Crystal report viewer component
            ReportViewer viewer = new ReportViewer();
            string db_username = "sqluser8935";
            string db_password = "SQL_server8935";
            try
            {
                switch (cb_reports.SelectedIndex)
                {
                    case 0:                     
                        //Loading Items by category report
                        Rp_Items_by_category report0 = new Rp_Items_by_category();                     
                        report0.Load("Rp_Items_by_category.rpt");
                        report0.SetDatabaseLogon(db_username, db_password);
                        report0.Refresh();
                        report0.SetParameterValue(0, cb_criteria.SelectedItem.ToString());
                        viewer.report_viewer.ViewerCore.ReportSource = report0;
                        HideComponents();
                        break;

                    case 1:
                        //Loading Items by brand report
                       
                        Rp_Items_by_brand report1 = new Rp_Items_by_brand();    
                        report1.Load("Rp_Items_by_brand.rpt");
                        report1.SetDatabaseLogon(db_username, db_password);
                        report1.Refresh();
                        report1.SetParameterValue(0, cb_criteria.SelectedItem.ToString());                        
                        viewer.report_viewer.ViewerCore.ReportSource = report1;
                        HideComponents();
                        break;

                    case 2:
                        //Loading Items by brand report
                        Rp_Items_by_expired_date report2 = new Rp_Items_by_expired_date();                       
                        report2.Load("Rp_Items_by_expired_date.rpt");
                        report2.SetDatabaseLogon(db_username, db_password);
                        report2.Refresh();
                        report2.SetParameterValue(0, dp_criteria.SelectedDate);
                        viewer.report_viewer.ViewerCore.ReportSource = report2;
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
            cb_criteria.Visibility = Visibility.Hidden;
            cb_criteria.Visibility = Visibility.Hidden;
            dp_criteria.Visibility = Visibility.Hidden;
        }


        //Controlling the changes values in the combobox for displaying the search criteria component
        private void cb_reports_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Startupx_dbDataContext dc = new Startupx_dbDataContext();
            switch (cb_reports.SelectedIndex)
            {
                case 0:
                    HideComponents();
                    cb_criteria.ItemsSource = from C in dc.Item_categories select C.category_pref;
                    cb_criteria.Visibility = Visibility.Visible;
                    break;
                case 1:
                    HideComponents();
                    cb_criteria.ItemsSource = from B in dc.Item_brands select B.brand_name;
                    cb_criteria.Visibility = Visibility.Visible;
                    break;
                case 2:
                    HideComponents();
                    dp_criteria.Visibility = Visibility.Visible;
                    break;
                default:
                    break;
            }
        }
    }
}
