
namespace STAAC {
    partial class newTemplateForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(newTemplateForm));
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblWidth = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.lblColorScheme = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.tblMain = new System.Windows.Forms.TableLayoutPanel();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.cbColorScheme = new System.Windows.Forms.ComboBox();
            this.tblMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAuthor
            // 
            this.lblAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(214, 44);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(75, 25);
            this.lblAuthor.TabIndex = 3;
            this.lblAuthor.Text = "&Author";
            // 
            // lblCategory
            // 
            this.lblCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(190, 88);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(99, 25);
            this.lblCategory.TabIndex = 5;
            this.lblCategory.Text = "Ca&tegory";
            // 
            // lblWidth
            // 
            this.lblWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(222, 132);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(67, 25);
            this.lblWidth.TabIndex = 7;
            this.lblWidth.Text = "&Width";
            // 
            // lblHeight
            // 
            this.lblHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(215, 176);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(74, 25);
            this.lblHeight.TabIndex = 9;
            this.lblHeight.Text = "&Height";
            // 
            // lblColorScheme
            // 
            this.lblColorScheme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblColorScheme.AutoSize = true;
            this.lblColorScheme.Location = new System.Drawing.Point(142, 220);
            this.lblColorScheme.Name = "lblColorScheme";
            this.lblColorScheme.Size = new System.Drawing.Size(147, 25);
            this.lblColorScheme.TabIndex = 11;
            this.lblColorScheme.Text = "Color &Scheme";
            // 
            // btnCreate
            // 
            this.btnCreate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCreate.Location = new System.Drawing.Point(3, 267);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(286, 41);
            this.btnCreate.TabIndex = 13;
            this.btnCreate.Text = "&Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.BtnCreate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.Location = new System.Drawing.Point(295, 267);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(286, 41);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "C&ancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // lblName
            // 
            this.lblName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(221, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(68, 25);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "&Name";
            // 
            // txtName
            // 
            this.txtName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtName.Location = new System.Drawing.Point(295, 3);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(286, 31);
            this.txtName.TabIndex = 2;
            // 
            // tblMain
            // 
            this.tblMain.ColumnCount = 2;
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblMain.Controls.Add(this.btnCancel, 1, 6);
            this.tblMain.Controls.Add(this.txtName, 1, 0);
            this.tblMain.Controls.Add(this.btnCreate, 0, 6);
            this.tblMain.Controls.Add(this.lblName, 0, 0);
            this.tblMain.Controls.Add(this.lblCategory, 0, 2);
            this.tblMain.Controls.Add(this.lblAuthor, 0, 1);
            this.tblMain.Controls.Add(this.lblWidth, 0, 3);
            this.tblMain.Controls.Add(this.lblHeight, 0, 4);
            this.tblMain.Controls.Add(this.lblColorScheme, 0, 5);
            this.tblMain.Controls.Add(this.txtAuthor, 1, 1);
            this.tblMain.Controls.Add(this.txtCategory, 1, 2);
            this.tblMain.Controls.Add(this.txtWidth, 1, 3);
            this.tblMain.Controls.Add(this.txtHeight, 1, 4);
            this.tblMain.Controls.Add(this.cbColorScheme, 1, 5);
            this.tblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMain.Location = new System.Drawing.Point(0, 0);
            this.tblMain.Name = "tblMain";
            this.tblMain.RowCount = 7;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tblMain.Size = new System.Drawing.Size(584, 311);
            this.tblMain.TabIndex = 0;
            // 
            // txtAuthor
            // 
            this.txtAuthor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAuthor.Location = new System.Drawing.Point(295, 47);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(286, 31);
            this.txtAuthor.TabIndex = 4;
            // 
            // txtCategory
            // 
            this.txtCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCategory.Location = new System.Drawing.Point(295, 91);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(286, 31);
            this.txtCategory.TabIndex = 6;
            // 
            // txtWidth
            // 
            this.txtWidth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtWidth.Location = new System.Drawing.Point(295, 135);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(286, 31);
            this.txtWidth.TabIndex = 8;
            // 
            // txtHeight
            // 
            this.txtHeight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHeight.Location = new System.Drawing.Point(295, 179);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(286, 31);
            this.txtHeight.TabIndex = 10;
            // 
            // cbColorScheme
            // 
            this.cbColorScheme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbColorScheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColorScheme.FormattingEnabled = true;
            this.cbColorScheme.Items.AddRange(new object[] {
            "None",
            "Rainbow",
            "Pink",
            "Brown",
            "Red",
            "Orange",
            "Yellow",
            "Green",
            "Blue",
            "Purple",
            "White"});
            this.cbColorScheme.Location = new System.Drawing.Point(295, 223);
            this.cbColorScheme.Name = "cbColorScheme";
            this.cbColorScheme.Size = new System.Drawing.Size(286, 33);
            this.cbColorScheme.TabIndex = 15;
            // 
            // newTemplateForm
            // 
            this.AcceptButton = this.btnCreate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(584, 311);
            this.Controls.Add(this.tblMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "newTemplateForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Template";
            this.Load += new System.EventHandler(this.NewTemplateForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NewTemplateForm_KeyDown);
            this.tblMain.ResumeLayout(false);
            this.tblMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Label lblColorScheme;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TableLayoutPanel tblMain;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.ComboBox cbColorScheme;
    }
}