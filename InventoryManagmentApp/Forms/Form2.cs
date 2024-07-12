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

namespace InventoryManagmentApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            LblDate.Text = DateTime.Now.ToLongDateString();
            LblTime.Text = DateTime.Now.ToLongTimeString();
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Timer.Start();
            ShowProductInfo();
        }

        private void BtnPassData_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection ObjCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Connect Timeout=30");
                string Qry = "INSERT INTO OrderProduct(OrderID,ProductCode) VALUES('" + TextCustomerFName.Text + "','" + TextCustomerLName.Text + "')";
                SqlCommand ObjCom = new SqlCommand(Qry, ObjCon);

                ObjCon.Open();
                ObjCom.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void bunifuPictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ShowProductInfo()
        {
            SqlConnection ObjCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Connect Timeout=30");
            string Qry = "SELECT ProductCode,ProductName,ProductUnitPrice FROM Product";

            SqlDataAdapter ObjDataAdaptor = new SqlDataAdapter(Qry,ObjCon);
            Database.DatabaseDataSet ObjDataSet = new Database.DatabaseDataSet();

            ObjDataSet.Clear();

            ObjDataAdaptor.Fill(ObjDataSet, "ProductInfo");
            DataGridShowProduct.DataSource = ObjDataSet.Tables["ProductInfo"];
        }
        
        private void DataGridShowProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           

            
            MessageBox.Show("Product #" + DataGridShowAddedProducts.Rows.Count.ToString() + " Successfully Added!");
            DataGridViewRow newRow = new DataGridViewRow();

            newRow.CreateCells(DataGridShowAddedProducts);
            newRow.Cells[0].Value = DataGridShowProduct.CurrentRow.Cells[0].Value.ToString();
            newRow.Cells[1].Value = DataGridShowProduct.CurrentRow.Cells[1].Value.ToString();
            newRow.Cells[2].Value = DataGridShowProduct.CurrentRow.Cells[2].Value.ToString();

            
            DataGridShowAddedProducts.Rows.Add(newRow);


        }

        
        
        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void DataGridShowAddedProducts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        private void IconCalculateTotal_Click(object sender, EventArgs e)
        {
            TotalOfCart = 0;
            int RowCount = DataGridShowAddedProducts.RowCount;

            double UnitPrice = Convert.ToDouble(DataGridShowAddedProducts.CurrentRow.Cells[2].Value);
            double Quantity = Convert.ToDouble(DataGridShowAddedProducts.CurrentRow.Cells[4].Value);

            double TotalPrice = UnitPrice * Quantity;
            DataGridShowAddedProducts.CurrentRow.Cells[3].Value = TotalPrice;
            
            CalculateTotalOfCart();
        }

        double TotalOfCart = 0;
        private void CalculateTotalOfCart()
        {
            int RowCount = DataGridShowAddedProducts.RowCount;
            

            for (int i = 0; i < (RowCount - 1); i++)
            {
                TotalOfCart = TotalOfCart + Convert.ToDouble(DataGridShowAddedProducts.Rows[i].Cells[3].Value);
            }

            LblCartTotal.Text = TotalOfCart.ToString();

        }

        

        private void IconDeleteRecord_Click(object sender, EventArgs e)
        {
            int RowIndex = DataGridShowAddedProducts.CurrentRow.Index;
            Double TemPrice = Convert.ToDouble(DataGridShowAddedProducts.CurrentRow.Cells[3].Value);

            DataGridShowAddedProducts.Rows.Remove(DataGridShowAddedProducts.Rows[RowIndex]);

            TotalOfCart = TotalOfCart - TemPrice;
            LblCartTotal.Text = TotalOfCart.ToString();
        }

        private void IconPrintBill_Click(object sender, EventArgs e)
        {
            
            System.DateTime myDate = default(System.DateTime);
            myDate = DatePickerOrderDate.Value;
            
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Connect Timeout=30"))
                using (SqlCommand cmd = new SqlCommand("dbo.InsertOrderCommand", con))
                {
                    // tell ADO.NET it's a stored procedure (not inline SQL statements)
                    cmd.CommandType = CommandType.StoredProcedure;

                    // define parameters
                    cmd.Parameters.Add("@OrderID", SqlDbType.NChar, 06).Value = TextOrderID.Text;
                    cmd.Parameters.Add("@TotalPrice", SqlDbType.Money).Value = TotalOfCart;
                    cmd.Parameters.Add("@OrderDate", SqlDbType.Date).Value = myDate;
                    cmd.Parameters.Add("@DiscountCode", SqlDbType.NChar, 06).Value = TextDiscountCode.Text;
                    cmd.Parameters.Add("@OrderIssuerID", SqlDbType.NChar, 06).Value = TextIssuerID.Text;
                    cmd.Parameters.Add("@CustomerFName", SqlDbType.NChar, 30).Value = TextCustomerFName.Text;
                    cmd.Parameters.Add("@CustomerLName", SqlDbType.NChar, 30).Value = TextCustomerLName.Text;
                    cmd.Parameters.Add("@CustomerContact", SqlDbType.NChar, 10).Value = TextCustomerContact.Text;
                    cmd.Parameters.Add("@PaymentMethod", SqlDbType.NChar, 20).Value = DropDownPaymentMethod.Text;

                    // open connection, execute stored procedure, close connection again
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                TotalOfCart = 0;
                LblCartTotal.Text = "Cart Total";
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }

            PassOrderProductInfoToDatabase();
            ReduceStock();

        }
        private void PassOrderProductInfoToDatabase()
        {
            
            int RowCount = DataGridShowAddedProducts.RowCount;
            SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Connect Timeout=30");
            

            for (int i = 0; i < (RowCount - 1); i++)
            {
                string ProductCode = DataGridShowAddedProducts.Rows[i].Cells[0].Value.ToString();
                int OrderQty = Convert.ToInt32(DataGridShowAddedProducts.Rows[i].Cells[4].Value);
                double TotalPrice = Convert.ToDouble(DataGridShowAddedProducts.Rows[i].Cells[3].Value);
                string Qry = "INSERT INTO OrderProduct(OrderID,ProductCode,OrderQty,Price) VALUES('" + TextOrderID.Text + "','" + ProductCode + "','" + OrderQty + "','" + TotalPrice + "') ";
                SqlCommand Com = new SqlCommand(Qry, Con);
                Con.Open();
                Com.ExecuteNonQuery();
                Con.Close();


            }

        }

        private void BtnFilterProducts_Click(object sender, EventArgs e)
        {
            SqlConnection ObjCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Connect Timeout=30");
            string Qry = "SELECT ProductCode,ProductName,ProductUnitPrice FROM Product WHERE ProductName LIKE '%"+TextSearchBox.Text+"%'";

            SqlDataAdapter ObjDataAdaptor = new SqlDataAdapter(Qry, ObjCon);
            Database.DatabaseDataSet ObjDataSet = new Database.DatabaseDataSet();

            ObjDataSet.Clear();

            ObjDataAdaptor.Fill(ObjDataSet, "ProductInfo");
            DataGridShowProduct.DataSource = ObjDataSet.Tables["ProductInfo"];
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            ShowProductInfo();
        }

        private void ReduceStock()
        {
            int RowCount = DataGridShowAddedProducts.RowCount;
            SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Connect Timeout=30");

            for (int i = 0; i < (RowCount - 1); i++)
            {
                string ProductCode = DataGridShowAddedProducts.Rows[i].Cells[0].Value.ToString();
                int OrderQty = Convert.ToInt32(DataGridShowAddedProducts.Rows[i].Cells[4].Value);
               
                string Qry = "UPDATE Product SET ProductQty=ProductQty-'"+OrderQty+"' WHERE ProductCode='"+ProductCode+"' ";
                SqlCommand Com = new SqlCommand(Qry, Con);
                Con.Open();
                Com.ExecuteNonQuery();
                Con.Close();


            }
        }
    }
}
