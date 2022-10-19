namespace SmartRDP_v1._0._0
{
    partial class SmartRDP
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

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SmartRDP));
            this.btnConnect = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tableMain = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.rdpBTN = new System.Windows.Forms.PictureBox();
            this.vncBTN = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panelHeaderBLine = new System.Windows.Forms.Panel();
            this.tableHeader = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.activeHeaderText = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.saveBTN = new System.Windows.Forms.Button();
            this.saveNQuitBTN = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.rdpUsers1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdpBTN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vncBTN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panelHeaderBLine.SuspendLayout();
            this.tableHeader.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdpUsers1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnConnect.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnConnect.Location = new System.Drawing.Point(380, 4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(118, 40);
            this.btnConnect.TabIndex = 8;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(5, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 40);
            this.button1.TabIndex = 7;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tableMain
            // 
            this.tableMain.ColumnCount = 1;
            this.tableMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableMain.Controls.Add(this.panel1, 0, 0);
            this.tableMain.Controls.Add(this.panelHeaderBLine, 0, 1);
            this.tableMain.Controls.Add(this.panel4, 0, 3);
            this.tableMain.Controls.Add(this.tableLayoutPanel1, 0, 2);
            this.tableMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableMain.Location = new System.Drawing.Point(0, 0);
            this.tableMain.Margin = new System.Windows.Forms.Padding(0);
            this.tableMain.Name = "tableMain";
            this.tableMain.RowCount = 4;
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.78832F));
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.109489F));
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 78.28467F));
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableMain.Size = new System.Drawing.Size(510, 554);
            this.tableMain.TabIndex = 17;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.flowLayoutPanel2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(510, 83);
            this.panel1.TabIndex = 18;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.rdpBTN);
            this.flowLayoutPanel2.Controls.Add(this.vncBTN);
            this.flowLayoutPanel2.Controls.Add(this.pictureBox3);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(501, 84);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // rdpBTN
            // 
            this.rdpBTN.BackColor = System.Drawing.Color.White;
            this.rdpBTN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rdpBTN.BackgroundImage")));
            this.rdpBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.rdpBTN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rdpBTN.Location = new System.Drawing.Point(3, 3);
            this.rdpBTN.Name = "rdpBTN";
            this.rdpBTN.Size = new System.Drawing.Size(60, 60);
            this.rdpBTN.TabIndex = 0;
            this.rdpBTN.TabStop = false;
            this.rdpBTN.Click += new System.EventHandler(this.rdpBTN_Click);
            // 
            // vncBTN
            // 
            this.vncBTN.BackColor = System.Drawing.Color.White;
            this.vncBTN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("vncBTN.BackgroundImage")));
            this.vncBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.vncBTN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.vncBTN.Location = new System.Drawing.Point(69, 3);
            this.vncBTN.Name = "vncBTN";
            this.vncBTN.Size = new System.Drawing.Size(60, 60);
            this.vncBTN.TabIndex = 1;
            this.vncBTN.TabStop = false;
            this.vncBTN.Click += new System.EventHandler(this.vncBTN_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.White;
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Location = new System.Drawing.Point(135, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(60, 60);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // panelHeaderBLine
            // 
            this.panelHeaderBLine.BackColor = System.Drawing.Color.Black;
            this.panelHeaderBLine.Controls.Add(this.tableHeader);
            this.panelHeaderBLine.Location = new System.Drawing.Point(0, 83);
            this.panelHeaderBLine.Margin = new System.Windows.Forms.Padding(0);
            this.panelHeaderBLine.Name = "panelHeaderBLine";
            this.panelHeaderBLine.Size = new System.Drawing.Size(510, 25);
            this.panelHeaderBLine.TabIndex = 21;
            // 
            // tableHeader
            // 
            this.tableHeader.BackColor = System.Drawing.Color.White;
            this.tableHeader.ColumnCount = 2;
            this.tableHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.15873F));
            this.tableHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 94.84127F));
            this.tableHeader.Controls.Add(this.panel5, 1, 0);
            this.tableHeader.Location = new System.Drawing.Point(0, 1);
            this.tableHeader.Margin = new System.Windows.Forms.Padding(0);
            this.tableHeader.Name = "tableHeader";
            this.tableHeader.RowCount = 1;
            this.tableHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableHeader.Size = new System.Drawing.Size(510, 24);
            this.tableHeader.TabIndex = 22;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.activeHeaderText);
            this.panel5.Controls.Add(this.label12);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(26, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(484, 24);
            this.panel5.TabIndex = 23;
            // 
            // activeHeaderText
            // 
            this.activeHeaderText.AutoSize = true;
            this.activeHeaderText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.activeHeaderText.Location = new System.Drawing.Point(20, 3);
            this.activeHeaderText.Name = "activeHeaderText";
            this.activeHeaderText.Size = new System.Drawing.Size(170, 15);
            this.activeHeaderText.TabIndex = 2;
            this.activeHeaderText.Text = "Remote Desktop Protocol";
            this.activeHeaderText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label12.Location = new System.Drawing.Point(3, -1);
            this.label12.Margin = new System.Windows.Forms.Padding(0);
            this.label12.Name = "label12";
            this.label12.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label12.Size = new System.Drawing.Size(24, 24);
            this.label12.TabIndex = 1;
            this.label12.Text = "└";
            this.label12.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.saveBTN);
            this.panel4.Controls.Add(this.saveNQuitBTN);
            this.panel4.Controls.Add(this.btnConnect);
            this.panel4.Controls.Add(this.button1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 501);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(504, 50);
            this.panel4.TabIndex = 24;
            // 
            // saveBTN
            // 
            this.saveBTN.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.saveBTN.BackColor = System.Drawing.SystemColors.ControlLight;
            this.saveBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.saveBTN.Location = new System.Drawing.Point(130, 4);
            this.saveBTN.Name = "saveBTN";
            this.saveBTN.Size = new System.Drawing.Size(118, 40);
            this.saveBTN.TabIndex = 10;
            this.saveBTN.Text = "Save";
            this.saveBTN.UseVisualStyleBackColor = false;
            this.saveBTN.Click += new System.EventHandler(this.saveBTN_Click);
            // 
            // saveNQuitBTN
            // 
            this.saveNQuitBTN.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.saveNQuitBTN.BackColor = System.Drawing.SystemColors.ControlLight;
            this.saveNQuitBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.saveNQuitBTN.Location = new System.Drawing.Point(255, 4);
            this.saveNQuitBTN.Name = "saveNQuitBTN";
            this.saveNQuitBTN.Size = new System.Drawing.Size(118, 40);
            this.saveNQuitBTN.TabIndex = 9;
            this.saveNQuitBTN.Text = "Save && Quit";
            this.saveNQuitBTN.UseVisualStyleBackColor = false;
            this.saveNQuitBTN.Click += new System.EventHandler(this.saveNQuitBTN_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.644415F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82.71133F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.644258F));
            this.tableLayoutPanel1.Controls.Add(this.panel6, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 111);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(504, 384);
            this.tableLayoutPanel1.TabIndex = 25;
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(46, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(410, 378);
            this.panel6.TabIndex = 9;
            // 
            // rdpUsers1BindingSource
            // 
            this.rdpUsers1BindingSource.DataMember = "rdpUsers1";
            // 
            // SmartRDP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(510, 554);
            this.Controls.Add(this.tableMain);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MaximizeBox = false;
            this.Name = "SmartRDP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SmartRDP";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SmartRDP_FormClosing);
            this.Load += new System.EventHandler(this.SmartRDP_Load);
            this.Move += new System.EventHandler(this.SmartRDP_Move);
            this.Resize += new System.EventHandler(this.SmartRDP_Resize);
            this.tableMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rdpBTN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vncBTN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panelHeaderBLine.ResumeLayout(false);
            this.tableHeader.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rdpUsers1BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource rdpUsers1BindingSource;
        private System.Windows.Forms.TableLayoutPanel tableMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panelHeaderBLine;
        private System.Windows.Forms.TableLayoutPanel tableHeader;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.PictureBox rdpBTN;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox vncBTN;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button saveNQuitBTN;
        private System.Windows.Forms.Button saveBTN;
        public System.Windows.Forms.Label activeHeaderText;
    }
}

