namespace PortalMySQLC969
{
    partial class MainForm
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
            this.mainDGV = new System.Windows.Forms.DataGridView();
            this.box3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.box2 = new System.Windows.Forms.TextBox();
            this.newBtn = new System.Windows.Forms.Button();
            this.editBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.box1 = new System.Windows.Forms.TextBox();
            this.tableLabel = new System.Windows.Forms.Label();
            this.tableSelectionCBox = new System.Windows.Forms.ComboBox();
            this.descriptionBox = new System.Windows.Forms.RichTextBox();
            this.timezoneLabel = new System.Windows.Forms.Label();
            this.timezoneIsPDTPSTUserLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.box4 = new System.Windows.Forms.TextBox();
            this.filtersPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.idCBox = new System.Windows.Forms.CheckBox();
            this.mrchntTextBox = new System.Windows.Forms.TextBox();
            this.idUpDown = new System.Windows.Forms.NumericUpDown();
            this.mrchntCBox = new System.Windows.Forms.CheckBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.nameCBox = new System.Windows.Forms.CheckBox();
            this.filterButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mainDGV)).BeginInit();
            this.filtersPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.idUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // mainDGV
            // 
            this.mainDGV.AllowUserToAddRows = false;
            this.mainDGV.AllowUserToDeleteRows = false;
            this.mainDGV.AllowUserToResizeColumns = false;
            this.mainDGV.AllowUserToResizeRows = false;
            this.mainDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.mainDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainDGV.Location = new System.Drawing.Point(16, 40);
            this.mainDGV.Name = "mainDGV";
            this.mainDGV.ReadOnly = true;
            this.mainDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.mainDGV.Size = new System.Drawing.Size(492, 421);
            this.mainDGV.TabIndex = 0;
            this.mainDGV.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.MainDGV_CellEnter);
            this.mainDGV.MouseEnter += new System.EventHandler(this.sendFiltersToBack);
            // 
            // box3
            // 
            this.box3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.box3.Enabled = false;
            this.box3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.box3.Location = new System.Drawing.Point(648, 190);
            this.box3.Name = "box3";
            this.box3.Size = new System.Drawing.Size(135, 29);
            this.box3.TabIndex = 3;
            this.box3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.Location = new System.Drawing.Point(661, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 21);
            this.label3.TabIndex = 7;
            this.label3.Text = "Manufacturer:";
            // 
            // saveButton
            // 
            this.saveButton.Enabled = false;
            this.saveButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.saveButton.Location = new System.Drawing.Point(383, 467);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(101, 30);
            this.saveButton.TabIndex = 9;
            this.saveButton.Text = "Save";
            this.saveButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.Location = new System.Drawing.Point(671, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 21);
            this.label2.TabIndex = 12;
            this.label2.Text = "Product ID:";
            // 
            // box2
            // 
            this.box2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.box2.Enabled = false;
            this.box2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.box2.Location = new System.Drawing.Point(682, 123);
            this.box2.Name = "box2";
            this.box2.Size = new System.Drawing.Size(61, 29);
            this.box2.TabIndex = 11;
            this.box2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // newBtn
            // 
            this.newBtn.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.newBtn.Location = new System.Drawing.Point(26, 467);
            this.newBtn.Name = "newBtn";
            this.newBtn.Size = new System.Drawing.Size(101, 30);
            this.newBtn.TabIndex = 13;
            this.newBtn.Text = "New";
            this.newBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.newBtn.UseVisualStyleBackColor = true;
            this.newBtn.Click += new System.EventHandler(this.NewBtn_Click);
            // 
            // editBtn
            // 
            this.editBtn.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.editBtn.Location = new System.Drawing.Point(264, 467);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(101, 30);
            this.editBtn.TabIndex = 14;
            this.editBtn.Text = "Edit";
            this.editBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.deleteBtn.Location = new System.Drawing.Point(145, 467);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(101, 30);
            this.deleteBtn.TabIndex = 15;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.Location = new System.Drawing.Point(678, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 21);
            this.label1.TabIndex = 20;
            this.label1.Text = "Price:";
            // 
            // box1
            // 
            this.box1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.box1.Enabled = false;
            this.box1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.box1.Location = new System.Drawing.Point(682, 55);
            this.box1.Name = "box1";
            this.box1.Size = new System.Drawing.Size(61, 29);
            this.box1.TabIndex = 19;
            this.box1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tableLabel
            // 
            this.tableLabel.AutoSize = true;
            this.tableLabel.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.tableLabel.Location = new System.Drawing.Point(21, 9);
            this.tableLabel.Name = "tableLabel";
            this.tableLabel.Size = new System.Drawing.Size(61, 28);
            this.tableLabel.TabIndex = 28;
            this.tableLabel.Text = "Table:";
            // 
            // tableSelectionCBox
            // 
            this.tableSelectionCBox.FormattingEnabled = true;
            this.tableSelectionCBox.Items.AddRange(new object[] {
            "Customers",
            "Sales",
            "Products"});
            this.tableSelectionCBox.Location = new System.Drawing.Point(88, 16);
            this.tableSelectionCBox.Name = "tableSelectionCBox";
            this.tableSelectionCBox.Size = new System.Drawing.Size(121, 21);
            this.tableSelectionCBox.TabIndex = 31;
            this.tableSelectionCBox.Text = "SELECT DATA!";
            this.tableSelectionCBox.SelectedIndexChanged += new System.EventHandler(this.tableSelectionCBox_SelectedIndexChanged);
            // 
            // descriptionBox
            // 
            this.descriptionBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.descriptionBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.descriptionBox.Location = new System.Drawing.Point(514, 391);
            this.descriptionBox.MaxLength = 1020;
            this.descriptionBox.Name = "descriptionBox";
            this.descriptionBox.Size = new System.Drawing.Size(355, 134);
            this.descriptionBox.TabIndex = 33;
            this.descriptionBox.Text = "Product Notes";
            this.descriptionBox.Visible = false;
            this.descriptionBox.ZoomFactor = 1.45F;
            // 
            // timezoneLabel
            // 
            this.timezoneLabel.AutoSize = true;
            this.timezoneLabel.Font = new System.Drawing.Font("Segoe UI", 7.75F);
            this.timezoneLabel.Location = new System.Drawing.Point(661, 236);
            this.timezoneLabel.Name = "timezoneLabel";
            this.timezoneLabel.Size = new System.Drawing.Size(85, 13);
            this.timezoneLabel.TabIndex = 51;
            this.timezoneLabel.Text = "Your timezone: ";
            // 
            // timezoneIsPDTPSTUserLabel
            // 
            this.timezoneIsPDTPSTUserLabel.AutoSize = true;
            this.timezoneIsPDTPSTUserLabel.Font = new System.Drawing.Font("Segoe UI", 7.75F);
            this.timezoneIsPDTPSTUserLabel.Location = new System.Drawing.Point(656, 223);
            this.timezoneIsPDTPSTUserLabel.Name = "timezoneIsPDTPSTUserLabel";
            this.timezoneIsPDTPSTUserLabel.Size = new System.Drawing.Size(101, 13);
            this.timezoneIsPDTPSTUserLabel.TabIndex = 50;
            this.timezoneIsPDTPSTUserLabel.Text = "Times originate in ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label4.Location = new System.Drawing.Point(660, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 21);
            this.label4.TabIndex = 53;
            this.label4.Text = "Product Name:";
            // 
            // box4
            // 
            this.box4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.box4.Enabled = false;
            this.box4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.box4.Location = new System.Drawing.Point(622, 260);
            this.box4.Name = "box4";
            this.box4.Size = new System.Drawing.Size(192, 25);
            this.box4.TabIndex = 52;
            this.box4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // filtersPanel
            // 
            this.filtersPanel.BackColor = System.Drawing.SystemColors.Control;
            this.filtersPanel.Controls.Add(this.panel1);
            this.filtersPanel.Controls.Add(this.filterButton);
            this.filtersPanel.Controls.Add(this.label5);
            this.filtersPanel.Location = new System.Drawing.Point(275, 12);
            this.filtersPanel.Name = "filtersPanel";
            this.filtersPanel.Size = new System.Drawing.Size(188, 136);
            this.filtersPanel.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.Controls.Add(this.idCBox);
            this.panel1.Controls.Add(this.mrchntTextBox);
            this.panel1.Controls.Add(this.idUpDown);
            this.panel1.Controls.Add(this.mrchntCBox);
            this.panel1.Controls.Add(this.nameTextBox);
            this.panel1.Controls.Add(this.nameCBox);
            this.panel1.Location = new System.Drawing.Point(3, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(180, 74);
            this.panel1.TabIndex = 65;
            // 
            // idCBox
            // 
            this.idCBox.AutoSize = true;
            this.idCBox.Location = new System.Drawing.Point(3, 9);
            this.idCBox.Name = "idCBox";
            this.idCBox.Size = new System.Drawing.Size(37, 17);
            this.idCBox.TabIndex = 60;
            this.idCBox.Text = "ID";
            this.idCBox.UseVisualStyleBackColor = true;
            this.idCBox.CheckedChanged += new System.EventHandler(this.panelCheckBoxesHandler);
            // 
            // mrchntTextBox
            // 
            this.mrchntTextBox.Enabled = false;
            this.mrchntTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F);
            this.mrchntTextBox.Location = new System.Drawing.Point(62, 51);
            this.mrchntTextBox.Name = "mrchntTextBox";
            this.mrchntTextBox.Size = new System.Drawing.Size(115, 18);
            this.mrchntTextBox.TabIndex = 64;
            this.mrchntTextBox.TextChanged += new System.EventHandler(this.panelCheckBoxesHandler);
            // 
            // idUpDown
            // 
            this.idUpDown.Enabled = false;
            this.idUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F);
            this.idUpDown.Location = new System.Drawing.Point(62, 9);
            this.idUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.idUpDown.Name = "idUpDown";
            this.idUpDown.Size = new System.Drawing.Size(115, 18);
            this.idUpDown.TabIndex = 58;
            this.idUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.idUpDown.ValueChanged += new System.EventHandler(this.panelCheckBoxesHandler);
            // 
            // mrchntCBox
            // 
            this.mrchntCBox.AutoSize = true;
            this.mrchntCBox.Location = new System.Drawing.Point(3, 53);
            this.mrchntCBox.Name = "mrchntCBox";
            this.mrchntCBox.Size = new System.Drawing.Size(56, 17);
            this.mrchntCBox.TabIndex = 62;
            this.mrchntCBox.Text = "Mnfctr";
            this.mrchntCBox.UseVisualStyleBackColor = true;
            this.mrchntCBox.CheckedChanged += new System.EventHandler(this.panelCheckBoxesHandler);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Enabled = false;
            this.nameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F);
            this.nameTextBox.Location = new System.Drawing.Point(69, 30);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(108, 18);
            this.nameTextBox.TabIndex = 59;
            this.nameTextBox.TextChanged += new System.EventHandler(this.panelCheckBoxesHandler);
            // 
            // nameCBox
            // 
            this.nameCBox.AutoSize = true;
            this.nameCBox.Location = new System.Drawing.Point(3, 32);
            this.nameCBox.Name = "nameCBox";
            this.nameCBox.Size = new System.Drawing.Size(54, 17);
            this.nameCBox.TabIndex = 61;
            this.nameCBox.Text = "Name";
            this.nameCBox.UseVisualStyleBackColor = true;
            this.nameCBox.CheckedChanged += new System.EventHandler(this.panelCheckBoxesHandler);
            // 
            // filterButton
            // 
            this.filterButton.Location = new System.Drawing.Point(3, 2);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(182, 23);
            this.filterButton.TabIndex = 55;
            this.filterButton.Text = "Search Filters";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filtersToFront);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 13);
            this.label5.TabIndex = 56;
            this.label5.Text = "Select Filters to apply";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 537);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.box4);
            this.Controls.Add(this.timezoneLabel);
            this.Controls.Add(this.timezoneIsPDTPSTUserLabel);
            this.Controls.Add(this.descriptionBox);
            this.Controls.Add(this.tableSelectionCBox);
            this.Controls.Add(this.tableLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.box1);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.newBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.box2);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.box3);
            this.Controls.Add(this.mainDGV);
            this.Controls.Add(this.filtersPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "MySQL Communicator";
            this.MouseEnter += new System.EventHandler(this.sendFiltersToBack);
            ((System.ComponentModel.ISupportInitialize)(this.mainDGV)).EndInit();
            this.filtersPanel.ResumeLayout(false);
            this.filtersPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.idUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView mainDGV;
        private System.Windows.Forms.TextBox box3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox box2;
        private System.Windows.Forms.Button newBtn;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox box1;
        private System.Windows.Forms.Label tableLabel;
        private System.Windows.Forms.ComboBox tableSelectionCBox;
        private System.Windows.Forms.RichTextBox descriptionBox;
        private System.Windows.Forms.Label timezoneLabel;
        private System.Windows.Forms.Label timezoneIsPDTPSTUserLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox box4;
        private System.Windows.Forms.Panel filtersPanel;
        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown idUpDown;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.CheckBox idCBox;
        private System.Windows.Forms.CheckBox nameCBox;
        private System.Windows.Forms.CheckBox mrchntCBox;
        private System.Windows.Forms.TextBox mrchntTextBox;
        private System.Windows.Forms.Panel panel1;
    }
}