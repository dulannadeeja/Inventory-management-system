using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagmentApp
{
    public partial class Loading_Screen : Form
    {
        public Loading_Screen()
        {
            InitializeComponent();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            bunifuCircleProgress1.Increment(1);
            bunifuCircleProgress1.Text = bunifuCircleProgress1.Value.ToString();
            if(bunifuCircleProgress1.Value==100)
            {
                timer1.Stop();
                Login_Page ObjForm3 = new Login_Page();
                ObjForm3.Show();
                this.Hide();
            }
        }

        private void LoadingScreen_Load(object sender, EventArgs e)
        {
            bunifuCircleProgress1.Value = 0;
            LblCopyrights.Text = "Copyrights" + " \u00a9 " + "NSBM 20.3 Group #3";
        }

        private void LblCopyrights_Click(object sender, EventArgs e)
        {

        }
    }
}
