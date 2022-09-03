namespace MIMIRSOFT
{
    partial class deviceSearchForm
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
            this.searchLbl = new System.Windows.Forms.Label();
            this.searchTbx = new System.Windows.Forms.TextBox();
            this.searchBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.fullStringCbx = new System.Windows.Forms.CheckBox();
            this.caseSensCbx = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // searchLbl
            // 
            this.searchLbl.AutoSize = true;
            this.searchLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.searchLbl.Location = new System.Drawing.Point(24, 32);
            this.searchLbl.Name = "searchLbl";
            this.searchLbl.Size = new System.Drawing.Size(81, 15);
            this.searchLbl.TabIndex = 0;
            this.searchLbl.Text = "Rechercher : ";
            // 
            // searchTbx
            // 
            this.searchTbx.Location = new System.Drawing.Point(135, 29);
            this.searchTbx.Name = "searchTbx";
            this.searchTbx.Size = new System.Drawing.Size(208, 23);
            this.searchTbx.TabIndex = 1;
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(359, 28);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(75, 23);
            this.searchBtn.TabIndex = 2;
            this.searchBtn.Text = "OK";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(359, 80);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(75, 23);
            this.CancelBtn.TabIndex = 3;
            this.CancelBtn.Text = "Annuler";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // fullStringCbx
            // 
            this.fullStringCbx.AutoSize = true;
            this.fullStringCbx.Location = new System.Drawing.Point(42, 84);
            this.fullStringCbx.Name = "fullStringCbx";
            this.fullStringCbx.Size = new System.Drawing.Size(81, 19);
            this.fullStringCbx.TabIndex = 4;
            this.fullStringCbx.Text = "Mot entier";
            this.fullStringCbx.UseVisualStyleBackColor = true;
            // 
            // caseSensCbx
            // 
            this.caseSensCbx.AutoSize = true;
            this.caseSensCbx.Location = new System.Drawing.Point(178, 84);
            this.caseSensCbx.Name = "caseSensCbx";
            this.caseSensCbx.Size = new System.Drawing.Size(121, 19);
            this.caseSensCbx.TabIndex = 5;
            this.caseSensCbx.Text = "Sensible à la casse";
            this.caseSensCbx.UseVisualStyleBackColor = true;
            // 
            // deviceSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 124);
            this.Controls.Add(this.caseSensCbx);
            this.Controls.Add(this.fullStringCbx);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.searchTbx);
            this.Controls.Add(this.searchLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "deviceSearchForm";
            this.Text = "Recherhe de périphériques";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label searchLbl;
        private TextBox searchTbx;
        private Button searchBtn;
        private Button CancelBtn;
        private CheckBox fullStringCbx;
        private CheckBox caseSensCbx;
    }
}