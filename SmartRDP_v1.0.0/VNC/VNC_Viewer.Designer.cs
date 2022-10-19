namespace SmartRDP_v1._0._0
{
    partial class VNC_Viewer
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.fullscreen = new System.Windows.Forms.Button();
            this.Disconnect = new System.Windows.Forms.Button();
            this.specKeys = new System.Windows.Forms.Button();
            this.vncDesktop1 = new VncSharp.RemoteDesktop();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.vncDesktop1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.96718F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.032823F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(600, 371);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.fullscreen);
            this.panel1.Controls.Add(this.Disconnect);
            this.panel1.Controls.Add(this.specKeys);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 354);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(596, 15);
            this.panel1.TabIndex = 0;
            // 
            // fullscreen
            // 
            this.fullscreen.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.fullscreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fullscreen.Location = new System.Drawing.Point(292, -8);
            this.fullscreen.Margin = new System.Windows.Forms.Padding(0);
            this.fullscreen.Name = "fullscreen";
            this.fullscreen.Size = new System.Drawing.Size(95, 28);
            this.fullscreen.TabIndex = 3;
            this.fullscreen.Text = "FullScreen";
            this.fullscreen.UseVisualStyleBackColor = true;
            this.fullscreen.Click += new System.EventHandler(this.fullscreen_Click);
            // 
            // Disconnect
            // 
            this.Disconnect.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Disconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Disconnect.Location = new System.Drawing.Point(496, -8);
            this.Disconnect.Margin = new System.Windows.Forms.Padding(0);
            this.Disconnect.Name = "Disconnect";
            this.Disconnect.Size = new System.Drawing.Size(95, 28);
            this.Disconnect.TabIndex = 2;
            this.Disconnect.Text = "Disconnect";
            this.Disconnect.UseVisualStyleBackColor = true;
            this.Disconnect.Click += new System.EventHandler(this.Disconnect_Click);
            // 
            // specKeys
            // 
            this.specKeys.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.specKeys.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.specKeys.Location = new System.Drawing.Point(394, -8);
            this.specKeys.Margin = new System.Windows.Forms.Padding(0);
            this.specKeys.Name = "specKeys";
            this.specKeys.Size = new System.Drawing.Size(95, 28);
            this.specKeys.TabIndex = 1;
            this.specKeys.Text = "Ctrl+Alt+Delete";
            this.specKeys.UseVisualStyleBackColor = true;
            this.specKeys.Click += new System.EventHandler(this.specKeys_Click);
            // 
            // vncDesktop1
            // 
            this.vncDesktop1.AutoScroll = true;
            this.vncDesktop1.AutoScrollMinSize = new System.Drawing.Size(608, 427);
            this.vncDesktop1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vncDesktop1.Location = new System.Drawing.Point(2, 2);
            this.vncDesktop1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.vncDesktop1.Name = "vncDesktop1";
            this.vncDesktop1.Size = new System.Drawing.Size(596, 348);
            this.vncDesktop1.TabIndex = 1;
            // 
            // VNC_Viewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 371);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "VNC_Viewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VNC";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Remote_Desktop_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button specKeys;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Disconnect;
        private VncSharp.RemoteDesktop vncDesktop1;
        private System.Windows.Forms.Button fullscreen;
    }
}