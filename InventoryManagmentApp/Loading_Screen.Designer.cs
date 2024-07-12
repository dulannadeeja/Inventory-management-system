
namespace InventoryManagmentApp
{
    partial class Loading_Screen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loading_Screen));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuCircleProgress1 = new Bunifu.UI.WinForms.BunifuCircleProgress();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bunifuLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuLabel2 = new Bunifu.UI.WinForms.BunifuLabel();
            this.LblCopyrights = new Bunifu.UI.WinForms.BunifuLabel();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuCircleProgress1
            // 
            this.bunifuCircleProgress1.Animated = false;
            this.bunifuCircleProgress1.AnimationInterval = 1;
            this.bunifuCircleProgress1.AnimationSpeed = 1;
            this.bunifuCircleProgress1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCircleProgress1.CircleMargin = 10;
            this.bunifuCircleProgress1.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Bold);
            this.bunifuCircleProgress1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(199)))), ((int)(((byte)(244)))));
            this.bunifuCircleProgress1.IsPercentage = false;
            this.bunifuCircleProgress1.LineProgressThickness = 6;
            this.bunifuCircleProgress1.LineThickness = 10;
            this.bunifuCircleProgress1.Location = new System.Drawing.Point(101, 255);
            this.bunifuCircleProgress1.Name = "bunifuCircleProgress1";
            this.bunifuCircleProgress1.ProgressAnimationSpeed = 200;
            this.bunifuCircleProgress1.ProgressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(26)))), ((int)(((byte)(43)))));
            this.bunifuCircleProgress1.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(199)))), ((int)(((byte)(244)))));
            this.bunifuCircleProgress1.ProgressColor2 = System.Drawing.Color.White;
            this.bunifuCircleProgress1.ProgressEndCap = Bunifu.UI.WinForms.BunifuCircleProgress.CapStyles.Round;
            this.bunifuCircleProgress1.ProgressFillStyle = Bunifu.UI.WinForms.BunifuCircleProgress.FillStyles.Gradient;
            this.bunifuCircleProgress1.ProgressStartCap = Bunifu.UI.WinForms.BunifuCircleProgress.CapStyles.Round;
            this.bunifuCircleProgress1.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.bunifuCircleProgress1.Size = new System.Drawing.Size(184, 184);
            this.bunifuCircleProgress1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.bunifuCircleProgress1.SubScriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.bunifuCircleProgress1.SubScriptMargin = new System.Windows.Forms.Padding(5, -20, 0, 0);
            this.bunifuCircleProgress1.SubScriptText = "";
            this.bunifuCircleProgress1.SuperScriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(199)))), ((int)(((byte)(244)))));
            this.bunifuCircleProgress1.SuperScriptMargin = new System.Windows.Forms.Padding(5, 20, 0, 0);
            this.bunifuCircleProgress1.SuperScriptText = "%";
            this.bunifuCircleProgress1.TabIndex = 16;
            this.bunifuCircleProgress1.Text = "30";
            this.bunifuCircleProgress1.TextMargin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.bunifuCircleProgress1.Value = 30;
            this.bunifuCircleProgress1.ValueByTransition = 30;
            this.bunifuCircleProgress1.ValueMargin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // bunifuLabel1
            // 
            this.bunifuLabel1.AllowParentOverrides = false;
            this.bunifuLabel1.AutoEllipsis = false;
            this.bunifuLabel1.AutoSize = false;
            this.bunifuLabel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel1.CursorType = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel1.Font = new System.Drawing.Font("Franklin Gothic Medium", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(199)))), ((int)(((byte)(244)))));
            this.bunifuLabel1.Location = new System.Drawing.Point(-1, 34);
            this.bunifuLabel1.Name = "bunifuLabel1";
            this.bunifuLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel1.Size = new System.Drawing.Size(384, 116);
            this.bunifuLabel1.TabIndex = 17;
            this.bunifuLabel1.Text = "Computech Inventory Manager";
            this.bunifuLabel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuLabel1.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuLabel2
            // 
            this.bunifuLabel2.AllowParentOverrides = false;
            this.bunifuLabel2.AutoEllipsis = false;
            this.bunifuLabel2.AutoSize = false;
            this.bunifuLabel2.CursorType = null;
            this.bunifuLabel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bunifuLabel2.Font = new System.Drawing.Font("Franklin Gothic Medium", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(199)))), ((int)(((byte)(244)))));
            this.bunifuLabel2.Location = new System.Drawing.Point(0, 527);
            this.bunifuLabel2.Name = "bunifuLabel2";
            this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel2.Size = new System.Drawing.Size(384, 77);
            this.bunifuLabel2.TabIndex = 17;
            this.bunifuLabel2.Text = "Loading...";
            this.bunifuLabel2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuLabel2.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // LblCopyrights
            // 
            this.LblCopyrights.AllowParentOverrides = false;
            this.LblCopyrights.AutoEllipsis = false;
            this.LblCopyrights.AutoSize = false;
            this.LblCopyrights.CursorType = null;
            this.LblCopyrights.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LblCopyrights.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCopyrights.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(199)))), ((int)(((byte)(244)))));
            this.LblCopyrights.Location = new System.Drawing.Point(0, 604);
            this.LblCopyrights.Name = "LblCopyrights";
            this.LblCopyrights.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblCopyrights.Size = new System.Drawing.Size(384, 77);
            this.LblCopyrights.TabIndex = 17;
            this.LblCopyrights.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblCopyrights.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            this.LblCopyrights.Click += new System.EventHandler(this.LblCopyrights_Click);
            // 
            // Loading_Screen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(46)))), ((int)(((byte)(59)))));
            this.ClientSize = new System.Drawing.Size(384, 681);
            this.Controls.Add(this.bunifuLabel1);
            this.Controls.Add(this.bunifuLabel2);
            this.Controls.Add(this.bunifuCircleProgress1);
            this.Controls.Add(this.LblCopyrights);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Loading_Screen";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoadingScreen";
            this.Load += new System.EventHandler(this.LoadingScreen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.UI.WinForms.BunifuCircleProgress bunifuCircleProgress1;
        private System.Windows.Forms.Timer timer1;
        private Bunifu.UI.WinForms.BunifuLabel LblCopyrights;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel2;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel1;
    }
}