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
    public partial class Login_Page : Form
    {
        public Login_Page()
        {
            InitializeComponent();
            TextPassword.PasswordChar = '\u2022';
            PasswordHide();



        }

        private void bunifuPictureBox2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {

            EncapPasswordValidation ObjValidation = new EncapPasswordValidation();
            ObjValidation.SetData(TextUserName.Text,TextPassword.Text,DropDownAuthorize.Text);
            ObjValidation.GetValidation();
            if (ObjValidation.GetValidation() == false)
            {
                LblIncorrect.Visible = true;
            }

        }

        private void bunifuCheckBox1_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            PasswordHide();
        }
        private void PasswordHide()
        {
            if(bunifuCheckBox1.Checked)
            {
                TextPassword.PasswordChar = '\0';
            }else
            {
                TextPassword.PasswordChar = '\u2022';
            }
        }
        private void bunifuLabel6_Click(object sender, EventArgs e)
        {

        }

        private void TextUserName_Click(object sender, EventArgs e)
        {
            LblIncorrect.Visible = false;
        }

        private void TextPassword_TextChanged(object sender, EventArgs e)
        {
            LblIncorrect.Visible = false;
        }

        private void TextUserName_TextChange(object sender, EventArgs e)
        {
            LblIncorrect.Visible = false;
        }

        private void DropDownAuthorize_SelectedIndexChanged(object sender, EventArgs e)
        {
            LblIncorrect.Visible = false;
        }

        private void LblIncorrect_Click(object sender, EventArgs e)
        {

        }
    }
}
