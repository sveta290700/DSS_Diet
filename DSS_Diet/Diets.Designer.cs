
namespace DietProject
{
    partial class Diets
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Diets));
            this.DietsLabel = new System.Windows.Forms.Label();
            this.DSearchButton = new System.Windows.Forms.Button();
            this.DCancelButton = new System.Windows.Forms.Button();
            this.DSetChoiceLabel = new System.Windows.Forms.Label();
            this.DSearchLabel = new System.Windows.Forms.Label();
            this.DNameLabel = new System.Windows.Forms.Label();
            this.DNameTextBox = new DietProject.WaterMarkTextBox();
            this.DPatronymLabel = new System.Windows.Forms.Label();
            this.DPatronymTextBox = new DietProject.WaterMarkTextBox();
            this.DSurnameLabel = new System.Windows.Forms.Label();
            this.DSurnameTextBox = new DietProject.WaterMarkTextBox();
            this.DPatientParametersSetComboBox = new System.Windows.Forms.ComboBox();
            this.DDietsDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DDietsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // DietsLabel
            // 
            resources.ApplyResources(this.DietsLabel, "DietsLabel");
            this.DietsLabel.BackColor = System.Drawing.Color.LightGreen;
            this.DietsLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DietsLabel.Name = "DietsLabel";
            // 
            // DSearchButton
            // 
            resources.ApplyResources(this.DSearchButton, "DSearchButton");
            this.DSearchButton.BackColor = System.Drawing.Color.PaleGreen;
            this.DSearchButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.DSearchButton.Name = "DSearchButton";
            this.DSearchButton.TabStop = false;
            this.DSearchButton.UseVisualStyleBackColor = false;
            this.DSearchButton.Click += new System.EventHandler(this.DSearchButton_Click);
            // 
            // DCancelButton
            // 
            resources.ApplyResources(this.DCancelButton, "DCancelButton");
            this.DCancelButton.BackColor = System.Drawing.Color.PaleGreen;
            this.DCancelButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.DCancelButton.Name = "DCancelButton";
            this.DCancelButton.TabStop = false;
            this.DCancelButton.UseVisualStyleBackColor = false;
            this.DCancelButton.Click += new System.EventHandler(this.DCancelButton_Click);
            // 
            // DSetChoiceLabel
            // 
            resources.ApplyResources(this.DSetChoiceLabel, "DSetChoiceLabel");
            this.DSetChoiceLabel.Name = "DSetChoiceLabel";
            // 
            // DSearchLabel
            // 
            resources.ApplyResources(this.DSearchLabel, "DSearchLabel");
            this.DSearchLabel.Name = "DSearchLabel";
            // 
            // DNameLabel
            // 
            resources.ApplyResources(this.DNameLabel, "DNameLabel");
            this.DNameLabel.Name = "DNameLabel";
            // 
            // DNameTextBox
            // 
            resources.ApplyResources(this.DNameTextBox, "DNameTextBox");
            this.DNameTextBox.Name = "DNameTextBox";
            this.DNameTextBox.TabStop = false;
            this.DNameTextBox.WaterMarkColor = System.Drawing.Color.Gray;
            this.DNameTextBox.WaterMarkText = "Имя пациента";
            // 
            // DPatronymLabel
            // 
            resources.ApplyResources(this.DPatronymLabel, "DPatronymLabel");
            this.DPatronymLabel.Name = "DPatronymLabel";
            // 
            // DPatronymTextBox
            // 
            resources.ApplyResources(this.DPatronymTextBox, "DPatronymTextBox");
            this.DPatronymTextBox.Name = "DPatronymTextBox";
            this.DPatronymTextBox.TabStop = false;
            this.DPatronymTextBox.WaterMarkColor = System.Drawing.Color.Gray;
            this.DPatronymTextBox.WaterMarkText = "Отчество пациента";
            // 
            // DSurnameLabel
            // 
            resources.ApplyResources(this.DSurnameLabel, "DSurnameLabel");
            this.DSurnameLabel.Name = "DSurnameLabel";
            // 
            // DSurnameTextBox
            // 
            resources.ApplyResources(this.DSurnameTextBox, "DSurnameTextBox");
            this.DSurnameTextBox.Name = "DSurnameTextBox";
            this.DSurnameTextBox.TabStop = false;
            this.DSurnameTextBox.WaterMarkColor = System.Drawing.Color.Gray;
            this.DSurnameTextBox.WaterMarkText = "Фамилия пациента";
            // 
            // DPatientParametersSetComboBox
            // 
            resources.ApplyResources(this.DPatientParametersSetComboBox, "DPatientParametersSetComboBox");
            this.DPatientParametersSetComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DPatientParametersSetComboBox.FormattingEnabled = true;
            this.DPatientParametersSetComboBox.Name = "DPatientParametersSetComboBox";
            this.DPatientParametersSetComboBox.TabStop = false;
            // 
            // DDietsDataGridView
            // 
            resources.ApplyResources(this.DDietsDataGridView, "DDietsDataGridView");
            this.DDietsDataGridView.AllowUserToAddRows = false;
            this.DDietsDataGridView.AllowUserToDeleteRows = false;
            this.DDietsDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.DDietsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DDietsDataGridView.Name = "DDietsDataGridView";
            this.DDietsDataGridView.ReadOnly = true;
            this.DDietsDataGridView.RowTemplate.Height = 25;
            // 
            // Diets
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.DDietsDataGridView);
            this.Controls.Add(this.DPatientParametersSetComboBox);
            this.Controls.Add(this.DNameLabel);
            this.Controls.Add(this.DNameTextBox);
            this.Controls.Add(this.DPatronymLabel);
            this.Controls.Add(this.DPatronymTextBox);
            this.Controls.Add(this.DSurnameLabel);
            this.Controls.Add(this.DSurnameTextBox);
            this.Controls.Add(this.DSearchLabel);
            this.Controls.Add(this.DSetChoiceLabel);
            this.Controls.Add(this.DCancelButton);
            this.Controls.Add(this.DSearchButton);
            this.Controls.Add(this.DietsLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Diets";
            this.Load += new System.EventHandler(this.Products_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DDietsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DietsLabel;
        private System.Windows.Forms.Button DSearchButton;
        private System.Windows.Forms.Button DCancelButton;
        private System.Windows.Forms.Label DSetChoiceLabel;
        private System.Windows.Forms.Label DSearchLabel;
        private System.Windows.Forms.Label DNameLabel;
        private WaterMarkTextBox DNameTextBox;
        private System.Windows.Forms.Label DPatronymLabel;
        private WaterMarkTextBox DPatronymTextBox;
        private System.Windows.Forms.Label DSurnameLabel;
        private WaterMarkTextBox DSurnameTextBox;
        private System.Windows.Forms.ComboBox DPatientParametersSetComboBox;
        private System.Windows.Forms.DataGridView DDietsDataGridView;
    }
}