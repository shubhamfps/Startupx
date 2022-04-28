using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Startupx.Billing
{
    public partial class BillingModule : Form
    {
        public BillingModule()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Y.C.Patel\Documents\smarketdb.mdf;Integrated Security=True;Connect Timeout=30");

        //random number for invoice_Id
        public int random()
        {
            Random rnd = new Random();
            int invoice_Id = rnd.Next(100, 100000);
            return invoice_Id;
        }
        
        //exit the application
        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //sql connection string
        SqlConnection con1 = new SqlConnection(@"Data Source=sqlserver8935.database.windows.net;Initial Catalog=business_solutiondb;Persist Security Info=True;User ID=sqluser8935;Password=SQL_server8935");

        //populate function for products
        private void populate()
        {
            con1.Open();
            string query = "select name, price from business_solutiondb.Item";
            SqlDataAdapter sda = new SqlDataAdapter(query, con1);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            PRDDGV.DataSource = ds.Tables[0];
            con1.Close();
        }

        //populate function for invoice
        private void populateBill()
        {
            con1.Open();
            string query = "select * from InvoiceBill";
            SqlDataAdapter sda = new SqlDataAdapter(query, con1);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            SellListDGV.DataSource = ds.Tables[0];
            con1.Close();
        }
        
        
        //"add" click event
        private void button4_Click(object sender, EventArgs e)
        {
            if (BillId.Text == "" && CName.Text=="")

            {
                MessageBox.Show("Missing Bill Id and Customer Name" );
            }
            else
            {


                try
                {
                    int invoice_Id = random();
                    con1.Open();
                    if (PaymentMethod.SelectedIndex==-1)
                    {
                        MessageBox.Show("Please Select Payment Method");
                    }
                    else
                    {
                        string query = "insert into InvoiceBill values('" + BillId.Text + "','" + CName.Text + "','" + invoice_Id + "','" + DateLbl.Text + "','" + AmtLbl.Text + "','" + PaymentMethod.SelectedItem + "')";
                        SqlCommand cmd = new SqlCommand(query, con1);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Invoice Added Successfully");
                        
                    }
                    con1.Close();
                    populateBill();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
        }
        
        //when load the page it will populate the results
        private void BillingModule_Load(object sender, EventArgs e)
        {
            populate();
            populateBill();
        }

        //"Next" click event
        private void button7_Click(object sender, EventArgs e)
        {
            BillId.Text = "";
            CName.Text = "";
            ORDERDGV.Rows.Clear();
            AmtLbl.Text = ".";
        }

        //"print" click event for the invoice 
        private void button6_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            DialogResult result = printPreviewDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        //print document1 that will go to print click event
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Welcome To The STARTUPX Shop", new Font("Century Gothic", 25, FontStyle.Bold), Brushes.Red, new Point(230));
            e.Graphics.DrawString("Bill Id: " + SellListDGV.SelectedRows[0].Cells[0].Value.ToString(), new Font("Century Gothic", 15, FontStyle.Bold), Brushes.Blue, new Point(100, 70));
            e.Graphics.DrawString("Customer Name: " + SellListDGV.SelectedRows[0].Cells[1].Value.ToString(), new Font("Century Gothic", 15, FontStyle.Bold), Brushes.Blue, new Point(100, 130));
            e.Graphics.DrawString("Invoice Id: " + SellListDGV.SelectedRows[0].Cells[2].Value.ToString(), new Font("Century Gothic", 15, FontStyle.Bold), Brushes.Blue, new Point(100, 100));
            e.Graphics.DrawString("Date: " + SellListDGV.SelectedRows[0].Cells[3].Value.ToString(), new Font("Century Gothic", 15, FontStyle.Bold), Brushes.Blue, new Point(100, 160));
            e.Graphics.DrawString("Total Amount: " + SellListDGV.SelectedRows[0].Cells[4].Value.ToString() +" $", new Font("Century Gothic", 15, FontStyle.Bold), Brushes.Blue, new Point(100, 190));
            e.Graphics.DrawString("Payment Method is : " + SellListDGV.SelectedRows[0].Cells[5].Value.ToString(), new Font("Century Gothic", 15, FontStyle.Bold), Brushes.Blue, new Point(100, 220));
        }
        
        //print document2 that will go to print bill click event
        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics gp = e.Graphics;
            Font font = new Font("Courier New", 14);
            Font font1 = new Font("Courier New", 10);
            float fontheight = font.GetHeight();
            int sx = 190;
            int sy = 50;
            float offset = 30;
            float leftmargin = e.MarginBounds.Left;
            float topmargin = e.MarginBounds.Top;
            con1.Open();
            string query = "select invoiceid from InvoiceBill where Billid="+ BillId.Text;
            SqlCommand cmd = new SqlCommand(query,con1);
            Int32 invoice_Id = Convert.ToInt32(cmd.ExecuteScalar());
            
            e.Graphics.DrawString("Welcome To The StartUPX Shop", new Font("Century Gothic", 17), Brushes.Black, sx, sy);

            string top = "Date:" + DateLbl.Text.PadRight(5);
            
            gp.DrawString(top + "                     " + "Invoice Id:" + invoice_Id + "" , font, new SolidBrush(Color.Black), sx, sy + offset);
            offset = offset + fontheight;
            gp.DrawString("Customer Name : "  + CName.Text + " ", font, new SolidBrush(Color.Black), sx, sy + offset);
            offset = offset + 30;
            gp.DrawString("=====================================================", font, new SolidBrush(Color.Black), sx, sy + offset);
            offset = offset + 18;
            gp.DrawString("Name, Price, Qty, Discount, Tax and Total of the Products", new Font("Courier New", 12), new SolidBrush(Color.Black), sx, sy + offset);
            offset = offset + 15;

            int y = 1;
            //for loop for product
            for (int t = 0; t < ORDERDGV.Rows.Count - 1; t++)
            {
                gp.DrawString("-------------------------------------------------------------", font1, new SolidBrush(Color.Black), sx, sy + offset);
                offset = offset + 12;
                gp.DrawString("Product " + y + " :" + ORDERDGV.Rows[t].Cells[1].Value?.ToString(), font1, new SolidBrush(Color.Black), sx, sy + offset);
                offset = offset + 12;
                gp.DrawString("Price     :" + ORDERDGV.Rows[t].Cells[2].Value?.ToString() + "$", font1, new SolidBrush(Color.Black), sx, sy + offset);
                offset = offset + 12;
                gp.DrawString("Qty       :" + ORDERDGV.Rows[t].Cells[3].Value?.ToString(), font1, new SolidBrush(Color.Black), sx, sy + offset);
                offset = offset + 12;
                gp.DrawString("Discount  :" + ORDERDGV.Rows[t].Cells[4].Value?.ToString(), font1, new SolidBrush(Color.Black), sx, sy + offset);
                offset = offset + 12;
                gp.DrawString("Tax       :" + ORDERDGV.Rows[t].Cells[5].Value?.ToString(), font1, new SolidBrush(Color.Black), sx, sy + offset);
                offset = offset + 12;
                gp.DrawString("Total     :" + ORDERDGV.Rows[t].Cells[6].Value?.ToString() + ".$", font1, new SolidBrush(Color.Black), sx, sy + offset);
                offset = offset + 12;
                gp.DrawString("-------------------------------------------------------------", font1, new SolidBrush(Color.Black), sx, sy + offset);
                y++;
            }
            
            offset = offset + 15;
            gp.DrawString("=====================================================", font, new SolidBrush(Color.Black), sx, sy + offset);
            offset = offset + 15;
            gp.DrawString("Payment Method is " + PaymentMethod.SelectedItem.ToString(), font, new SolidBrush(Color.Black), sx, sy + offset);
            offset = offset + 20;
            gp.DrawString("Grand Total is : " + AmtLbl.Text.ToString() + " $", new Font("Courier New", 25), new SolidBrush(Color.Black), sx, sy + offset);
            
            //Clear the fields after Print the bill
            BillId.Text = "";
            CName.Text = "";
            ORDERDGV.Rows.Clear();
            AmtLbl.Text = ".";
            PaymentMethod.SelectedIndex = -1;
            con1.Close();

        }

        //"Print Bill" click event
        private void button2_Click(object sender, EventArgs e)
        {
            /*printDialog1.Document = printDocument2;*/
            printDialog1.Document = printDocument2;
            //DialogResult result = printPreviewDialog2.ShowDialog();
            DialogResult result = printDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                printDocument2.Print();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }

        private void DateLbl_Click(object sender, EventArgs e)
        {

        }

        //date
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            DateLbl.Text = DateTime.Today.Day.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString();
        }

        //exit the application
        private void button8_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //"Delete" click event
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                
                
                    con1.Open();
                    string query = "delete from InvoiceBill where Billid = " + SellListDGV.SelectedRows[0].Cells[0].Value;
                    SqlCommand cmd = new SqlCommand(query, con1);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Invoice Deleted Successfully");
                    con1.Close();
                    populateBill();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            
        }

        private void ProdGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //Product grid view that direct select the item from gridview
        private void PRDDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            ProdName.Text = PRDDGV.SelectedRows[0].Cells[0].Value.ToString();
            
            ProdPrice.Text = PRDDGV.SelectedRows[0].Cells[1].Value.ToString();
        }
        

        private void button5_Click_2(object sender, EventArgs e)
        {
            
        }

        //"Add Product" click event
        double Grdtotal, n;
        private void button1_Click(object sender, EventArgs e)
        {
            if (ProdName.Text == "" || PQnt.Text == "" || PDiscount.Text == "" || PTax.Text == "")
            {
                MessageBox.Show("Missing the Data");
            }
            else
            {

                Double total = Convert.ToDouble(ProdPrice.Text) * Convert.ToDouble(PQnt.Text);
                Double dis = Convert.ToDouble(PDiscount.Text);
                Double tax = Convert.ToDouble(PTax.Text);
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(ORDERDGV);
                newRow.Cells[0].Value = n + 1;
                newRow.Cells[1].Value = ProdName.Text;
                newRow.Cells[2].Value = ProdPrice.Text;
                newRow.Cells[3].Value = PQnt.Text;
                newRow.Cells[4].Value = dis;
                newRow.Cells[5].Value = tax;
                double ttl = total - ((dis * total) / 100) + ((tax * total) / 100);
                newRow.Cells[6].Value = ttl;
                ORDERDGV.Rows.Add(newRow);
                n++;
                total = ttl;
                Grdtotal = Grdtotal + total;
                AmtLbl.Text = "" + Grdtotal;
                ProdName.Text = "";
                ProdPrice.Text = "";
                PQnt.Text = "";
                PDiscount.Text = "";
                PTax.Text = "";
            }
        }
    }
}
