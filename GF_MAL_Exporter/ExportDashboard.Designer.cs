namespace GF_MAL_Exporter
{
    partial class ExportDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportDashboard));
            this.browseButton = new System.Windows.Forms.Button();
            this.saveAsButton = new System.Windows.Forms.Button();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.exportButton = new System.Windows.Forms.Button();
            this.tableComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.csvRadioButton = new System.Windows.Forms.RadioButton();
            this.txtRadioButton = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.sourceComboBox = new System.Windows.Forms.ComboBox();
            this.exportPanel = new System.Windows.Forms.Panel();
            this.backupCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.exportPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(56, 89);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 1;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // saveAsButton
            // 
            this.saveAsButton.Location = new System.Drawing.Point(16, 12);
            this.saveAsButton.Name = "saveAsButton";
            this.saveAsButton.Size = new System.Drawing.Size(75, 23);
            this.saveAsButton.TabIndex = 2;
            this.saveAsButton.Text = "Save as";
            this.saveAsButton.UseVisualStyleBackColor = true;
            this.saveAsButton.Click += new System.EventHandler(this.SaveAsButton_Click);
            // 
            // pathTextBox
            // 
            this.pathTextBox.Location = new System.Drawing.Point(187, 91);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.ReadOnly = true;
            this.pathTextBox.Size = new System.Drawing.Size(361, 20);
            this.pathTextBox.TabIndex = 3;
            this.pathTextBox.TextChanged += new System.EventHandler(this.PathTextBox_TextChanged);
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(16, 55);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(97, 23);
            this.exportButton.TabIndex = 6;
            this.exportButton.Text = "Export to SQL";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // tableComboBox
            // 
            this.tableComboBox.FormattingEnabled = true;
            this.tableComboBox.Items.AddRange(new object[] {
            "Replace list",
            "Add to list"});
            this.tableComboBox.Location = new System.Drawing.Point(147, 57);
            this.tableComboBox.Name = "tableComboBox";
            this.tableComboBox.Size = new System.Drawing.Size(121, 21);
            this.tableComboBox.TabIndex = 7;
            this.tableComboBox.SelectedIndexChanged += new System.EventHandler(this.TableComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(274, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Note: SQL export is not implemented for public use";
            // 
            // csvRadioButton
            // 
            this.csvRadioButton.AutoSize = true;
            this.csvRadioButton.Location = new System.Drawing.Point(222, 15);
            this.csvRadioButton.Name = "csvRadioButton";
            this.csvRadioButton.Size = new System.Drawing.Size(46, 17);
            this.csvRadioButton.TabIndex = 5;
            this.csvRadioButton.TabStop = true;
            this.csvRadioButton.Text = "CSV";
            this.csvRadioButton.UseVisualStyleBackColor = true;
            // 
            // txtRadioButton
            // 
            this.txtRadioButton.AutoSize = true;
            this.txtRadioButton.Checked = true;
            this.txtRadioButton.Location = new System.Drawing.Point(147, 15);
            this.txtRadioButton.Name = "txtRadioButton";
            this.txtRadioButton.Size = new System.Drawing.Size(46, 17);
            this.txtRadioButton.TabIndex = 4;
            this.txtRadioButton.TabStop = true;
            this.txtRadioButton.Text = "TXT";
            this.txtRadioButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(61, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Source";
            // 
            // sourceComboBox
            // 
            this.sourceComboBox.FormattingEnabled = true;
            this.sourceComboBox.Items.AddRange(new object[] {
            "GameFaqs",
            "MyAnimeList"});
            this.sourceComboBox.Location = new System.Drawing.Point(187, 38);
            this.sourceComboBox.Name = "sourceComboBox";
            this.sourceComboBox.Size = new System.Drawing.Size(121, 21);
            this.sourceComboBox.TabIndex = 10;
            this.sourceComboBox.SelectedIndexChanged += new System.EventHandler(this.SourceComboBox_SelectedIndexChanged);
            // 
            // exportPanel
            // 
            this.exportPanel.Controls.Add(this.label3);
            this.exportPanel.Controls.Add(this.backupCheckBox);
            this.exportPanel.Controls.Add(this.saveAsButton);
            this.exportPanel.Controls.Add(this.tableComboBox);
            this.exportPanel.Controls.Add(this.txtRadioButton);
            this.exportPanel.Controls.Add(this.label1);
            this.exportPanel.Controls.Add(this.csvRadioButton);
            this.exportPanel.Controls.Add(this.exportButton);
            this.exportPanel.Enabled = false;
            this.exportPanel.Location = new System.Drawing.Point(40, 135);
            this.exportPanel.Name = "exportPanel";
            this.exportPanel.Size = new System.Drawing.Size(532, 114);
            this.exportPanel.TabIndex = 12;
            // 
            // backupCheckBox
            // 
            this.backupCheckBox.AutoSize = true;
            this.backupCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backupCheckBox.Location = new System.Drawing.Point(147, 91);
            this.backupCheckBox.Name = "backupCheckBox";
            this.backupCheckBox.Size = new System.Drawing.Size(63, 17);
            this.backupCheckBox.TabIndex = 9;
            this.backupCheckBox.Text = "Backup";
            this.backupCheckBox.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(274, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(245, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Make sure Word Wrap is disabled in your text editor";
            // 
            // ExportDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(584, 261);
            this.Controls.Add(this.exportPanel);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.sourceComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pathTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ExportDashboard";
            this.Text = "ExportDashboard";
            this.exportPanel.ResumeLayout(false);
            this.exportPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Button saveAsButton;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.ComboBox tableComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton csvRadioButton;
        private System.Windows.Forms.RadioButton txtRadioButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox sourceComboBox;
        private System.Windows.Forms.Panel exportPanel;
        private System.Windows.Forms.CheckBox backupCheckBox;
        private System.Windows.Forms.Label label3;
    }
}