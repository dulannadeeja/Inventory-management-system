using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace InventoryManagmentApp
{
    public partial class UpdateProduct : Form
    {
        public UpdateProduct()
        {
            InitializeComponent();
        }

        private void bunifuPictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            

        }

        private void UpdateProduct_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'databaseDataSet.Category' table. You can move, or remove it, as needed.
            this.categoryTableAdapter.Fill(this.databaseDataSet.Category);
            // TODO: This line of code loads data into the 'productVendorDataSet.Vendor' table. You can move, or remove it, as needed.
            this.vendorTableAdapter.Fill(this.productVendorDataSet.Vendor);
            // TODO: This line of code loads data into the 'inventoryMangementAppDataBaseDataSet2.Category' table. You can move, or remove it, as needed.
        }
        private void bunifuImageButton1_Click_1(object sender, EventArgs e)
        {
            //Passe Data To The Database
            try
            {
                SqlConnection ObjConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Connect Timeout=30");
                string QryInsert = "INSERT INTO Product VALUES('" + TextProductCode.Text + "','" + TextProductName.Text + "','" + int.Parse(TextProductQty.Text) + "','" + TextProductNote.Text + "','" + DropProductVendor.Text + "','" + DropProductCategory.Text + "','" + TextProductUnitPrice.Text + "')";

                SqlCommand ObjCommand = new SqlCommand(QryInsert, ObjConnection);
                ObjConnection.Open();
                ObjCommand.ExecuteNonQuery();
                Form1 ObjForm1 = new Form1();
                ObjForm1.ShowData();

                //clear textboxes if not any exeptions are occured.
                TextProductCode.Clear();
                TextProductName.Clear();
                TextProductQty.Clear();
                TextProductNote.Clear();
                TextProductUnitPrice.Clear();
                DropProductVendor.ValueMember = "";
                DropProductVendor.ValueMember = "";
            }

            catch (SqlException ex1)
            {
                MessageBox.Show("Error Occured!" + Convert.ToString(ex1), "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            catch (FormatException ex2)
            {
                MessageBox.Show("Error Occured!" + Convert.ToString(ex2), "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }

        }
        private void bunifuImageButton2_Click_2(object sender, EventArgs e)
        {
            //Connetion To The Database
            SqlConnection ObjConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Connect Timeout=30");

            string QryUpdate = "UPDATE Product SET ProductQty=ProductQty+'" + TextAmountRestock.Text + "' WHERE ProductCode='" + TextProductCodeRestock.Text + "'";
            SqlCommand ObjCommand = new SqlCommand(QryUpdate, ObjConnection);
            ObjConnection.Open();
            ObjCommand.ExecuteNonQuery();


        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            //DropProductVendor.DataSource=null;
            //DropProductVendor.DataSource = vendorBindingSource.DataMember;
            //DropProductVendor.DisplayMember = "VendorName";

            //DropProductVendor.Refresh();
        }
    }
}
