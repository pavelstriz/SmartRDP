namespace SmartRDP_v1._0._0
{
    partial class UC_rdpConnect
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_rdp = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupComboB1 = new System.Windows.Forms.ComboBox();
            this.groupFlag1 = new System.Windows.Forms.PictureBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.computerIp = new System.Windows.Forms.TextBox();
            this.rdpName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.saveCredCheck1 = new System.Windows.Forms.CheckBox();
            this.label = new System.Windows.Forms.Label();
            this.userPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.userName = new System.Windows.Forms.TextBox();
            this.tab_vnc = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tab_rdp.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupFlag1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab_rdp);
            this.tabControl1.Controls.Add(this.tab_vnc);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(350, 362);
            this.tabControl1.TabIndex = 14;
            // 
            // tab_rdp
            // 
            this.tab_rdp.BackColor = System.Drawing.Color.White;
            this.tab_rdp.Controls.Add(this.groupBox2);
            this.tab_rdp.Controls.Add(this.groupBox1);
            this.tab_rdp.Location = new System.Drawing.Point(4, 26);
            this.tab_rdp.Margin = new System.Windows.Forms.Padding(0);
            this.tab_rdp.Name = "tab_rdp";
            this.tab_rdp.Size = new System.Drawing.Size(342, 332);
            this.tab_rdp.TabIndex = 0;
            this.tab_rdp.Text = "General";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.groupComboB1);
            this.groupBox2.Controls.Add(this.groupFlag1);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.computerIp);
            this.groupBox2.Controls.Add(this.rdpName);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox2.Location = new System.Drawing.Point(24, 29);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(298, 130);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Remote Desktop";
            // 
            // groupComboB1
            // 
            this.groupComboB1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.groupComboB1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupComboB1.Location = new System.Drawing.Point(92, 88);
            this.groupComboB1.Margin = new System.Windows.Forms.Padding(0);
            this.groupComboB1.Name = "groupComboB1";
            this.groupComboB1.Size = new System.Drawing.Size(122, 23);
            this.groupComboB1.TabIndex = 24;
            this.groupComboB1.SelectedIndexChanged += new System.EventHandler(this.groupComboB1_SelectedIndexChanged);
            // 
            // groupFlag1
            // 
            this.groupFlag1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupFlag1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.groupFlag1.Location = new System.Drawing.Point(242, 88);
            this.groupFlag1.Margin = new System.Windows.Forms.Padding(0);
            this.groupFlag1.Name = "groupFlag1";
            this.groupFlag1.Padding = new System.Windows.Forms.Padding(2);
            this.groupFlag1.Size = new System.Drawing.Size(35, 40);
            this.groupFlag1.TabIndex = 23;
            this.groupFlag1.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label13.Location = new System.Drawing.Point(34, 88);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 17);
            this.label13.TabIndex = 22;
            this.label13.Text = "Group:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(42, 61);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "Alias:";
            // 
            // computerIp
            // 
            this.computerIp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.computerIp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.computerIp.Location = new System.Drawing.Point(92, 28);
            this.computerIp.Margin = new System.Windows.Forms.Padding(2);
            this.computerIp.Name = "computerIp";
            this.computerIp.Size = new System.Drawing.Size(186, 23);
            this.computerIp.TabIndex = 1;
            this.computerIp.TextChanged += new System.EventHandler(this.computerIp_TextChanged);
            // 
            // rdpName
            // 
            this.rdpName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rdpName.Location = new System.Drawing.Point(92, 59);
            this.rdpName.Margin = new System.Windows.Forms.Padding(2);
            this.rdpName.Name = "rdpName";
            this.rdpName.Size = new System.Drawing.Size(186, 21);
            this.rdpName.TabIndex = 16;
            this.rdpName.TextChanged += new System.EventHandler(this.rdpName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(10, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP address:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.saveCredCheck1);
            this.groupBox1.Controls.Add(this.label);
            this.groupBox1.Controls.Add(this.userPassword);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.userName);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.Location = new System.Drawing.Point(24, 177);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(298, 130);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Authentication";
            // 
            // saveCredCheck1
            // 
            this.saveCredCheck1.AutoSize = true;
            this.saveCredCheck1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.saveCredCheck1.Location = new System.Drawing.Point(81, 95);
            this.saveCredCheck1.Margin = new System.Windows.Forms.Padding(2);
            this.saveCredCheck1.Name = "saveCredCheck1";
            this.saveCredCheck1.Size = new System.Drawing.Size(132, 21);
            this.saveCredCheck1.TabIndex = 19;
            this.saveCredCheck1.Text = "Save credentials";
            this.saveCredCheck1.UseVisualStyleBackColor = true;
            this.saveCredCheck1.CheckedChanged += new System.EventHandler(this.saveCredCheck1_CheckedChanged);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label.Location = new System.Drawing.Point(14, 66);
            this.label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(73, 17);
            this.label.TabIndex = 14;
            this.label.Text = "Password:";
            // 
            // userPassword
            // 
            this.userPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.userPassword.Location = new System.Drawing.Point(92, 63);
            this.userPassword.Margin = new System.Windows.Forms.Padding(2);
            this.userPassword.Name = "userPassword";
            this.userPassword.Size = new System.Drawing.Size(186, 23);
            this.userPassword.TabIndex = 3;
            this.userPassword.TextChanged += new System.EventHandler(this.userPassword_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(11, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Username:";
            // 
            // userName
            // 
            this.userName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.userName.Location = new System.Drawing.Point(92, 31);
            this.userName.Margin = new System.Windows.Forms.Padding(2);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(186, 23);
            this.userName.TabIndex = 2;
            this.userName.TextChanged += new System.EventHandler(this.userName_TextChanged);
            // 
            // tab_vnc
            // 
            this.tab_vnc.Location = new System.Drawing.Point(4, 26);
            this.tab_vnc.Margin = new System.Windows.Forms.Padding(2);
            this.tab_vnc.Name = "tab_vnc";
            this.tab_vnc.Padding = new System.Windows.Forms.Padding(2);
            this.tab_vnc.Size = new System.Drawing.Size(342, 332);
            this.tab_vnc.TabIndex = 1;
            this.tab_vnc.Text = "Advanced";
            this.tab_vnc.UseVisualStyleBackColor = true;
            // 
            // UC_rdpConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UC_rdpConnect";
            this.Size = new System.Drawing.Size(350, 362);
            this.Load += new System.EventHandler(this.UC_rdpConnect_Load);
            this.tabControl1.ResumeLayout(false);
            this.tab_rdp.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupFlag1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_rdp;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox groupComboB1;
        private System.Windows.Forms.PictureBox groupFlag1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox computerIp;
        private System.Windows.Forms.TextBox rdpName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox saveCredCheck1;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox userPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.TabPage tab_vnc;
    }
}
