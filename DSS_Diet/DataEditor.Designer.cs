
namespace DietProject
{
    partial class DataEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataEditor));
            this.KEChoiceLabel = new System.Windows.Forms.Label();
            this.KLSectionsListBox = new System.Windows.Forms.ListBox();
            this.SectionLabel = new System.Windows.Forms.Label();
            this.DEChoiceButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // KEChoiceLabel
            // 
            resources.ApplyResources(this.KEChoiceLabel, "KEChoiceLabel");
            this.KEChoiceLabel.Name = "KEChoiceLabel";
            // 
            // KLSectionsListBox
            // 
            resources.ApplyResources(this.KLSectionsListBox, "KLSectionsListBox");
            this.KLSectionsListBox.FormattingEnabled = true;
            this.KLSectionsListBox.Items.AddRange(new object[] {
            resources.GetString("KLSectionsListBox.Items"),
            resources.GetString("KLSectionsListBox.Items1"),
            resources.GetString("KLSectionsListBox.Items2"),
            resources.GetString("KLSectionsListBox.Items3")});
            this.KLSectionsListBox.Name = "KLSectionsListBox";
            this.KLSectionsListBox.TabStop = false;
            // 
            // SectionLabel
            // 
            resources.ApplyResources(this.SectionLabel, "SectionLabel");
            this.SectionLabel.BackColor = System.Drawing.Color.LightGreen;
            this.SectionLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SectionLabel.Name = "SectionLabel";
            // 
            // DEChoiceButton
            // 
            resources.ApplyResources(this.DEChoiceButton, "DEChoiceButton");
            this.DEChoiceButton.BackColor = System.Drawing.Color.PaleGreen;
            this.DEChoiceButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.DEChoiceButton.Name = "DEChoiceButton";
            this.DEChoiceButton.TabStop = false;
            this.DEChoiceButton.UseVisualStyleBackColor = false;
            this.DEChoiceButton.Click += new System.EventHandler(this.DEChoiceButton_Click);
            // 
            // DataEditor
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.DEChoiceButton);
            this.Controls.Add(this.SectionLabel);
            this.Controls.Add(this.KLSectionsListBox);
            this.Controls.Add(this.KEChoiceLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DataEditor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label KEChoiceLabel;
        private System.Windows.Forms.ListBox KLSectionsListBox;
        private System.Windows.Forms.Label SectionLabel;
        private System.Windows.Forms.Button DEChoiceButton;
    }
}