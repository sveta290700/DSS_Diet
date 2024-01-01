
namespace DietProject
{
    partial class DietInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DietInfo));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DietsLabel = new System.Windows.Forms.Label();
            this.DIDietInfoDataGridView = new System.Windows.Forms.DataGridView();
            this.DIDIetInfoLabel = new System.Windows.Forms.Label();
            this.DIPrintButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DIDietInfoDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // DietsLabel
            // 
            resources.ApplyResources(this.DietsLabel, "DietsLabel");
            this.DietsLabel.BackColor = System.Drawing.Color.LightGreen;
            this.DietsLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DietsLabel.Name = "DietsLabel";
            // 
            // DIDietInfoDataGridView
            // 
            resources.ApplyResources(this.DIDietInfoDataGridView, "DIDietInfoDataGridView");
            this.DIDietInfoDataGridView.AllowUserToAddRows = false;
            this.DIDietInfoDataGridView.AllowUserToDeleteRows = false;
            this.DIDietInfoDataGridView.AllowUserToResizeColumns = false;
            this.DIDietInfoDataGridView.AllowUserToResizeRows = false;
            this.DIDietInfoDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DIDietInfoDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DIDietInfoDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.DIDietInfoDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DIDietInfoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DIDietInfoDataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.DIDietInfoDataGridView.MultiSelect = false;
            this.DIDietInfoDataGridView.Name = "DIDietInfoDataGridView";
            this.DIDietInfoDataGridView.ReadOnly = true;
            this.DIDietInfoDataGridView.RowHeadersVisible = false;
            this.DIDietInfoDataGridView.RowTemplate.Height = 25;
            this.DIDietInfoDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DIDietInfoDataGridView.ShowCellToolTips = false;
            this.DIDietInfoDataGridView.TabStop = false;
            this.DIDietInfoDataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DIDietInfoDataGridView_DataBindingComplete);
            // 
            // DIDIetInfoLabel
            // 
            resources.ApplyResources(this.DIDIetInfoLabel, "DIDIetInfoLabel");
            this.DIDIetInfoLabel.Name = "DIDIetInfoLabel";
            // 
            // DIPrintButton
            // 
            resources.ApplyResources(this.DIPrintButton, "DIPrintButton");
            this.DIPrintButton.BackColor = System.Drawing.Color.PaleGreen;
            this.DIPrintButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.DIPrintButton.Name = "DIPrintButton";
            this.DIPrintButton.TabStop = false;
            this.DIPrintButton.UseVisualStyleBackColor = false;
            this.DIPrintButton.Click += new System.EventHandler(this.DIPrintButton_Click);
            // 
            // DietInfo
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.DIPrintButton);
            this.Controls.Add(this.DIDIetInfoLabel);
            this.Controls.Add(this.DIDietInfoDataGridView);
            this.Controls.Add(this.DietsLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DietInfo";
            this.Load += new System.EventHandler(this.DietInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DIDietInfoDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DietsLabel;
        private System.Windows.Forms.DataGridView DIDietInfoDataGridView;
        private System.Windows.Forms.Label DIDIetInfoLabel;
        private System.Windows.Forms.Button DIPrintButton;
    }
}