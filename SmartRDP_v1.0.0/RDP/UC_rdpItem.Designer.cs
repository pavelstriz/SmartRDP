namespace SmartRDP_v1._0._0
{
    partial class rdpItem
    {
        /// <summary> 
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód vygenerovaný pomocí Návrháře komponent

        /// <summary> 
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rdpItem));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.RI_hostName = new System.Windows.Forms.Label();
            this.RI_ipAddress = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(106, 46);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseEnter += new System.EventHandler(this.rdpItem_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.rdpItem_MouseLeave);
            // 
            // RI_hostName
            // 
            this.RI_hostName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RI_hostName.AutoSize = true;
            this.RI_hostName.BackColor = System.Drawing.Color.Transparent;
            this.RI_hostName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.RI_hostName.Location = new System.Drawing.Point(32, 0);
            this.RI_hostName.Name = "RI_hostName";
            this.RI_hostName.Size = new System.Drawing.Size(41, 15);
            this.RI_hostName.TabIndex = 1;
            this.RI_hostName.Text = "Name";
            this.RI_hostName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RI_hostName.MouseEnter += new System.EventHandler(this.rdpItem_MouseEnter);
            this.RI_hostName.MouseLeave += new System.EventHandler(this.rdpItem_MouseLeave);
            // 
            // RI_ipAddress
            // 
            this.RI_ipAddress.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RI_ipAddress.AutoSize = true;
            this.RI_ipAddress.BackColor = System.Drawing.Color.Transparent;
            this.RI_ipAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.RI_ipAddress.Location = new System.Drawing.Point(44, 15);
            this.RI_ipAddress.Name = "RI_ipAddress";
            this.RI_ipAddress.Size = new System.Drawing.Size(17, 15);
            this.RI_ipAddress.TabIndex = 2;
            this.RI_ipAddress.Text = "Ip";
            this.RI_ipAddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.RI_ipAddress.MouseEnter += new System.EventHandler(this.rdpItem_MouseEnter);
            this.RI_ipAddress.MouseLeave += new System.EventHandler(this.rdpItem_MouseLeave);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.RI_ipAddress, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.RI_hostName, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 46);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(106, 31);
            this.tableLayoutPanel1.TabIndex = 3;
            this.tableLayoutPanel1.MouseEnter += new System.EventHandler(this.rdpItem_MouseEnter);
            this.tableLayoutPanel1.MouseLeave += new System.EventHandler(this.rdpItem_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Location = new System.Drawing.Point(0, 79);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(105, 10);
            this.panel1.TabIndex = 4;
            // 
            // rdpItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "rdpItem";
            this.Size = new System.Drawing.Size(106, 80);
            this.Load += new System.EventHandler(this.rdpItem_Load);
            this.MouseEnter += new System.EventHandler(this.rdpItem_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.rdpItem_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label RI_hostName;
        private System.Windows.Forms.Label RI_ipAddress;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
    }
}
