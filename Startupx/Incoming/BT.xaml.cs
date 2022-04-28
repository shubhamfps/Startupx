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
using Startupx.Helpers;

namespace Startupx.WarehouseModule
{
    /// <summary>
    /// Interaction logic for BT.xaml
    /// </summary>
    public partial class BT : Window
    {
        List<Item> items;
        double total = 0;
        public BT()
        {
            InitializeComponent();
            items = new List<Item>();
           
        }

        //Checkout Button
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Startupx_dbDataContext dc = new Startupx_dbDataContext();
            //Insert Invoice
            Invoice i = new Invoice();
            i.barcode = (string)lb_barcode.Content;
            i.date = DateTime.Now.Date;
            i.total = double.Parse((string)lb_total.Content);
            i.tax = 14.5;
            i.discount = 20;
            i.total_amount = i.total - i.discount + i.tax;
            i.user_id = 1;
            dc.Invoices.InsertOnSubmit(i);
            dc.SubmitChanges();


            //Opening the Client details form           
            var invoice = (from inv in dc.Invoices
                             where inv.barcode.Equals(lb_barcode.Content)
                             select inv.id).Single();
            var invoice_id = Convert.ToInt32(invoice);
            Add_Checkout c = new Add_Checkout(invoice_id);
            c.ShowDialog();
        }


        //Search by barcode button
        private void bt_Search_Button(object sender, RoutedEventArgs e)
        {
            Startupx_dbDataContext dc = new Startupx_dbDataContext(); ;
            var item = (from i in dc.Items
                        where i.barcode.Equals(txt_search.Text)                        
                        select i).Single() as Item;
            items.Add(item);
            dg_selected_items.Items.Clear();            
            dg_selected_items.ItemsSource = items;
        }


        //Creating a new Invoice
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            items.Clear();
            lb_total.Content = "Total";
            total = 0;
            Startupx_dbDataContext dc = new Startupx_dbDataContext();
            //Generating the invoice barcode
            Barcode bc = new Barcode();
            string currentDate = DateTime.UtcNow.ToString();
            string barcode = dc.fn_generate_barcode(currentDate);
            bc.GenerateBarcode(barcode, img_barcode, lb_barcode);
        }

        //Event for taking the changed cell value
       private void dg_selected_items_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            total += double.Parse(((TextBox)e.EditingElement).Text);
            lb_total.Content = total;
           
        }

        
    }
}
