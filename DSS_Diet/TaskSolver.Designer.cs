
namespace DietProject
{
    partial class TaskSolver
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskSolver));
            this.DTUnselectButton = new System.Windows.Forms.Button();
            this.DTSelectButton = new System.Windows.Forms.Button();
            this.TDSolveButton = new System.Windows.Forms.Button();
            this.DietProductsLabel = new System.Windows.Forms.Label();
            this.DietProductsListBox = new System.Windows.Forms.ListBox();
            this.DTProductsNamesLabel = new System.Windows.Forms.Label();
            this.DTProductsNamesListBox = new System.Windows.Forms.ListBox();
            this.TSMoneyNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TDMoneyLabel = new System.Windows.Forms.Label();
            this.TSRubLabel = new System.Windows.Forms.Label();
            this.SurnameTextBox = new DietProject.WaterMarkTextBox();
            this.TSSurnameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DNPatientParametersSetComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TSPatronymLabel1 = new System.Windows.Forms.Label();
            this.waterMarkTextBox1 = new DietProject.WaterMarkTextBox();
            this.TSNameLabel = new System.Windows.Forms.Label();
            this.waterMarkTextBox2 = new DietProject.WaterMarkTextBox();
            this.TSPatronymLabel2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TSMoneyNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // DTUnselectButton
            // 
            resources.ApplyResources(this.DTUnselectButton, "DTUnselectButton");
            this.DTUnselectButton.BackColor = System.Drawing.SystemColors.Window;
            this.DTUnselectButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.DTUnselectButton.Name = "DTUnselectButton";
            this.DTUnselectButton.TabStop = false;
            this.DTUnselectButton.UseVisualStyleBackColor = false;
            this.DTUnselectButton.Click += new System.EventHandler(this.DTUnselectButton_Click);
            // 
            // DTSelectButton
            // 
            resources.ApplyResources(this.DTSelectButton, "DTSelectButton");
            this.DTSelectButton.BackColor = System.Drawing.SystemColors.Window;
            this.DTSelectButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.DTSelectButton.Name = "DTSelectButton";
            this.DTSelectButton.TabStop = false;
            this.DTSelectButton.UseVisualStyleBackColor = false;
            this.DTSelectButton.Click += new System.EventHandler(this.DTSelectButton_Click);
            // 
            // TDSolveButton
            // 
            resources.ApplyResources(this.TDSolveButton, "TDSolveButton");
            this.TDSolveButton.BackColor = System.Drawing.Color.PaleGreen;
            this.TDSolveButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.TDSolveButton.Name = "TDSolveButton";
            this.TDSolveButton.TabStop = false;
            this.TDSolveButton.UseVisualStyleBackColor = false;
            this.TDSolveButton.Click += new System.EventHandler(this.TDSolveButton_Click);
            // 
            // DietProductsLabel
            // 
            resources.ApplyResources(this.DietProductsLabel, "DietProductsLabel");
            this.DietProductsLabel.BackColor = System.Drawing.Color.LightGreen;
            this.DietProductsLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DietProductsLabel.Name = "DietProductsLabel";
            // 
            // DietProductsListBox
            // 
            resources.ApplyResources(this.DietProductsListBox, "DietProductsListBox");
            this.DietProductsListBox.FormattingEnabled = true;
            this.DietProductsListBox.Name = "DietProductsListBox";
            this.DietProductsListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.DietProductsListBox.TabStop = false;
            // 
            // DTProductsNamesLabel
            // 
            resources.ApplyResources(this.DTProductsNamesLabel, "DTProductsNamesLabel");
            this.DTProductsNamesLabel.BackColor = System.Drawing.Color.LightGreen;
            this.DTProductsNamesLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DTProductsNamesLabel.Name = "DTProductsNamesLabel";
            // 
            // DTProductsNamesListBox
            // 
            resources.ApplyResources(this.DTProductsNamesListBox, "DTProductsNamesListBox");
            this.DTProductsNamesListBox.FormattingEnabled = true;
            this.DTProductsNamesListBox.Name = "DTProductsNamesListBox";
            this.DTProductsNamesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.DTProductsNamesListBox.TabStop = false;
            // 
            // TSMoneyNumericUpDown
            // 
            resources.ApplyResources(this.TSMoneyNumericUpDown, "TSMoneyNumericUpDown");
            this.TSMoneyNumericUpDown.Maximum = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            this.TSMoneyNumericUpDown.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.TSMoneyNumericUpDown.Name = "TSMoneyNumericUpDown";
            this.TSMoneyNumericUpDown.TabStop = false;
            this.TSMoneyNumericUpDown.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // TDMoneyLabel
            // 
            resources.ApplyResources(this.TDMoneyLabel, "TDMoneyLabel");
            this.TDMoneyLabel.Name = "TDMoneyLabel";
            // 
            // TSRubLabel
            // 
            resources.ApplyResources(this.TSRubLabel, "TSRubLabel");
            this.TSRubLabel.Name = "TSRubLabel";
            // 
            // SurnameTextBox
            // 
            resources.ApplyResources(this.SurnameTextBox, "SurnameTextBox");
            this.SurnameTextBox.Name = "SurnameTextBox";
            this.SurnameTextBox.TabStop = false;
            this.SurnameTextBox.WaterMarkColor = System.Drawing.Color.Gray;
            this.SurnameTextBox.WaterMarkText = "Фамилия пациента";
            // 
            // TSSurnameLabel
            // 
            resources.ApplyResources(this.TSSurnameLabel, "TSSurnameLabel");
            this.TSSurnameLabel.Name = "TSSurnameLabel";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // DNPatientParametersSetComboBox
            // 
            resources.ApplyResources(this.DNPatientParametersSetComboBox, "DNPatientParametersSetComboBox");
            this.DNPatientParametersSetComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DNPatientParametersSetComboBox.FormattingEnabled = true;
            this.DNPatientParametersSetComboBox.Name = "DNPatientParametersSetComboBox";
            this.DNPatientParametersSetComboBox.TabStop = false;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // TSPatronymLabel1
            // 
            resources.ApplyResources(this.TSPatronymLabel1, "TSPatronymLabel1");
            this.TSPatronymLabel1.Name = "TSPatronymLabel1";
            // 
            // waterMarkTextBox1
            // 
            resources.ApplyResources(this.waterMarkTextBox1, "waterMarkTextBox1");
            this.waterMarkTextBox1.Name = "waterMarkTextBox1";
            this.waterMarkTextBox1.TabStop = false;
            this.waterMarkTextBox1.WaterMarkColor = System.Drawing.Color.Gray;
            this.waterMarkTextBox1.WaterMarkText = "Отчество пациента";
            // 
            // TSNameLabel
            // 
            resources.ApplyResources(this.TSNameLabel, "TSNameLabel");
            this.TSNameLabel.Name = "TSNameLabel";
            // 
            // waterMarkTextBox2
            // 
            resources.ApplyResources(this.waterMarkTextBox2, "waterMarkTextBox2");
            this.waterMarkTextBox2.Name = "waterMarkTextBox2";
            this.waterMarkTextBox2.TabStop = false;
            this.waterMarkTextBox2.WaterMarkColor = System.Drawing.Color.Gray;
            this.waterMarkTextBox2.WaterMarkText = "Имя пациента";
            // 
            // TSPatronymLabel2
            // 
            resources.ApplyResources(this.TSPatronymLabel2, "TSPatronymLabel2");
            this.TSPatronymLabel2.Name = "TSPatronymLabel2";
            // 
            // TaskSolver
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.TSPatronymLabel2);
            this.Controls.Add(this.TSNameLabel);
            this.Controls.Add(this.waterMarkTextBox2);
            this.Controls.Add(this.TSPatronymLabel1);
            this.Controls.Add(this.waterMarkTextBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DNPatientParametersSetComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TSSurnameLabel);
            this.Controls.Add(this.SurnameTextBox);
            this.Controls.Add(this.TSRubLabel);
            this.Controls.Add(this.TSMoneyNumericUpDown);
            this.Controls.Add(this.TDMoneyLabel);
            this.Controls.Add(this.DTUnselectButton);
            this.Controls.Add(this.DTSelectButton);
            this.Controls.Add(this.TDSolveButton);
            this.Controls.Add(this.DietProductsLabel);
            this.Controls.Add(this.DietProductsListBox);
            this.Controls.Add(this.DTProductsNamesLabel);
            this.Controls.Add(this.DTProductsNamesListBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TaskSolver";
            this.Load += new System.EventHandler(this.TaskDataInput_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TSMoneyNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DTUnselectButton;
        private System.Windows.Forms.Button DTSelectButton;
        private System.Windows.Forms.Button TDSolveButton;
        private System.Windows.Forms.Label DietProductsLabel;
        private System.Windows.Forms.ListBox DietProductsListBox;
        private System.Windows.Forms.Label DTProductsNamesLabel;
        private System.Windows.Forms.ListBox DTProductsNamesListBox;
        private System.Windows.Forms.NumericUpDown TSMoneyNumericUpDown;
        private System.Windows.Forms.Label TDMoneyLabel;
        private System.Windows.Forms.Label TSRubLabel;
        private WaterMarkTextBox SurnameTextBox;
        private System.Windows.Forms.Label TSSurnameLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox DNPatientParametersSetComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label TSPatronymLabel1;
        private WaterMarkTextBox waterMarkTextBox1;
        private System.Windows.Forms.Label TSNameLabel;
        private WaterMarkTextBox waterMarkTextBox2;
        private System.Windows.Forms.Label TSPatronymLabel2;
    }
}