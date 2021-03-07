
namespace STAAC {
    partial class EditButtonForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditButtonForm));
            this.txtName = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClearImage = new System.Windows.Forms.Button();
            this.btnImageSet = new System.Windows.Forms.Button();
            this.btnAssignWordlist = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtName.Location = new System.Drawing.Point(0, 0);
            this.txtName.Margin = new System.Windows.Forms.Padding(6);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(884, 47);
            this.txtName.TabIndex = 0;
            this.txtName.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.TxtName_HelpRequested);
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtName_KeyDown);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btnOK, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnClearImage, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnImageSet, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAssignWordlist, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 47);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(884, 49);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOK.Location = new System.Drawing.Point(3, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(170, 43);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.Location = new System.Drawing.Point(707, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(174, 43);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            this.btnCancel.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.BtnCancel_HelpRequested);
            // 
            // btnClearImage
            // 
            this.btnClearImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClearImage.Location = new System.Drawing.Point(531, 3);
            this.btnClearImage.Name = "btnClearImage";
            this.btnClearImage.Size = new System.Drawing.Size(170, 43);
            this.btnClearImage.TabIndex = 5;
            this.btnClearImage.Text = "C&lear Image";
            this.btnClearImage.UseVisualStyleBackColor = true;
            this.btnClearImage.Click += new System.EventHandler(this.BtnClearImage_Click);
            this.btnClearImage.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.BtnClearImage_HelpRequested);
            // 
            // btnImageSet
            // 
            this.btnImageSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnImageSet.Location = new System.Drawing.Point(355, 3);
            this.btnImageSet.Name = "btnImageSet";
            this.btnImageSet.Size = new System.Drawing.Size(170, 43);
            this.btnImageSet.TabIndex = 4;
            this.btnImageSet.Text = "Set &Image";
            this.btnImageSet.UseVisualStyleBackColor = true;
            this.btnImageSet.Click += new System.EventHandler(this.BtnImageSet_Click);
            this.btnImageSet.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.BtnImageSet_HelpRequested);
            // 
            // btnAssignWordlist
            // 
            this.btnAssignWordlist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAssignWordlist.Location = new System.Drawing.Point(179, 3);
            this.btnAssignWordlist.Name = "btnAssignWordlist";
            this.btnAssignWordlist.Size = new System.Drawing.Size(170, 43);
            this.btnAssignWordlist.TabIndex = 3;
            this.btnAssignWordlist.Text = "&Add Wordlist";
            this.btnAssignWordlist.UseVisualStyleBackColor = true;
            this.btnAssignWordlist.Click += new System.EventHandler(this.BtnAssignWordlist_Click);
            this.btnAssignWordlist.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.BtnAssignWordlist_HelpRequested);
            // 
            // EditButtonForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(884, 96);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(900, 135);
            this.Name = "EditButtonForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Enter Button Name";
            this.Load += new System.EventHandler(this.NewNameForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NewNameForm_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnImageSet;
        private System.Windows.Forms.Button btnClearImage;
        private System.Windows.Forms.Button btnAssignWordlist;
    }
}