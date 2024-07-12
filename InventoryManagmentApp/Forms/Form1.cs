using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace InventoryManagmentApp
{
    public partial class Form1 : Form
    {

        string Data = "";
        public Form1()
        {
            InitializeComponent();

            

            iconButton1.Parent = PanelSideMenu;
            iconButton1.BackColor = Color.Transparent;

            //bunifuDatavizAdvanced1.colorSet.Add(Color.FromArgb(138, 199, 64));

            



        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPictureBox3_Click(object sender, EventArgs e)
        {
            //Close Button
            this.Hide();

        }

        private void bunifuPictureBox1_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            if (PanelSideMenu.Width == 156)
            {
                PanelSideMenu.Visible = false;
                PanelSideMenu.Width = 50;
                bunifuTransition1.ShowSync(PanelSideMenu);
                bunifuTransition2.ShowSync(iconButton1);
            }
            else
            {
                PanelSideMenu.Visible = false;
                PanelSideMenu.Width = 156;
                bunifuTransition1.ShowSync(PanelSideMenu);
                bunifuTransition2.ShowSync(iconButton1);
            }
        }

        private void bunifuPictureBox4_Click(object sender, EventArgs e)
        {

        }
        private void ChartDelay_Tick(object sender, EventArgs e)
        {
            RenderbunifuDatavizAdvanced1();
            Chat();
        }

        public void Chat()
        {
            chart1.Series[0].XValueMember = "OrderID";
            chart1.Series[0].YValueMembers = "TotalPrice";

            

            chart1.DataSource = databaseDataSet3.PurchaseOrder;
            chart1.DataBind();

        }

        public void RenderbunifuDatavizAdvanced1()
        {
            Bunifu.Dataviz.WinForms.BunifuDatavizAdvanced.Canvas Canvas = new Bunifu.Dataviz.WinForms.BunifuDatavizAdvanced.Canvas();
            Bunifu.Dataviz.WinForms.BunifuDatavizAdvanced.DataPoint DataPoint = new Bunifu.Dataviz.WinForms.BunifuDatavizAdvanced.DataPoint(Bunifu.Dataviz.WinForms.BunifuDatavizAdvanced._type.Bunifu_splineArea);

            DataPoint.addLabely("Day-01", 53);
            DataPoint.addLabely("Day-02", 24);
            DataPoint.addLabely("Day-03", 45);
            DataPoint.addLabely("Day-04", 65);
            DataPoint.addLabely("Day-05", 53);
            DataPoint.addLabely("Day-06", 22);
            DataPoint.addLabely("Day-07", 56);
            DataPoint.addLabely("Day-08", 36);
            DataPoint.addLabely("Day-09", 67);
            DataPoint.addLabely("Day-10", 5);
            DataPoint.addLabely("Day-11", 25);
            DataPoint.addLabely("Day-12", 99);
            DataPoint.addLabely("Day-13", 39);
            DataPoint.addLabely("Day-14", 29);
            DataPoint.addLabely("Day-15", 37);
            DataPoint.addLabely("Day-16", 97);
            DataPoint.addLabely("Day-17", 29);
            DataPoint.addLabely("Day-18", 58);
            DataPoint.addLabely("Day-19", 27);
            DataPoint.addLabely("Day-20", 59);

            Canvas.addData(DataPoint);
            //bunifuDatavizAdvanced1.Render(Canvas);
        }

        private void bunifuPanel5_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            BunifuPage.PageTitle = "TabPage01";
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            BunifuPage.PageTitle = "TabPage02";

        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            BunifuPage.PageTitle = "TabPage03";

        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            BunifuPage.PageTitle = "TabPage04";
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            BunifuPage.PageTitle = "TabPage05";
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            BunifuPage.PageTitle = "TabPage06";
        }

        private void bunifuPictureBox8_Click(object sender, EventArgs e)
        {
            UpdateProduct ObjUpdateProduct = new UpdateProduct();

            ObjUpdateProduct.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void bunifuButton7_Click(object sender, EventArgs e)
        {
            SqlConnection ObjConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Connect Timeout=30");
            string qry = "DELETE FROM Product WHERE ProductCode='" + Data + "'";
            SqlCommand ObjCommand = new SqlCommand(qry, ObjConnection);
            ObjConnection.Open();
            ObjCommand.ExecuteNonQuery();
            ShowData();
        }

        //Show Products In Data Grid view
        public void ShowData()
        {

            this.productTableAdapter1.Fill(this.databaseDataSet2.Product);
            SqlConnection ObjConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Connect Timeout=30");

            string QryGetData = "SELECT * FROM Product";
            SqlDataAdapter ObjDataAdaptor = new SqlDataAdapter(QryGetData, ObjConnection);

            Database.DatabaseDataSet ObjDataSet = new Database.DatabaseDataSet();
            ObjDataSet.Clear();

            ObjDataAdaptor.Fill(ObjDataSet, "ProductsDataset");
            DataGridProducts.DataSource = ObjDataSet.Tables["ProductsTable"];
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'databaseDataSet3.PurchaseOrder' table. You can move, or remove it, as needed.
            this.purchaseOrderTableAdapter.Fill(this.databaseDataSet3.PurchaseOrder);
            // TODO: This line of code loads data into the 'dataSetToChart.PurchaseOrder' table. You can move, or remove it, as needed.

            // TODO: This line of code loads data into the 'dataSetToCategoryGrid.Category' table. You can move, or remove it, as needed.
            this.categoryTableAdapter.Fill(this.dataSetToCategoryGrid.Category);
            // TODO: This line of code loads data into the 'dataSetToVendorDataGrid.Vendor' table. You can move, or remove it, as needed.
            this.vendorTableAdapter.Fill(this.dataSetToVendorDataGrid.Vendor);
            // TODO: This line of code loads data into the 'databaseDataSet2.Product' table. You can move, or remove it, as needed.
            this.productTableAdapter1.Fill(this.databaseDataSet2.Product);
            ShowData();
            ShowOrderInfo();
            GetCountOfCriticalStocks();
            GetCountOfInStock();
            GetCountOfSoldItems();
            GetTotalSales();

        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            ShowData();
            GetCountOfCriticalStocks();
            GetCountOfInStock();
            GetCountOfSoldItems();


        }

        //Filter Products
        private void BtnFilterProducts_Click(object sender, EventArgs e)
        {
            SqlConnection ObjConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Connect Timeout=30");

            string QryGetData = "SELECT * FROM Product Where ProductName LIKE '%"+TextSearchBox.Text+"%'";
            SqlDataAdapter ObjDataAdaptor = new SqlDataAdapter(QryGetData, ObjConnection);

            Database.DatabaseDataSet ObjDataSet = new Database.DatabaseDataSet();
            ObjDataSet.Clear();

            ObjDataAdaptor.Fill(ObjDataSet, "Products");
            DataGridProducts.DataSource = ObjDataSet.Tables["Products"];

        }

        private void PanelTopBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            
            
        }

        private void DataGridProducts_Click(object sender, EventArgs e)
        {

        }

        private void DataGridProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Data = DataGridProducts.CurrentRow.Cells[0].Value.ToString();
            
        }

        private void bunifuPictureBox1_Click_1(object sender, EventArgs e)
        {
            SqlConnection ObjConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Connect Timeout=30");
            string qry = "DELETE FROM Product WHERE ProductCode='" + Data + "'";
            SqlCommand ObjCommand = new SqlCommand(qry, ObjConnection);
            ObjConnection.Open();
            ObjCommand.ExecuteNonQuery();
            ShowData();
        }

        private void bunifuPictureBox9_Click(object sender, EventArgs e)
        {
            SqlConnection ObjConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Connect Timeout=30");

            if (ToggleStock.Value==true)
            {
                string qry = "UPDATE Product SET ProductQty=ProductQty+'" + TextRestockAmount.Text + "'WHERE ProductCode='" + Data + "'";
                SqlCommand ObjCommand = new SqlCommand(qry, ObjConnection);
                ObjConnection.Open();
                ObjCommand.ExecuteNonQuery();
                ShowData();
            }
            else
            {
                string qry = "UPDATE Product SET ProductQty=ProductQty-'" + TextRestockAmount.Text + "'WHERE ProductCode='" + Data + "'";
                SqlCommand ObjCommand = new SqlCommand(qry, ObjConnection);
                ObjConnection.Open();
                ObjCommand.ExecuteNonQuery();
                ShowData();
            }
            
        }

        private void bunifuPanel6_Click(object sender, EventArgs e)
        {

        }

        private void bunifuDatavizAdvanced1_Load(object sender, EventArgs e)
        {

        }

        private void bunifuLabel9_Click(object sender, EventArgs e)
        {

        }

        private void ToggleStock_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuToggleSwitch.CheckedChangedEventArgs e)
        {
            
        }

        private void PanelFormBack_Click(object sender, EventArgs e)
        {

        }

        private void BtnVendorAdd_Click(object sender, EventArgs e)
        {
           if(TextVendorID.Text!="")
            {
                
                try
                {
                    SqlConnection ObjConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Connect Timeout=30");
                    string QryInsert = "INSERT INTO Vendor VALUES('" + TextVendorID.Text + "','" + TextVendorName.Text + "','" + TextVendorContact.Text + "','" + TextVendorAdLine01.Text + "','" + TextVendorAdLine02.Text + "','" + TextVendorCity.Text + "')";

                    SqlCommand ObjCommand = new SqlCommand(QryInsert, ObjConnection);
                    ObjConnection.Open();
                    ObjCommand.ExecuteNonQuery();

                    //clear textboxes if not any exeptions are occured.
                    TextVendorID.Clear();
                    TextVendorName.Clear();
                    TextVendorContact.Clear();
                    TextVendorAdLine01.Clear();
                    TextVendorAdLine02.Clear();
                    TextVendorCity.Clear();
                }

                catch (SqlException ex1)
                {
                    MessageBox.Show("Error Occured!" + Convert.ToString(ex1), "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                catch (FormatException ex2)
                {
                    MessageBox.Show("Error Occured!" + Convert.ToString(ex2), "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                finally
                {
                    ShowVendorInfo();
                }

            }
            else
            {
                MessageBox.Show("Fill The Vendor Details In Vendor Information form","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }
        private void ShowVendorInfo()
        {
            SqlConnection ObjConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Connect Timeout=30");
            string QryInsert = "SELECT * FROM Vendor";

            SqlDataAdapter ObjDataAdaptor = new SqlDataAdapter(QryInsert,ObjConnection);
            Database.DatabaseDataSet ObjDataSet = new Database.DatabaseDataSet();
            ObjDataSet.Clear();
            ObjDataAdaptor.Fill(ObjDataSet, "Vendor");
            DataGridVendor.DataSource = ObjDataSet.Tables["Vendor"];

        }

        private void BtnVendorDelete_Click(object sender, EventArgs e)
        {
            SqlConnection ObjConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Connect Timeout=30");
            string qry = "DELETE FROM Vendor WHERE VendorID='" + Data + "'";
            SqlCommand ObjCommand = new SqlCommand(qry, ObjConnection);
            ObjConnection.Open();
            ObjCommand.ExecuteNonQuery();
            ShowVendorInfo();
        }

        private void DataGridVendor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Data = DataGridVendor.CurrentRow.Cells[0].Value.ToString();

            TextVendorID.Text = DataGridVendor.CurrentRow.Cells[0].Value.ToString();
            TextVendorName.Text = DataGridVendor.CurrentRow.Cells[1].Value.ToString();
            TextVendorContact.Text = DataGridVendor.CurrentRow.Cells[2].Value.ToString();
            TextVendorAdLine01.Text = DataGridVendor.CurrentRow.Cells[3].Value.ToString();
            TextVendorAdLine02.Text = DataGridVendor.CurrentRow.Cells[4].Value.ToString();
            TextVendorCity.Text = DataGridVendor.CurrentRow.Cells[5].Value.ToString();
        }

        private void BtnVendorUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection ObjConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Connect Timeout=30");
            string qry = "UPDATE Vendor SET VendorName='"+TextVendorName.Text+ "',VendorContact='" + TextVendorContact.Text + "',AddressLine01='" + TextVendorAdLine01.Text + "',AddressLine02='" + TextVendorAdLine02.Text + "',City='" + TextVendorCity.Text + "' WHERE VendorID='"+TextVendorID.Text+"'";
            SqlCommand ObjCommand = new SqlCommand(qry, ObjConnection);
            ObjConnection.Open();
            ObjCommand.ExecuteNonQuery();
            ShowVendorInfo();
        }

        private void BtnRefreshVendor_Click(object sender, EventArgs e)
        {
            ShowVendorInfo();
        }

        private void BtnSearchVendor_Click(object sender, EventArgs e)
        {
            SqlConnection ObjConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Connect Timeout=30");
            string QryInsert = "SELECT * FROM Vendor WHERE VendorID='"+TextSearchVendor.Text+"'";

            SqlDataAdapter ObjDataAdaptor = new SqlDataAdapter(QryInsert, ObjConnection);
            Database.DatabaseDataSet ObjDataSet = new Database.DatabaseDataSet();
            ObjDataSet.Clear();
            ObjDataAdaptor.Fill(ObjDataSet, "Vendor");
            DataGridVendor.DataSource = ObjDataSet.Tables["Vendor"];
        }

        private void BtnAddCategory_Click(object sender, EventArgs e)
        {
            SqlConnection ObjConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Connect Timeout=30");
            string qry = "INSERT INTO Category VALUES('" + TextCategoryCode.Text + "','" + TextCategoryName.Text + "')";
            SqlCommand ObjCommand = new SqlCommand(qry, ObjConnection);

            ObjConnection.Open();
            ObjCommand.ExecuteNonQuery();

            TextCategoryCode.Clear();
            TextCategoryName.Clear();

            ShowCategoryInfo();
        }

        private void ShowCategoryInfo()
        {
            SqlConnection ObjConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Connect Timeout=30");
            string qry = "SELECT * FROM Category";
            
            SqlDataAdapter ObjDataAdaptor = new SqlDataAdapter(qry,ObjConnection);
            Database.DatabaseDataSet ObjDataSet = new Database.DatabaseDataSet();
            ObjDataSet.Clear();
            ObjDataAdaptor.Fill(ObjDataSet, "Category");
            DataGridCategory.DataSource = ObjDataSet.Tables["Category"];
        }

        private void DataGridCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Data = DataGridCategory.CurrentRow.Cells[0].Value.ToString();

            TextCategoryCode.Text = DataGridCategory.CurrentRow.Cells[0].Value.ToString();
            TextCategoryName.Text = DataGridCategory.CurrentRow.Cells[1].Value.ToString();

        }

        private void BtnDeleteCategory_Click(object sender, EventArgs e)
        {
            SqlConnection ObjConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Connect Timeout=30");
            string qry = "DELETE FROM Category WHERE CategoryCode='" +Data+ "'";
            SqlCommand ObjCommand = new SqlCommand(qry, ObjConnection);

            ObjConnection.Open();
            ObjCommand.ExecuteNonQuery();

            TextCategoryCode.Clear();
            TextCategoryName.Clear();

            ShowCategoryInfo();

        }

        private void BtnUpdateCategory_Click(object sender, EventArgs e)
        {
            SqlConnection ObjConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Connect Timeout=30");
            string qry = "UPDATE Category SET CategoryName='"+TextCategoryName.Text+"'WHERE CategoryCode='" + Data + "'";
            SqlCommand ObjCommand = new SqlCommand(qry, ObjConnection);

            ObjConnection.Open();
            ObjCommand.ExecuteNonQuery();

            TextCategoryCode.Clear();
            TextCategoryName.Clear();

            ShowCategoryInfo();

        }

        private void LblSearchCategory_Click(object sender, EventArgs e)
        {
            SqlConnection ObjConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Connect Timeout=30");
            string QryInsert = "SELECT * FROM Category WHERE CategoryCode='" + TextSearchCategory.Text + "'";

            SqlDataAdapter ObjDataAdaptor = new SqlDataAdapter(QryInsert, ObjConnection);
            Database.DatabaseDataSet ObjDataSet = new Database.DatabaseDataSet();
            ObjDataSet.Clear();
            ObjDataAdaptor.Fill(ObjDataSet, "Category");
            DataGridCategory.DataSource = ObjDataSet.Tables["Category"];

            
        }

        private void LblRefreshCategory_Click(object sender, EventArgs e)
        {
            ShowCategoryInfo();
            TextSearchCategory.Clear();
        }


        private void ShowOrderInfo()
        {
            SqlConnection ObjConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Connect Timeout=30");
            string QryInsert = "SELECT PurchaseOrder.OrderID,OrderProduct.ProductCode,OrderProduct.OrderQty,OrderProduct.Price,PurchaseOrder.OrderDate,PurchaseOrder.OrderIssuerID,PurchaseOrder.CustomerFName,PurchaseOrder.CustomerLName,PurchaseOrder.CustomerContact,PurchaseOrder.PaymentMethod,PurchaseOrder.DiscountCode FROM PurchaseOrder INNER JOIN OrderProduct ON(PurchaseOrder.OrderID=OrderProduct.OrderID) ORDER BY PurchaseOrder.OrderID";

            SqlDataAdapter ObjDataAdaptor = new SqlDataAdapter(QryInsert, ObjConnection);
            Database.DatabaseDataSet ObjDataSet = new Database.DatabaseDataSet();
            ObjDataSet.Clear();
            ObjDataAdaptor.Fill(ObjDataSet,"Order");
            DataGridOrders.DataSource = ObjDataSet.Tables["Order"];
        }

       

        private void bunifuButton8_Click(object sender, EventArgs e)
        {
            ShowOrderInfo();
        }

        private void BtnIssueABill_Click_1(object sender, EventArgs e)
        {
            Form2 ObjForm2 = new Form2();
            ObjForm2.Show();
        }

        private void bunifuButton9_Click(object sender, EventArgs e)
        {
            SqlConnection ObjConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Connect Timeout=30");
            string QryInsert = "SELECT PurchaseOrder.OrderID,OrderProduct.ProductCode,OrderProduct.OrderQty,OrderProduct.Price,PurchaseOrder.OrderDate,PurchaseOrder.OrderIssuerID,PurchaseOrder.CustomerFName,PurchaseOrder.CustomerLName,PurchaseOrder.CustomerContact,PurchaseOrder.PaymentMethod,PurchaseOrder.DiscountCode FROM PurchaseOrder INNER JOIN OrderProduct ON(PurchaseOrder.OrderID=OrderProduct.OrderID) WHERE PurchaseOrder.OrderID='" + TextSearchOrder.Text+ "' OR PurchaseOrder.CustomerFName='" + TextSearchOrder.Text + "' ORDER BY PurchaseOrder.OrderID";

            SqlDataAdapter ObjDataAdaptor = new SqlDataAdapter(QryInsert, ObjConnection);
            Database.DatabaseDataSet ObjDataSet = new Database.DatabaseDataSet();
            ObjDataSet.Clear();
            ObjDataAdaptor.Fill(ObjDataSet, "Order");
            DataGridOrders.DataSource = ObjDataSet.Tables["Order"];
        }

        private void BtnFilterOrdersByDate_Click(object sender, EventArgs e)
        {
            System.DateTime FromDate = default(System.DateTime);
            FromDate = DatePickerFrom.Value;
            System.DateTime TillDate = default(System.DateTime);
            TillDate = DatePickerTill.Value;

            SqlConnection ObjConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Connect Timeout=30");
            string QryInsert = "SELECT PurchaseOrder.OrderID,OrderProduct.ProductCode,OrderProduct.OrderQty,OrderProduct.Price,PurchaseOrder.OrderDate,PurchaseOrder.OrderIssuerID,PurchaseOrder.CustomerFName,PurchaseOrder.CustomerLName,PurchaseOrder.CustomerContact,PurchaseOrder.PaymentMethod,PurchaseOrder.DiscountCode FROM PurchaseOrder INNER JOIN OrderProduct ON(PurchaseOrder.OrderID=OrderProduct.OrderID) WHERE PurchaseOrder.OrderDate BETWEEN '"+FromDate+"' AND '"+TillDate+"'ORDER BY PurchaseOrder.OrderID";

            SqlDataAdapter ObjDataAdaptor = new SqlDataAdapter(QryInsert, ObjConnection);
            Database.DatabaseDataSet ObjDataSet = new Database.DatabaseDataSet();
            ObjDataSet.Clear();
            ObjDataAdaptor.Fill(ObjDataSet, "Order");
            DataGridOrders.DataSource = ObjDataSet.Tables["Order"];
        }

        private void BtnCriticalStock_Click(object sender, EventArgs e)
        {
            
        }

        int CriticalStockLevel = 10;

        private void iconButton2_Click(object sender, EventArgs e)
        {
            SqlConnection ObjConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Connect Timeout=30");

            string QryGetData = "SELECT * FROM Product Where ProductQty<='" + CriticalStockLevel + "'";
            SqlDataAdapter ObjDataAdaptor = new SqlDataAdapter(QryGetData, ObjConnection);

            Database.DatabaseDataSet ObjDataSet = new Database.DatabaseDataSet();
            ObjDataSet.Clear();

            ObjDataAdaptor.Fill(ObjDataSet, "Products");
            DataGridProducts.DataSource = ObjDataSet.Tables["Products"];
        }

        private void GetCountOfCriticalStocks()
        {
            SqlConnection ObjConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Connect Timeout=30");

            string Qry = "SELECT COUNT (*) FROM Product Where ProductQty<='" + CriticalStockLevel + "'";
            SqlCommand Com = new SqlCommand(Qry, ObjConnection);
            ObjConnection.Open();
            int Count= Convert.ToInt32(Com.ExecuteScalar());
            LblCriticalStockCount.Text = Count.ToString();
            
        }
        private void GetCountOfInStock()
        {
            SqlConnection ObjConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Connect Timeout=30");

            string Qry = "SELECT COUNT (*) FROM Product Where ProductQty>0";
            SqlCommand Com = new SqlCommand(Qry, ObjConnection);
            ObjConnection.Open();
            int Count = Convert.ToInt32(Com.ExecuteScalar());
            BtnInStockCount.Text = Count.ToString();

        }

        private void GetCountOfSoldItems()
        {
            SqlConnection ObjConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Connect Timeout=30");

            string Qry = "SELECT DISTINCT COUNT(ProductCode) FROM OrderProduct";
            SqlCommand Com = new SqlCommand(Qry, ObjConnection);
            ObjConnection.Open();
            int Count = Convert.ToInt32(Com.ExecuteScalar());
            BtnSoldItemsCount.Text = Count.ToString();
        }

        private void GetTotalSales()
        {
            SqlConnection ObjConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Connect Timeout=30");

            string Qry = "SELECT SUM(TotalPrice) FROM PurchaseOrder";
            SqlCommand Com = new SqlCommand(Qry, ObjConnection);
            ObjConnection.Open();
            string Count = Convert.ToString(Com.ExecuteScalar());

            if(Count!="")
            {
                BtnSalesCount.Text = Count.ToString();
            }else
            {
                BtnSalesCount.Text = "00000.00";
            }
            
        }
    }
}
