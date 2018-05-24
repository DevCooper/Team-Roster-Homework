namespace TeamRoster
{
    partial class TeamRosterForm
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
            this.SelectPlayerLabel = new System.Windows.Forms.Label();
            this.SelectPlayerComboBox = new System.Windows.Forms.ComboBox();
            this.LastNameTextBox = new System.Windows.Forms.TextBox();
            this.FirstNameTextBox = new System.Windows.Forms.TextBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.AcceptButton = new System.Windows.Forms.Button();
            this.LastNameLabel = new System.Windows.Forms.Label();
            this.FirstNameLabel = new System.Windows.Forms.Label();
            this.NumberLabel = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.ResultLabel = new System.Windows.Forms.Label();
            this.NumberMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // SelectPlayerLabel
            // 
            this.SelectPlayerLabel.AutoSize = true;
            this.SelectPlayerLabel.Location = new System.Drawing.Point(12, 29);
            this.SelectPlayerLabel.Name = "SelectPlayerLabel";
            this.SelectPlayerLabel.Size = new System.Drawing.Size(99, 17);
            this.SelectPlayerLabel.TabIndex = 0;
            this.SelectPlayerLabel.Text = "Select Player :";
            // 
            // SelectPlayerComboBox
            // 
            this.SelectPlayerComboBox.FormattingEnabled = true;
            this.SelectPlayerComboBox.Location = new System.Drawing.Point(117, 26);
            this.SelectPlayerComboBox.Name = "SelectPlayerComboBox";
            this.SelectPlayerComboBox.Size = new System.Drawing.Size(196, 24);
            this.SelectPlayerComboBox.TabIndex = 1;
            this.SelectPlayerComboBox.SelectedIndexChanged += new System.EventHandler(this.SelectPlayerComboBox_SelectedIndexChanged);
            // 
            // LastNameTextBox
            // 
            this.LastNameTextBox.Enabled = false;
            this.LastNameTextBox.Location = new System.Drawing.Point(117, 70);
            this.LastNameTextBox.Name = "LastNameTextBox";
            this.LastNameTextBox.Size = new System.Drawing.Size(196, 22);
            this.LastNameTextBox.TabIndex = 2;
            // 
            // FirstNameTextBox
            // 
            this.FirstNameTextBox.Enabled = false;
            this.FirstNameTextBox.Location = new System.Drawing.Point(117, 98);
            this.FirstNameTextBox.Name = "FirstNameTextBox";
            this.FirstNameTextBox.Size = new System.Drawing.Size(196, 22);
            this.FirstNameTextBox.TabIndex = 3;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(15, 154);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(96, 23);
            this.AddButton.TabIndex = 5;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.Enabled = false;
            this.EditButton.Location = new System.Drawing.Point(117, 154);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(96, 23);
            this.EditButton.TabIndex = 6;
            this.EditButton.Text = "Edit";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Enabled = false;
            this.DeleteButton.Location = new System.Drawing.Point(219, 154);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(94, 23);
            this.DeleteButton.TabIndex = 7;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Enabled = false;
            this.CancelButton.Location = new System.Drawing.Point(79, 183);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(109, 23);
            this.CancelButton.TabIndex = 8;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // AcceptButton
            // 
            this.AcceptButton.Enabled = false;
            this.AcceptButton.Location = new System.Drawing.Point(194, 183);
            this.AcceptButton.Name = "AcceptButton";
            this.AcceptButton.Size = new System.Drawing.Size(119, 23);
            this.AcceptButton.TabIndex = 9;
            this.AcceptButton.Text = "Accept";
            this.AcceptButton.UseVisualStyleBackColor = true;
            this.AcceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // LastNameLabel
            // 
            this.LastNameLabel.AutoSize = true;
            this.LastNameLabel.Location = new System.Drawing.Point(12, 73);
            this.LastNameLabel.Name = "LastNameLabel";
            this.LastNameLabel.Size = new System.Drawing.Size(84, 17);
            this.LastNameLabel.TabIndex = 10;
            this.LastNameLabel.Text = "Last Name :";
            // 
            // FirstNameLabel
            // 
            this.FirstNameLabel.AutoSize = true;
            this.FirstNameLabel.Location = new System.Drawing.Point(12, 101);
            this.FirstNameLabel.Name = "FirstNameLabel";
            this.FirstNameLabel.Size = new System.Drawing.Size(84, 17);
            this.FirstNameLabel.TabIndex = 11;
            this.FirstNameLabel.Text = "First Name :";
            // 
            // NumberLabel
            // 
            this.NumberLabel.AutoSize = true;
            this.NumberLabel.Location = new System.Drawing.Point(12, 129);
            this.NumberLabel.Name = "NumberLabel";
            this.NumberLabel.Size = new System.Drawing.Size(66, 17);
            this.NumberLabel.TabIndex = 12;
            this.NumberLabel.Text = "Number :";
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(194, 231);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(119, 23);
            this.ExitButton.TabIndex = 10;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // ResultLabel
            // 
            this.ResultLabel.AutoSize = true;
            this.ResultLabel.Location = new System.Drawing.Point(12, 221);
            this.ResultLabel.Name = "ResultLabel";
            this.ResultLabel.Size = new System.Drawing.Size(0, 17);
            this.ResultLabel.TabIndex = 14;
            // 
            // NumberMaskedTextBox
            // 
            this.NumberMaskedTextBox.Enabled = false;
            this.NumberMaskedTextBox.Location = new System.Drawing.Point(117, 126);
            this.NumberMaskedTextBox.Mask = "09";
            this.NumberMaskedTextBox.Name = "NumberMaskedTextBox";
            this.NumberMaskedTextBox.Size = new System.Drawing.Size(31, 22);
            this.NumberMaskedTextBox.TabIndex = 4;
            this.NumberMaskedTextBox.ValidatingType = typeof(int);
            this.NumberMaskedTextBox.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.NumberMaskedTextBox_MaskInputRejected);
            // 
            // TeamRosterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 266);
            this.Controls.Add(this.NumberMaskedTextBox);
            this.Controls.Add(this.ResultLabel);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.NumberLabel);
            this.Controls.Add(this.FirstNameLabel);
            this.Controls.Add(this.LastNameLabel);
            this.Controls.Add(this.AcceptButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.FirstNameTextBox);
            this.Controls.Add(this.LastNameTextBox);
            this.Controls.Add(this.SelectPlayerComboBox);
            this.Controls.Add(this.SelectPlayerLabel);
            this.Name = "TeamRosterForm";
            this.Text = "TeamRoster";
            this.Load += new System.EventHandler(this.TeamRosterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SelectPlayerLabel;
        private System.Windows.Forms.ComboBox SelectPlayerComboBox;
        private System.Windows.Forms.TextBox LastNameTextBox;
        private System.Windows.Forms.TextBox FirstNameTextBox;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button AcceptButton;
        private System.Windows.Forms.Label LastNameLabel;
        private System.Windows.Forms.Label FirstNameLabel;
        private System.Windows.Forms.Label NumberLabel;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Label ResultLabel;
        private System.Windows.Forms.MaskedTextBox NumberMaskedTextBox;
    }
}

