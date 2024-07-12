using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace InventoryManagmentApp
{
    public partial class Admin_Panel : Form
    {

        

        public Admin_Panel()
        {
            InitializeComponent();

        }
        // 
        // Admin_Panel Load Event
        // 
        public void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSetToCategoryGrid.Category' table. You can move, or remove it, as needed.
            this.categoryTableAdapter.Fill(this.dataSetToCategoryGrid.Category);
            // TODO: This line of code loads data into the 'dataSetToVendorDataGrid.Vendor' table. You can move, or remove it, as needed.
            this.vendorTableAdapter.Fill(this.dataSetToVendorDataGrid.Vendor);

            ShowProductInfo();
            ShowOrderInfo();
            GetCountOfCriticalStocks();
            GetCountOfInStock();
            GetCountOfSoldItems();
            GetTotalSales();
            ShowUsersInfo();

        }
        // 
        // Admin_Panel Connection To Database
        // 

        SqlConnection ObjConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Connect Timeout=30");
        string Qry = "";
        // 
        // Admin_Panel Set User Name 
        // 
        string UserNameTemp;
        public void SetUserNameInTitleBar(string UserName)
        {
            LblUserNameOnTitleBar.Text = "Admin - " + UserName;
            UserNameTemp = UserName;

        }
        // 
        // Admin_Panel Close Button
        // 
        private void BtnCloseApplication_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        // 
        // Admin_Panel Slider Menu
        // 
        private void BtnSlider_Click(object sender, EventArgs e)
        {
            if (PanelSideMenu.Width == 156)
            {
                PanelSideMenu.Visible = false;
                PanelSideMenu.Width = 50;
                bunifuTransition1.ShowSync(PanelSideMenu);
                bunifuTransition2.ShowSync(BtnSlider);
            }
            else
            {
                PanelSideMenu.Visible = false;
                PanelSideMenu.Width = 156;
                bunifuTransition1.ShowSync(PanelSideMenu);
                bunifuTransition2.ShowSync(BtnSlider);
            }
        }

        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            GetCountOfCriticalStocks();                         //Refresh All 4 Widgets
            GetCountOfInStock();                               //Refresh All 4 Widgets
            GetCountOfSoldItems();                            //Refresh All 4 Widgets
            GetTotalSales();                                 //Refresh All 4 Widgets
            BunifuPage.PageTitle = "TabPage01";
        }

        private void BtnInventory_Click(object sender, EventArgs e)
        {
            BunifuPage.PageTitle = "TabPage02";
        }

        private void BtnVendors_Click(object sender, EventArgs e)
        {
            BunifuPage.PageTitle = "TabPage03";
        }

        private void BtnPurchaseOrders_Click(object sender, EventArgs e)
        {
            BunifuPage.PageTitle = "TabPage04";
        }

        private void BtnCategory_Click(object sender, EventArgs e)
        {
            BunifuPage.PageTitle = "TabPage05";
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            BunifuPage.PageTitle = "TabPage06";
        }
        private void BtnLogout_Click(object sender, EventArgs e)
        {
            Login_Page ObjForm3 = new Login_Page();
            ObjForm3.Show();
            this.Dispose();
        }
        // 
        // Dashboard Load Chart
        // 
        private void ChartDelay_Tick(object sender, EventArgs e)
        {
            LoadChartData();
            ChartDelay.Stop();
        }
        private void LoadChartData()
        {
            
            Qry = "SELECT TOP 20 ProductCode,SUM(OrderQty) AS Quantity FROM OrderProduct GROUP BY ProductCode";

            ObjConnection.Open();
            SqlCommand ObjCom = new SqlCommand(Qry, ObjConnection);
            SqlDataReader ObjDataReader = ObjCom.ExecuteReader();

            this.ChartSoldQty.Series["Sold Quantity"].Points.Clear();
            ChartSoldQty.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            while (ObjDataReader.Read())
            {
                this.ChartSoldQty.Series["Sold Quantity"].Points.AddXY(ObjDataReader["ProductCode"], ObjDataReader["Quantity"]);
            }
            ObjDataReader.Close();
            ObjConnection.Close();
        }
        // 
        // Dashboard Load All 4 Widgets
        // 
        private void GetCountOfCriticalStocks()
        {
            Qry = "SELECT COUNT (*) FROM Product Where ProductQty<='" + CriticalStockLevel + "'";
            SqlCommand Com = new SqlCommand(Qry, ObjConnection);
            ObjConnection.Open();
            int Count = Convert.ToInt32(Com.ExecuteScalar());
            LblCriticalStockCount.Text = Count.ToString();
            ObjConnection.Close();

        }
        private void GetCountOfInStock()
        {
            Qry = "SELECT COUNT (*) FROM Product Where ProductQty>0";
            SqlCommand Com = new SqlCommand(Qry, ObjConnection);
            ObjConnection.Open();
            int Count = Convert.ToInt32(Com.ExecuteScalar());
            LblInStockCount.Text = Count.ToString();
            ObjConnection.Close();
        }

        private void GetCountOfSoldItems()
        {
            Qry = "SELECT DISTINCT COUNT(ProductCode) FROM OrderProduct";
            SqlCommand Com = new SqlCommand(Qry, ObjConnection);
            ObjConnection.Open();
            int Count = Convert.ToInt32(Com.ExecuteScalar());
            LblSoldItemsCount.Text = Count.ToString();
            ObjConnection.Close();
        }

        private void GetTotalSales()
        {

            Qry = "SELECT SUM(TotalPrice) FROM PurchaseOrder";
            SqlCommand Com = new SqlCommand(Qry, ObjConnection);
            ObjConnection.Open();
            string Count = Convert.ToString(Com.ExecuteScalar());

            if (Count != "")
            {
                LblSalesCount.Text = Count.ToString();
            }
            else
            {
                LblSalesCount.Text = "00000.00";
            }
            ObjConnection.Close();

        }

        // 
        // Inventory Show All Products In Data Grid view
        // 
        public void ShowProductInfo()
        {

            Qry = "SELECT ProductCode AS Product_Code,ProductName AS Name,ProductUnitPrice AS Unit_Price,ProductQty AS Quantity,ProductNote AS Note_On_Product,ProductVendor AS Vendor,ProductCategoryCode AS Category FROM Product";
            SqlDataAdapter ObjDataAdaptor = new SqlDataAdapter(Qry, ObjConnection);

            DatabaseDataSet ObjDataSet = new DatabaseDataSet();
            ObjDataSet.Reset();
            //ObjConnection.Open();
            ObjDataAdaptor.Fill(ObjDataSet, "Products");
            DataGridProducts.DataSource = ObjDataSet.Tables["Products"];
            ObjConnection.Close();

        }
        // 
        // Inventory Refresh Products In Data Grid view
        // 
        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            ShowProductInfo();
            TextProductSearchBox.Clear();
        }
        // 
        // Inventory ADD Products
        // 
        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            Update_Product ObjUpdateProduct = new Update_Product();
            ObjUpdateProduct.ShowDialog();
        }
        // 
        // Inventory Show Critical Products
        // 
        int CriticalStockLevel = 10;                                    //Critical Stock Level
        private void BtnCriticalItems_Click(object sender, EventArgs e)
        {
            Qry = "SELECT ProductCode AS Product_Code,ProductName AS Name,ProductUnitPrice AS Unit_Price,ProductQty AS Quantity,ProductNote AS Note_On_Product,ProductVendor AS Vendor,ProductCategoryCode AS Category FROM Product Where ProductQty<='" + CriticalStockLevel + "'";
            SqlDataAdapter ObjDataAdaptor = new SqlDataAdapter(Qry, ObjConnection);

            ObjConnection.Open();
            DatabaseDataSet ObjDataSet = new DatabaseDataSet();
            ObjDataSet.Clear();

            ObjDataAdaptor.Fill(ObjDataSet, "Products");
            DataGridProducts.DataSource = ObjDataSet.Tables["Products"];
            ObjConnection.Close();

        }
        // 
        // Inventory Show ALL Products
        //
        private void BtnAllItems_Click(object sender, EventArgs e)
        {
            ShowProductInfo();
        }
        // 
        // Inventory Filter Products
        //        
        private void BtnFilterProducts_Click(object sender, EventArgs e)
        {
            Qry = "SELECT * FROM Product Where ProductName LIKE '%" + TextProductSearchBox.Text + "%'";
            SqlDataAdapter ObjDataAdaptor = new SqlDataAdapter(Qry, ObjConnection);
            ObjConnection.Open();
            DatabaseDataSet ObjDataSet = new DatabaseDataSet();
            ObjDataSet.Clear();

            ObjDataAdaptor.Fill(ObjDataSet, "Products");
            DataGridProducts.DataSource = ObjDataSet.Tables["Products"];
            ObjConnection.Close();

        }
        // 
        // Inventory Update Stocks
        //
        private void BtnUpdateStock_Click(object sender, EventArgs e)
        {
            ObjConnection.Open();
            if (ToggleStockInOut.Value == true)
            {
                string qry = "UPDATE Product SET ProductQty=ProductQty+'" + TextRestockAmount.Text + "'WHERE ProductCode='" + ProductCode + "'";
                SqlCommand ObjCommand = new SqlCommand(qry, ObjConnection);
                ObjCommand.ExecuteNonQuery();
                ShowProductInfo();
            }
            else
            {
                string qry = "UPDATE Product SET ProductQty=ProductQty-'" + TextRestockAmount.Text + "'WHERE ProductCode='" + ProductCode + "'";
                SqlCommand ObjCommand = new SqlCommand(qry, ObjConnection);
                ObjCommand.ExecuteNonQuery();
                ShowProductInfo();
            }
            ObjConnection.Close();
        }
        // 
        // Inventory Get Row Index Of Selected Row Of Products GridView
        //
        string ProductCode = "";
        private void DataGridProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DataGridProducts.Rows.Count != 0)
            {
                ProductCode = DataGridProducts.CurrentRow.Cells[0].Value.ToString();
            }

        }
        // 
        // Inventory-Delete Products
        //
        private void BtnDeleteProduct_Click(object sender, EventArgs e)
        {
            Qry = "DELETE FROM Product WHERE ProductCode='" + ProductCode + "'";
            SqlCommand ObjCommand = new SqlCommand(Qry, ObjConnection);
            ObjConnection.Open();
            ObjCommand.ExecuteNonQuery();
            ObjConnection.Close();
            ShowProductInfo();
        }
        // 
        // Vendor-Load Vendors Info To The DataGridView
        //
        private void ShowVendorInfo()
        {
            Qry = "SELECT * FROM Vendor";

            SqlDataAdapter ObjDataAdaptor = new SqlDataAdapter(Qry, ObjConnection);
            DatabaseDataSet ObjDataSet = new DatabaseDataSet();
            ObjDataSet.Clear();
            ObjDataAdaptor.Fill(ObjDataSet, "Vendor");
            DataGridVendor.DataSource = ObjDataSet.Tables["Vendor"];
            ObjConnection.Close();

        }
        // 
        // Vendor-ADD Vendors 
        //
        private void BtnVendorAdd_Click(object sender, EventArgs e)
        {
           if(TextVendorID.Text!="")
            {
                
                try
                {
                    Qry = "INSERT INTO Vendor VALUES('" + TextVendorID.Text + "','" + TextVendorName.Text + "','" + TextVendorContact.Text + "','" + TextVendorAdLine01.Text + "','" + TextVendorAdLine02.Text + "','" + TextVendorCity.Text + "')";

                    SqlCommand ObjCommand = new SqlCommand(Qry, ObjConnection);
                    ObjConnection.Open();
                    ObjCommand.ExecuteNonQuery();
                    ShowVendorInfo();

                    //Clear Textboxes.
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
                    ObjConnection.Close();
                }
                
                

            }
            else
            {
                MessageBox.Show("Fill The Vendor Details In Vendor Information form","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }

        // 
        // Vendor-Delete Vendors 
        //
        private void BtnVendorDelete_Click(object sender, EventArgs e)
        {
            Qry = "DELETE FROM Vendor WHERE VendorID='" + ProductCode + "'";
            SqlCommand ObjCommand = new SqlCommand(Qry, ObjConnection);
            ObjConnection.Open();
            ObjCommand.ExecuteNonQuery();
            ObjConnection.Close();
            ShowVendorInfo();
        }
        // 
        // Vendor-Get Data From Selected Row In DataGridView 
        //
        private void DataGridVendor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ProductCode = DataGridVendor.CurrentRow.Cells[0].Value.ToString();

            TextVendorID.Text = DataGridVendor.CurrentRow.Cells[0].Value.ToString();
            TextVendorName.Text = DataGridVendor.CurrentRow.Cells[1].Value.ToString();
            TextVendorContact.Text = DataGridVendor.CurrentRow.Cells[2].Value.ToString();
            TextVendorAdLine01.Text = DataGridVendor.CurrentRow.Cells[3].Value.ToString();
            TextVendorAdLine02.Text = DataGridVendor.CurrentRow.Cells[4].Value.ToString();
            TextVendorCity.Text = DataGridVendor.CurrentRow.Cells[5].Value.ToString();
        }
        // 
        // Vendor-Update Vendors 
        //
        private void BtnVendorUpdate_Click(object sender, EventArgs e)
        {
            Qry = "UPDATE Vendor SET VendorName='"+TextVendorName.Text+ "',VendorContact='" + TextVendorContact.Text + "',AddressLine01='" + TextVendorAdLine01.Text + "',AddressLine02='" + TextVendorAdLine02.Text + "',City='" + TextVendorCity.Text + "' WHERE VendorID='"+TextVendorID.Text+"'";
            SqlCommand ObjCommand = new SqlCommand(Qry, ObjConnection);
            ObjConnection.Open();
            ObjCommand.ExecuteNonQuery();
            ObjConnection.Close();
            ShowVendorInfo();
        }
        // 
        // Vendor-Refresh Vendors DataGridView 
        //
        private void BtnRefreshVendor_Click(object sender, EventArgs e)
        {
            ShowVendorInfo();
            TextSearchVendor.Clear();
        }
        // 
        // Vendor-Search Vendors 
        //
        private void BtnSearchVendor_Click(object sender, EventArgs e)
        {
            Qry = "SELECT * FROM Vendor WHERE VendorID='"+TextSearchVendor.Text+ "' OR VendorName='" + TextSearchVendor.Text + "'";

            SqlDataAdapter ObjDataAdaptor = new SqlDataAdapter(Qry, ObjConnection);
            DatabaseDataSet ObjDataSet = new DatabaseDataSet();
            ObjDataSet.Clear();
            ObjDataAdaptor.Fill(ObjDataSet, "Vendor");
            DataGridVendor.DataSource = ObjDataSet.Tables["Vendor"];
            ObjConnection.Close();
        }
        // 
        // Category-ADD Category 
        //
        private void BtnAddCategory_Click(object sender, EventArgs e)
        {
            Qry = "INSERT INTO Category VALUES('" + TextCategoryCode.Text + "','" + TextCategoryName.Text + "')";
            SqlCommand ObjCommand = new SqlCommand(Qry, ObjConnection);

            ObjConnection.Open();
            try
            {
                ObjCommand.ExecuteNonQuery();
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
                
                ObjConnection.Close();

                TextCategoryCode.Clear();
                TextCategoryName.Clear();

            }
            ShowCategoryInfo();

        }
        // 
        // Category-Show Category Info In DataGridView 
        //
        private void ShowCategoryInfo()
        {
            Qry = "SELECT * FROM Category";
            
            SqlDataAdapter ObjDataAdaptor = new SqlDataAdapter(Qry,ObjConnection);
            DatabaseDataSet ObjDataSet = new DatabaseDataSet();
            ObjDataSet.Clear();
            ObjConnection.Open();
            ObjDataAdaptor.Fill(ObjDataSet, "Category");
            DataGridCategory.DataSource = ObjDataSet.Tables["Category"];
            ObjConnection.Close();
        }
        // 
        // Category-Get Data From Current DataGridView Row 
        //
        private void DataGridCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ProductCode = DataGridCategory.CurrentRow.Cells[0].Value.ToString();

            TextCategoryCode.Text = DataGridCategory.CurrentRow.Cells[0].Value.ToString();
            TextCategoryName.Text = DataGridCategory.CurrentRow.Cells[1].Value.ToString();

        }
        // 
        // Category-Delete Category 
        //
        private void BtnDeleteCategory_Click(object sender, EventArgs e)
        {
            SqlConnection ObjConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Connect Timeout=30");
            string qry = "DELETE FROM Category WHERE CategoryCode='" + ProductCode + "'";
            SqlCommand ObjCommand = new SqlCommand(qry, ObjConnection);

            ObjConnection.Open();
            ObjCommand.ExecuteNonQuery();
            ObjConnection.Close();
            TextCategoryCode.Clear();
            TextCategoryName.Clear();

            ShowCategoryInfo();

        }
        // 
        // Category-Update Category 
        //
        private void BtnUpdateCategory_Click(object sender, EventArgs e)
        {
            SqlConnection ObjConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Connect Timeout=30");
            string qry = "UPDATE Category SET CategoryName='"+TextCategoryName.Text+"'WHERE CategoryCode='" + ProductCode + "'";
            SqlCommand ObjCommand = new SqlCommand(qry, ObjConnection);

            ObjConnection.Open();
            ObjCommand.ExecuteNonQuery();
            ObjConnection.Close();

            TextCategoryCode.Clear();
            TextCategoryName.Clear();

            ShowCategoryInfo();

        }
        // 
        // Category-Search Category 
        //
        private void LblSearchCategory_Click(object sender, EventArgs e)
        {
            Qry = "SELECT * FROM Category WHERE CategoryName='" + TextSearchCategory.Text + "' OR CategoryCode='" + TextSearchCategory.Text + "' ";

            SqlDataAdapter ObjDataAdaptor = new SqlDataAdapter(Qry, ObjConnection);
            DatabaseDataSet ObjDataSet = new DatabaseDataSet();
            ObjDataSet.Clear();
            ObjConnection.Open();
            ObjDataAdaptor.Fill(ObjDataSet, "Category");
            DataGridCategory.DataSource = ObjDataSet.Tables["Category"];
            ObjConnection.Close();

        }
        // 
        // Category-Refresh Category DataGridView 
        //
        private void LblRefreshCategory_Click(object sender, EventArgs e)
        {
            ShowCategoryInfo();
            TextSearchCategory.Clear();
        }
        // 
        // Purchase_Order-Show Orders In DataGridView 
        //
        private void ShowOrderInfo()
        {
            Qry = "SELECT PurchaseOrder.OrderID,OrderProduct.ProductCode,OrderProduct.OrderQty,OrderProduct.Price,PurchaseOrder.OrderDate,PurchaseOrder.OrderIssuerID,PurchaseOrder.CustomerFName,PurchaseOrder.CustomerLName,PurchaseOrder.CustomerContact,PurchaseOrder.PaymentMethod,PurchaseOrder.DiscountCode FROM PurchaseOrder INNER JOIN OrderProduct ON(PurchaseOrder.OrderID=OrderProduct.OrderID) ORDER BY PurchaseOrder.OrderID";

            SqlDataAdapter ObjDataAdaptor = new SqlDataAdapter(Qry, ObjConnection);
            DatabaseDataSet ObjDataSet = new DatabaseDataSet();
            ObjDataSet.Clear();
            ObjConnection.Open();
            ObjDataAdaptor.Fill(ObjDataSet,"Order");
            DataGridOrders.DataSource = ObjDataSet.Tables["Order"];
            ObjConnection.Close();
        }
        // 
        // Purchase_Orders-Refresh DataGridView 
        //
        private void BtnRefreshOrders_Click(object sender, EventArgs e)
        {
            ShowOrderInfo();
        }
        // 
        // Purchase_Orders-Issue A New Bill 
        //

        private void BtnIssueABill_Click_1(object sender, EventArgs e)
        {
            Cashier ObjForm2 = new Cashier();
            ObjForm2.Show();
            ObjForm2.SetUserNameInTitleBar(UserNameTemp);//Set EmpID On Cashier Page
        }
        // 
        // Purchase_Orders-Filter Orders  
        //
        private void BtnFilterOrders_Click(object sender, EventArgs e)
        {
            Qry = "SELECT PurchaseOrder.OrderID,OrderProduct.ProductCode,OrderProduct.OrderQty,OrderProduct.Price,PurchaseOrder.OrderDate,PurchaseOrder.OrderIssuerID,PurchaseOrder.CustomerFName,PurchaseOrder.CustomerLName,PurchaseOrder.CustomerContact,PurchaseOrder.PaymentMethod,PurchaseOrder.DiscountCode FROM PurchaseOrder INNER JOIN OrderProduct ON(PurchaseOrder.OrderID=OrderProduct.OrderID) WHERE PurchaseOrder.OrderID='" + TextSearchOrder.Text + "' OR PurchaseOrder.CustomerFName='" + TextSearchOrder.Text + "' ORDER BY PurchaseOrder.OrderID";

            SqlDataAdapter ObjDataAdaptor = new SqlDataAdapter(Qry, ObjConnection);
            DatabaseDataSet ObjDataSet = new DatabaseDataSet();
            ObjDataSet.Clear();
            ObjConnection.Open();
            ObjDataAdaptor.Fill(ObjDataSet, "Order");
            DataGridOrders.DataSource = ObjDataSet.Tables["Order"];
            ObjConnection.Close();
        }
        // 
        // Purchase_Orders-Filter Orders By Date
        //
        private void BtnFilterOrdersByDate_Click(object sender, EventArgs e)
        {
            System.DateTime FromDate = default(System.DateTime);
            FromDate = DatePickerFrom.Value;
            System.DateTime TillDate = default(System.DateTime);
            TillDate = DatePickerTill.Value;

            Qry= "SELECT PurchaseOrder.OrderID,OrderProduct.ProductCode,OrderProduct.OrderQty,OrderProduct.Price,PurchaseOrder.OrderDate,PurchaseOrder.OrderIssuerID,PurchaseOrder.CustomerFName,PurchaseOrder.CustomerLName,PurchaseOrder.CustomerContact,PurchaseOrder.PaymentMethod,PurchaseOrder.DiscountCode FROM PurchaseOrder INNER JOIN OrderProduct ON(PurchaseOrder.OrderID=OrderProduct.OrderID) WHERE PurchaseOrder.OrderDate BETWEEN '"+FromDate+"' AND '"+TillDate+"'ORDER BY PurchaseOrder.OrderID";

            SqlDataAdapter ObjDataAdaptor = new SqlDataAdapter(Qry, ObjConnection);
            DatabaseDataSet ObjDataSet = new DatabaseDataSet();
            ObjDataSet.Clear();
            ObjConnection.Open();
            ObjDataAdaptor.Fill(ObjDataSet, "Order");
            DataGridOrders.DataSource = ObjDataSet.Tables["Order"];
            ObjConnection.Close();
        }
        // 
        // Settings-ADD User
        //
        private void AddUser()
        {
            if(TextEmpID.Text!="" && TextUserName.Text != "" && TextPassword.Text != "" && DropDownAuthorize.Text != "" && TextConfirmPassword.Text !="")
            {
                if(TextPassword.Text== TextConfirmPassword.Text)
                {
                    Qry = "INSERT INTO Users VALUES('" + TextEmpID.Text + "','" + TextUserName.Text + "','" + TextPassword.Text + "','" + DropDownAuthorize.Text + "')";
                    SqlCommand Com = new SqlCommand(Qry, ObjConnection);
                    ObjConnection.Open();
                    Com.ExecuteNonQuery();
                }
                else
                {
                    LblIncorrect.Text = "Confirm Password Is Not Matching!";
                    LblIncorrect.Visible = true;
                }
                ObjConnection.Close();
            }
            else
            {
                LblIncorrect.Text = "Check Missing Fields!";
                LblIncorrect.Visible = true;
            }
            
        }
        // 
        // Settings-ADD User Button
        //
        private void BtnGiveAccess_Click(object sender, EventArgs e)
        {
            AddUser();
            ShowUsersInfo();
        }
        // 
        // Settings-Show Password
        //
        private void CheckBoxPassword_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if(CheckBoxPassword.Checked==true)
            {
                TextPassword.PasswordChar = '\0';
            }else
            {
                TextPassword.PasswordChar = '\u2022';
            }
        }
        // 
        // Settings-Show Confirm Password
        //
        private void CheckBoxConfirmPassword_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (CheckBoxConfirmPassword.Checked == true)
            {
                TextConfirmPassword.PasswordChar = '\0';
            }
            else
            {
                TextConfirmPassword.PasswordChar = '\u2022';
            }
        }
        // 
        // Settings-Clear Textboxes
        //
        private void TextEmpID_TextChange(object sender, EventArgs e)
        {
            LblIncorrect.Text = "";
            LblIncorrect.Visible = false;
        }

        private void TextUserName_TextChange(object sender, EventArgs e)
        {
            LblIncorrect.Text = "";
            LblIncorrect.Visible = false;
        }

        private void TextPassword_TextChange(object sender, EventArgs e)
        {
            LblIncorrect.Text = "";
            LblIncorrect.Visible = false;
        }

        private void TextConfirmPassword_TextChange(object sender, EventArgs e)
        {
            LblIncorrect.Text = "";
            LblIncorrect.Visible = false;
        }

        private void DropDownAuthorize_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LblIncorrect.Text = "";
            LblIncorrect.Visible = false;
        }
        // 
        // Settings-Show Users Info In DataGridView
        //
        private void ShowUsersInfo()
        {
            Qry = "SELECT * FROM Users";

            SqlDataAdapter ObjDataAdapter = new SqlDataAdapter(Qry, ObjConnection);
            DatabaseDataSet ObjDataSet = new DatabaseDataSet();
            ObjConnection.Open();
            ObjDataAdapter.Fill(ObjDataSet, "Users");
            DataGridUsers.DataSource = ObjDataSet.Tables["Users"];
            ObjConnection.Close();
        }
        // 
        // Settings-Delete Users
        //
        private void BtnDeleteUsers_Click(object sender, EventArgs e)
        {
            string UserID = DataGridUsers.CurrentRow.Cells[0].Value.ToString();

            Qry = "DELETE FROM Users WHERE EMPID='" + UserID + "'";
            SqlCommand ObjCommand = new SqlCommand(Qry, ObjConnection);

            ObjConnection.Open();
            ObjCommand.ExecuteNonQuery();
            ObjConnection.Close();
            ShowUsersInfo();
        }
    }
}
