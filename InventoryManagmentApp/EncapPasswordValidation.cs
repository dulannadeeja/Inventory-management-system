using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace InventoryManagmentApp
{
    class EncapPasswordValidation
    {
        private string UserName;
        private string Password;
        private string Authorize;

        public void SetData(string InputUserName, String InputPassword, string InputAuthorize)
        {
            UserName = InputUserName;
            Password = InputPassword;
            Authorize = InputAuthorize;
            
            
        }

        public bool GetValidation()
        {
            SqlConnection ObjCon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Connect Timeout=30");
            string Qry = "SELECT * FROM Users WHERE UserName='" + UserName + "' AND Password='" + Password + "' AND Authorize='" + Authorize + "'";

            SqlCommand ObjCom = new SqlCommand(Qry, ObjCon);
            ObjCon.Open();
            SqlDataReader Reader = ObjCom.ExecuteReader();
            bool Flag = false;
            if (Reader.Read()==true)
            {
                
                if (Authorize == "Admin")
                {
                    Admin_Panel ObjForm1 = new Admin_Panel();
                    ObjForm1.Show();
                    Login_Page ObjLogin = new Login_Page();
                    ObjLogin.Hide();
                    ObjForm1.SetUserNameInTitleBar(UserName);

                    Cashier ObjForm2 = new Cashier();
                    ObjForm2.SetUserNameInTitleBar(UserName);
                    Flag = true;
                }
                else
                {
                    Cashier ObjForm2 = new Cashier();
                    ObjForm2.Show();
                    Login_Page ObjLogin = new Login_Page();
                    ObjLogin.Hide();
                    ObjForm2.SetUserNameInTitleBar(UserName);
                    Flag = true;
                }
            }
            else
            {
                
                Flag = false;

            }
            return Flag;
        }
        }
    }
        
    

