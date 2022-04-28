using Startupx.Incoming;
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
    /// Interaction logic for Add_Checkout.xaml
    /// </summary>
    public partial class Add_Checkout : Window
    {
        int invoice_id;
        public Add_Checkout(int invoice_id)
        {
            InitializeComponent();
            this.invoice_id = invoice_id;
            List<String> payment_method = new List<string>();
            payment_method.Add("Cash");
            payment_method.Add("Credit");
            payment_method.Add("Debit Card");
            cb_payment_method.ItemsSource = payment_method;            
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Startupx_dbDataContext dc = new Startupx_dbDataContext();
            string clientName = txt_client.Text;
            long cardNumber = long.Parse(txt_card_number.Text);
            string payment = cb_payment_method.SelectedItem.ToString();

            //Updating in the database

            dc.sp_update_payment_method(invoice_id, clientName, cardNumber, payment);

            //Creating and open tthe invoice report
            ReportViewer viewer = new ReportViewer();
            string db_username = "sqluser8935";
            string db_password = "SQL_server8935";
            Rp_Invoice report0 = new Rp_Invoice();
            report0.Load("Rp_Invoice.rpt");
            report0.SetDatabaseLogon(db_username, db_password);
            report0.Refresh();
            report0.SetParameterValue(0, invoice_id);
            viewer.report_viewer.ViewerCore.ReportSource = report0;
        }
    }
}
