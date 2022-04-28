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
    /// Interaction logic for Add_Stock.xaml
    /// </summary>
    public partial class Add_Stock : Window
    {
        string barcode;
        public Add_Stock(string barcode)
        {
            InitializeComponent();
            this.barcode = barcode;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int stock = Convert.ToInt32(txt_stock.Text);
                Startupx_dbDataContext dc = new Startupx_dbDataContext();
                dc.sp_update_item_stock(barcode, stock);
                MessageBox.Show("Stock updated", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Something wrong", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
    }
}
