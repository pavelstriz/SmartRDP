namespace SmartRDP_v1._0._0
{
    partial class pictureBoxWCount
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
            this.selectedColNumber = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // selectedColNumber
            // 
            this.selectedColNumber.AutoSize = true;
            this.selectedColNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.selectedColNumber.Location = new System.Drawing.Point(17, 0);
            this.selectedColNumber.Name = "selectedColNumber";
            this.selectedColNumber.Size = new System.Drawing.Size(22, 24);
            this.selectedColNumber.TabIndex = 2;
            this.selectedColNumber.Text = "n";
            // 
            // pictureBoxWCount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.selectedColNumber);
            this.Name = "pictureBoxWCount";
            this.Size = new System.Drawing.Size(70, 39);
            this.Load += new System.EventHandler(this.pictureBoxWCount_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label selectedColNumber;
    }
}
