
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
            this.TSUnselectButton = new System.Windows.Forms.Button();
            this.TSSelectButton = new System.Windows.Forms.Button();
            this.TDSolveButton = new System.Windows.Forms.Button();
            this.TSDietProductsLabel = new System.Windows.Forms.Label();
            this.TSDietProductsListBox = new System.Windows.Forms.ListBox();
            this.TSProductsNamesLabel = new System.Windows.Forms.Label();
            this.TSProductsNamesListBox = new System.Windows.Forms.ListBox();
            this.TSMoneyNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TSMoneyLabel = new System.Windows.Forms.Label();
            this.TSRubLabel = new System.Windows.Forms.Label();
            this.TSSurnameTextBox = new DietProject.WaterMarkTextBox();
            this.TSSurnameLabel = new System.Windows.Forms.Label();
            this.TSPatientParametersSetLabel = new System.Windows.Forms.Label();
            this.TSPatientParametersSetComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TSPatronymLabel1 = new System.Windows.Forms.Label();
            this.TSPatronymTextBox = new DietProject.WaterMarkTextBox();
            this.TSNameLabel = new System.Windows.Forms.Label();
            this.TSNameTextBox = new DietProject.WaterMarkTextBox();
            this.TSPatronymLabel2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TSMoneyNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // TSUnselectButton
            // 
            resources.ApplyResources(this.TSUnselectButton, "TSUnselectButton");
            this.TSUnselectButton.BackColor = System.Drawing.SystemColors.Window;
            this.TSUnselectButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.TSUnselectButton.Name = "TSUnselectButton";
            this.TSUnselectButton.TabStop = false;
            this.TSUnselectButton.UseVisualStyleBackColor = false;
            this.TSUnselectButton.Click += new System.EventHandler(this.TSUnselectButton_Click);
            // 
            // TSSelectButton
            // 
            resources.ApplyResources(this.TSSelectButton, "TSSelectButton");
            this.TSSelectButton.BackColor = System.Drawing.SystemColors.Window;
            this.TSSelectButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.TSSelectButton.Name = "TSSelectButton";
            this.TSSelectButton.TabStop = false;
            this.TSSelectButton.UseVisualStyleBackColor = false;
            this.TSSelectButton.Click += new System.EventHandler(this.TSSelectButton_Click);
            // 
            // TDSolveButton
            // 
            resources.ApplyResources(this.TDSolveButton, "TDSolveButton");
            this.TDSolveButton.BackColor = System.Drawing.Color.PaleGreen;
            this.TDSolveButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.TDSolveButton.Name = "TDSolveButton";
            this.TDSolveButton.TabStop = false;
            this.TDSolveButton.UseVisualStyleBackColor = false;
            this.TDSolveButton.Click += new System.EventHandler(this.TSSolveButton_Click);
            // 
            // TSDietProductsLabel
            // 
            resources.ApplyResources(this.TSDietProductsLabel, "TSDietProductsLabel");
            this.TSDietProductsLabel.BackColor = System.Drawing.Color.LightGreen;
            this.TSDietProductsLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TSDietProductsLabel.Name = "TSDietProductsLabel";
            // 
            // TSDietProductsListBox
            // 
            resources.ApplyResources(this.TSDietProductsListBox, "TSDietProductsListBox");
            this.TSDietProductsListBox.FormattingEnabled = true;
            this.TSDietProductsListBox.Name = "TSDietProductsListBox";
            this.TSDietProductsListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.TSDietProductsListBox.TabStop = false;
            // 
            // TSProductsNamesLabel
            // 
            resources.ApplyResources(this.TSProductsNamesLabel, "TSProductsNamesLabel");
            this.TSProductsNamesLabel.BackColor = System.Drawing.Color.LightGreen;
            this.TSProductsNamesLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TSProductsNamesLabel.Name = "TSProductsNamesLabel";
            // 
            // TSProductsNamesListBox
            // 
            resources.ApplyResources(this.TSProductsNamesListBox, "TSProductsNamesListBox");
            this.TSProductsNamesListBox.FormattingEnabled = true;
            this.TSProductsNamesListBox.Name = "TSProductsNamesListBox";
            this.TSProductsNamesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.TSProductsNamesListBox.TabStop = false;
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
            // TSMoneyLabel
            // 
            resources.ApplyResources(this.TSMoneyLabel, "TSMoneyLabel");
            this.TSMoneyLabel.Name = "TSMoneyLabel";
            // 
            // TSRubLabel
            // 
            resources.ApplyResources(this.TSRubLabel, "TSRubLabel");
            this.TSRubLabel.Name = "TSRubLabel";
            // 
            // TSSurnameTextBox
            // 
            resources.ApplyResources(this.TSSurnameTextBox, "TSSurnameTextBox");
            this.TSSurnameTextBox.Name = "TSSurnameTextBox";
            this.TSSurnameTextBox.TabStop = false;
            this.TSSurnameTextBox.WaterMarkColor = System.Drawing.Color.Gray;
            this.TSSurnameTextBox.WaterMarkText = "Фамилия пациента";
            // 
            // TSSurnameLabel
            // 
            resources.ApplyResources(this.TSSurnameLabel, "TSSurnameLabel");
            this.TSSurnameLabel.Name = "TSSurnameLabel";
            // 
            // TSPatientParametersSetLabel
            // 
            resources.ApplyResources(this.TSPatientParametersSetLabel, "TSPatientParametersSetLabel");
            this.TSPatientParametersSetLabel.Name = "TSPatientParametersSetLabel";
            // 
            // TSPatientParametersSetComboBox
            // 
            resources.ApplyResources(this.TSPatientParametersSetComboBox, "TSPatientParametersSetComboBox");
            this.TSPatientParametersSetComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TSPatientParametersSetComboBox.FormattingEnabled = true;
            this.TSPatientParametersSetComboBox.Name = "TSPatientParametersSetComboBox";
            this.TSPatientParametersSetComboBox.TabStop = false;
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
            // TSPatronymTextBox
            // 
            resources.ApplyResources(this.TSPatronymTextBox, "TSPatronymTextBox");
            this.TSPatronymTextBox.Name = "TSPatronymTextBox";
            this.TSPatronymTextBox.TabStop = false;
            this.TSPatronymTextBox.WaterMarkColor = System.Drawing.Color.Gray;
            this.TSPatronymTextBox.WaterMarkText = "Отчество пациента";
            // 
            // TSNameLabel
            // 
            resources.ApplyResources(this.TSNameLabel, "TSNameLabel");
            this.TSNameLabel.Name = "TSNameLabel";
            // 
            // TSNameTextBox
            // 
            resources.ApplyResources(this.TSNameTextBox, "TSNameTextBox");
            this.TSNameTextBox.Name = "TSNameTextBox";
            this.TSNameTextBox.TabStop = false;
            this.TSNameTextBox.WaterMarkColor = System.Drawing.Color.Gray;
            this.TSNameTextBox.WaterMarkText = "Имя пациента";
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
            this.Controls.Add(this.TSNameTextBox);
            this.Controls.Add(this.TSPatronymLabel1);
            this.Controls.Add(this.TSPatronymTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TSPatientParametersSetComboBox);
            this.Controls.Add(this.TSPatientParametersSetLabel);
            this.Controls.Add(this.TSSurnameLabel);
            this.Controls.Add(this.TSSurnameTextBox);
            this.Controls.Add(this.TSRubLabel);
            this.Controls.Add(this.TSMoneyNumericUpDown);
            this.Controls.Add(this.TSMoneyLabel);
            this.Controls.Add(this.TSUnselectButton);
            this.Controls.Add(this.TSSelectButton);
            this.Controls.Add(this.TDSolveButton);
            this.Controls.Add(this.TSDietProductsLabel);
            this.Controls.Add(this.TSDietProductsListBox);
            this.Controls.Add(this.TSProductsNamesLabel);
            this.Controls.Add(this.TSProductsNamesListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TaskSolver";
            this.Load += new System.EventHandler(this.TaskSolver_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TSMoneyNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button TSUnselectButton;
        private System.Windows.Forms.Button TSSelectButton;
        private System.Windows.Forms.Button TDSolveButton;
        private System.Windows.Forms.Label TSDietProductsLabel;
        private System.Windows.Forms.ListBox TSDietProductsListBox;
        private System.Windows.Forms.Label TSProductsNamesLabel;
        private System.Windows.Forms.ListBox TSProductsNamesListBox;
        private System.Windows.Forms.NumericUpDown TSMoneyNumericUpDown;
        private System.Windows.Forms.Label TSMoneyLabel;
        private System.Windows.Forms.Label TSRubLabel;
        private WaterMarkTextBox TSSurnameTextBox;
        private System.Windows.Forms.Label TSSurnameLabel;
        private System.Windows.Forms.Label TSPatientParametersSetLabel;
        private System.Windows.Forms.ComboBox TSPatientParametersSetComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label TSPatronymLabel1;
        private WaterMarkTextBox TSPatronymTextBox;
        private System.Windows.Forms.Label TSNameLabel;
        private WaterMarkTextBox TSNameTextBox;
        private System.Windows.Forms.Label TSPatronymLabel2;
    }
}