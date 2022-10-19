namespace SmartRDP_v1._0._0
{
    partial class rdpBookmarks
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rdpBookmarks));
            this.dgv_bookmark = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.editModeBTN = new System.Windows.Forms.Button();
            this.saveEditBTN = new System.Windows.Forms.Button();
            this.removeAllBTN = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.exportPB1 = new System.Windows.Forms.Panel();
            this.exportColCount = new System.Windows.Forms.Label();
            this.importPB1 = new System.Windows.Forms.Panel();
            this.importColCount = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.rightClickMenuStripExport = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tblrdpBookmarks2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rightClickMenuStripImport = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_bookmark)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.exportPB1.SuspendLayout();
            this.importPB1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblrdpBookmarks2BindingSource)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_bookmark
            // 
            this.dgv_bookmark.AllowUserToAddRows = false;
            this.dgv_bookmark.AllowUserToOrderColumns = true;
            this.dgv_bookmark.AllowUserToResizeRows = false;
            this.dgv_bookmark.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_bookmark.BackgroundColor = System.Drawing.Color.White;
            this.dgv_bookmark.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_bookmark.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_bookmark.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgv_bookmark.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_bookmark.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_bookmark.ColumnHeadersHeight = 5;
            this.dgv_bookmark.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_bookmark.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_bookmark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_bookmark.EnableHeadersVisualStyles = false;
            this.dgv_bookmark.GridColor = System.Drawing.Color.White;
            this.dgv_bookmark.Location = new System.Drawing.Point(2, 2);
            this.dgv_bookmark.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_bookmark.MultiSelect = false;
            this.dgv_bookmark.Name = "dgv_bookmark";
            this.dgv_bookmark.RowHeadersVisible = false;
            this.dgv_bookmark.RowHeadersWidth = 51;
            this.dgv_bookmark.RowTemplate.Height = 24;
            this.dgv_bookmark.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_bookmark.Size = new System.Drawing.Size(673, 329);
            this.dgv_bookmark.TabIndex = 20;
            this.dgv_bookmark.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_bookmark_CellDoubleClick);
            this.dgv_bookmark.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_bookmark_CellEnter);
            this.dgv_bookmark.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_bookmark_CellFormatting);
            this.dgv_bookmark.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_bookmark_CellMouseDown);
            this.dgv_bookmark.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_bookmark_CellMouseMove);
            this.dgv_bookmark.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_bookmark_CellMouseUp);
            this.dgv_bookmark.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgv_bookmark_RowsAdded);
            this.dgv_bookmark.SelectionChanged += new System.EventHandler(this.dgv_bookmark_SelectionChanged);
            this.dgv_bookmark.Sorted += new System.EventHandler(this.dgv_bookmark_Sorted);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33199F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 263F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33601F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33199F));
            this.tableLayoutPanel1.Controls.Add(this.editModeBTN, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.saveEditBTN, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.removeAllBTN, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 335);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(673, 38);
            this.tableLayoutPanel1.TabIndex = 22;
            // 
            // editModeBTN
            // 
            this.editModeBTN.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.editModeBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.editModeBTN.Location = new System.Drawing.Point(32, 3);
            this.editModeBTN.Margin = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.editModeBTN.Name = "editModeBTN";
            this.editModeBTN.Size = new System.Drawing.Size(100, 32);
            this.editModeBTN.TabIndex = 25;
            this.editModeBTN.Text = "Edit mode";
            this.editModeBTN.UseVisualStyleBackColor = true;
            this.editModeBTN.Click += new System.EventHandler(this.editModeBTN_Click);
            // 
            // saveEditBTN
            // 
            this.saveEditBTN.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.saveEditBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.saveEditBTN.Location = new System.Drawing.Point(539, 3);
            this.saveEditBTN.Margin = new System.Windows.Forms.Padding(4, 2, 2, 2);
            this.saveEditBTN.Name = "saveEditBTN";
            this.saveEditBTN.Size = new System.Drawing.Size(82, 32);
            this.saveEditBTN.TabIndex = 24;
            this.saveEditBTN.Text = "Ok";
            this.saveEditBTN.UseVisualStyleBackColor = true;
            this.saveEditBTN.Click += new System.EventHandler(this.saveEditBTN_Click);
            // 
            // removeAllBTN
            // 
            this.removeAllBTN.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.removeAllBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.removeAllBTN.Location = new System.Drawing.Point(449, 3);
            this.removeAllBTN.Margin = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.removeAllBTN.Name = "removeAllBTN";
            this.removeAllBTN.Size = new System.Drawing.Size(82, 32);
            this.removeAllBTN.TabIndex = 23;
            this.removeAllBTN.Text = "Remove all";
            this.removeAllBTN.UseVisualStyleBackColor = true;
            this.removeAllBTN.Click += new System.EventHandler(this.removeAllBTN_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.exportPB1);
            this.flowLayoutPanel1.Controls.Add(this.importPB1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(138, 2);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(259, 34);
            this.flowLayoutPanel1.TabIndex = 26;
            // 
            // exportPB1
            // 
            this.exportPB1.BackgroundImage = global::SmartRDP_v1._0._0.Properties.Resources.export1_4;
            this.exportPB1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.exportPB1.Controls.Add(this.exportColCount);
            this.exportPB1.Location = new System.Drawing.Point(2, 2);
            this.exportPB1.Margin = new System.Windows.Forms.Padding(2);
            this.exportPB1.Name = "exportPB1";
            this.exportPB1.Size = new System.Drawing.Size(29, 32);
            this.exportPB1.TabIndex = 11;
            this.exportPB1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.exportPB1_MouseMove);
            // 
            // exportColCount
            // 
            this.exportColCount.AutoSize = true;
            this.exportColCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.exportColCount.Location = new System.Drawing.Point(19, 0);
            this.exportColCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.exportColCount.Name = "exportColCount";
            this.exportColCount.Size = new System.Drawing.Size(10, 9);
            this.exportColCount.TabIndex = 10;
            this.exportColCount.Text = "0";
            // 
            // importPB1
            // 
            this.importPB1.BackgroundImage = global::SmartRDP_v1._0._0.Properties.Resources.import1_4;
            this.importPB1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.importPB1.Controls.Add(this.importColCount);
            this.importPB1.Location = new System.Drawing.Point(35, 2);
            this.importPB1.Margin = new System.Windows.Forms.Padding(2);
            this.importPB1.Name = "importPB1";
            this.importPB1.Size = new System.Drawing.Size(29, 32);
            this.importPB1.TabIndex = 12;
            this.importPB1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.importPB1_MouseMove);
            // 
            // importColCount
            // 
            this.importColCount.AutoSize = true;
            this.importColCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 4.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.importColCount.Location = new System.Drawing.Point(21, 0);
            this.importColCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.importColCount.Name = "importColCount";
            this.importColCount.Size = new System.Drawing.Size(9, 7);
            this.importColCount.TabIndex = 10;
            this.importColCount.Text = "0";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // rightClickMenuStripExport
            // 
            this.rightClickMenuStripExport.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.rightClickMenuStripExport.Name = "rightClickMenuStrip";
            this.rightClickMenuStripExport.Size = new System.Drawing.Size(61, 4);
            this.rightClickMenuStripExport.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.rightClickMenuStripExport_ItemClicked);
            // 
            // tblrdpBookmarks2BindingSource
            // 
            this.tblrdpBookmarks2BindingSource.DataMember = "tbl_rdpBookmarks2";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "rightClickMenuStrip";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // rightClickMenuStripImport
            // 
            this.rightClickMenuStripImport.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.rightClickMenuStripImport.Name = "rightClickMenuStrip";
            this.rightClickMenuStripImport.Size = new System.Drawing.Size(61, 4);
            this.rightClickMenuStripImport.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.rightClickMenuStripImport_ItemClicked);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.dgv_bookmark, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.8F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.2F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(677, 375);
            this.tableLayoutPanel2.TabIndex = 23;
            // 
            // rdpBookmarks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 375);
            this.Controls.Add(this.tableLayoutPanel2);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "rdpBookmarks";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bookmarks";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.rdpBookmarks_FormClosing);
            this.Load += new System.EventHandler(this.rdpBookmarks_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_bookmark)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.exportPB1.ResumeLayout(false);
            this.exportPB1.PerformLayout();
            this.importPB1.ResumeLayout(false);
            this.importPB1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblrdpBookmarks2BindingSource)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_bookmark;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button saveEditBTN;
        private System.Windows.Forms.Button removeAllBTN;
        private System.Windows.Forms.Button editModeBTN;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
 //       private SmartRDPDataSet1 smartRDPDataSet1;
        private System.Windows.Forms.BindingSource tblrdpBookmarks2BindingSource;
        private System.Windows.Forms.ContextMenuStrip rightClickMenuStripExport;
        private System.Windows.Forms.Panel exportPB1;
        private System.Windows.Forms.Label exportColCount;
        private System.Windows.Forms.Panel importPB1;
        private System.Windows.Forms.Label importColCount;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip rightClickMenuStripImport;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        //      private SmartRDPDataSet1TableAdapters.tbl_rdpBookmarks2TableAdapter tbl_rdpBookmarks2TableAdapter;
    }
}