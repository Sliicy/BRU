
namespace STAAC {
    partial class PhraseBuildingForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhraseBuildingForm));
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lstWords = new System.Windows.Forms.ListBox();
            this.btnAnd = new System.Windows.Forms.Button();
            this.btnOr = new System.Windows.Forms.Button();
            this.btnNot = new System.Windows.Forms.Button();
            this.btnDone = new System.Windows.Forms.Button();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpBottom = new System.Windows.Forms.TableLayoutPanel();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtPhrase = new System.Windows.Forms.TextBox();
            this.tlpMiddle = new System.Windows.Forms.TableLayoutPanel();
            this.tlpHeader = new System.Windows.Forms.TableLayoutPanel();
            this.btnClearSearch = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tlpMain.SuspendLayout();
            this.tlpBottom.SuspendLayout();
            this.tlpMiddle.SuspendLayout();
            this.tlpHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearch.Location = new System.Drawing.Point(3, 3);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(572, 38);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
            this.txtSearch.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.TxtSearch_HelpRequested);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSearch_KeyDown);
            // 
            // lstWords
            // 
            this.lstWords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstWords.FormattingEnabled = true;
            this.lstWords.ItemHeight = 25;
            this.lstWords.Location = new System.Drawing.Point(3, 53);
            this.lstWords.Name = "lstWords";
            this.lstWords.ScrollAlwaysVisible = true;
            this.lstWords.Size = new System.Drawing.Size(778, 405);
            this.lstWords.Sorted = true;
            this.lstWords.TabIndex = 5;
            this.lstWords.SelectedIndexChanged += new System.EventHandler(this.LstWords_SelectedIndexChanged);
            this.lstWords.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.LstWords_HelpRequested);
            this.lstWords.DoubleClick += new System.EventHandler(this.LstWords_DoubleClick);
            // 
            // btnAnd
            // 
            this.btnAnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAnd.Location = new System.Drawing.Point(3, 3);
            this.btnAnd.Name = "btnAnd";
            this.btnAnd.Size = new System.Drawing.Size(253, 38);
            this.btnAnd.TabIndex = 7;
            this.btnAnd.Text = "&And";
            this.btnAnd.UseVisualStyleBackColor = true;
            this.btnAnd.Click += new System.EventHandler(this.BtnAnd_Click);
            this.btnAnd.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.BtnAnd_HelpRequested);
            // 
            // btnOr
            // 
            this.btnOr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOr.Location = new System.Drawing.Point(262, 3);
            this.btnOr.Name = "btnOr";
            this.btnOr.Size = new System.Drawing.Size(253, 38);
            this.btnOr.TabIndex = 8;
            this.btnOr.Text = "&Or";
            this.btnOr.UseVisualStyleBackColor = true;
            this.btnOr.Click += new System.EventHandler(this.BtnOr_Click);
            this.btnOr.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.BtnAnd_HelpRequested);
            // 
            // btnNot
            // 
            this.btnNot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNot.Location = new System.Drawing.Point(521, 3);
            this.btnNot.Name = "btnNot";
            this.btnNot.Size = new System.Drawing.Size(254, 38);
            this.btnNot.TabIndex = 9;
            this.btnNot.Text = "&Not";
            this.btnNot.UseVisualStyleBackColor = true;
            this.btnNot.Click += new System.EventHandler(this.BtnNot_Click);
            this.btnNot.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.BtnAnd_HelpRequested);
            // 
            // btnDone
            // 
            this.btnDone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDone.Location = new System.Drawing.Point(681, 3);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(94, 38);
            this.btnDone.TabIndex = 13;
            this.btnDone.Text = "&Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.BtnDone_Click);
            this.btnDone.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.BtnDone_HelpRequested);
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.tlpBottom, 0, 3);
            this.tlpMain.Controls.Add(this.tlpMiddle, 0, 2);
            this.tlpMain.Controls.Add(this.tlpHeader, 0, 0);
            this.tlpMain.Controls.Add(this.lstWords, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 4;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpMain.Size = new System.Drawing.Size(784, 561);
            this.tlpMain.TabIndex = 0;
            // 
            // tlpBottom
            // 
            this.tlpBottom.ColumnCount = 3;
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpBottom.Controls.Add(this.btnDone, 2, 0);
            this.tlpBottom.Controls.Add(this.btnClear, 1, 0);
            this.tlpBottom.Controls.Add(this.txtPhrase, 0, 0);
            this.tlpBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBottom.Location = new System.Drawing.Point(3, 514);
            this.tlpBottom.Name = "tlpBottom";
            this.tlpBottom.RowCount = 1;
            this.tlpBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBottom.Size = new System.Drawing.Size(778, 44);
            this.tlpBottom.TabIndex = 10;
            // 
            // btnClear
            // 
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClear.Location = new System.Drawing.Point(581, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(94, 38);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "Clea&r";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            this.btnClear.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.BtnClear_HelpRequested);
            // 
            // txtPhrase
            // 
            this.txtPhrase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPhrase.Location = new System.Drawing.Point(3, 3);
            this.txtPhrase.Multiline = true;
            this.txtPhrase.Name = "txtPhrase";
            this.txtPhrase.Size = new System.Drawing.Size(572, 38);
            this.txtPhrase.TabIndex = 11;
            this.txtPhrase.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.TxtPhrase_HelpRequested);
            this.txtPhrase.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtPhrase_KeyDown);
            // 
            // tlpMiddle
            // 
            this.tlpMiddle.ColumnCount = 3;
            this.tlpMiddle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMiddle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMiddle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpMiddle.Controls.Add(this.btnAnd, 0, 0);
            this.tlpMiddle.Controls.Add(this.btnOr, 1, 0);
            this.tlpMiddle.Controls.Add(this.btnNot, 2, 0);
            this.tlpMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMiddle.Location = new System.Drawing.Point(3, 464);
            this.tlpMiddle.Name = "tlpMiddle";
            this.tlpMiddle.RowCount = 1;
            this.tlpMiddle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMiddle.Size = new System.Drawing.Size(778, 44);
            this.tlpMiddle.TabIndex = 6;
            // 
            // tlpHeader
            // 
            this.tlpHeader.ColumnCount = 3;
            this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpHeader.Controls.Add(this.txtSearch, 0, 0);
            this.tlpHeader.Controls.Add(this.btnClearSearch, 2, 0);
            this.tlpHeader.Controls.Add(this.btnAdd, 1, 0);
            this.tlpHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpHeader.Location = new System.Drawing.Point(3, 3);
            this.tlpHeader.Name = "tlpHeader";
            this.tlpHeader.RowCount = 1;
            this.tlpHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpHeader.Size = new System.Drawing.Size(778, 44);
            this.tlpHeader.TabIndex = 1;
            // 
            // btnClearSearch
            // 
            this.btnClearSearch.Location = new System.Drawing.Point(681, 3);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Size = new System.Drawing.Size(94, 38);
            this.btnClearSearch.TabIndex = 4;
            this.btnClearSearch.Text = "&Clear";
            this.btnClearSearch.UseVisualStyleBackColor = true;
            this.btnClearSearch.Click += new System.EventHandler(this.BtnClearSearch_Click);
            this.btnClearSearch.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.BtnClearSearch_HelpRequested);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(581, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(94, 38);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            this.btnAdd.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.BtnAdd_HelpRequested);
            // 
            // PhraseBuildingForm
            // 
            this.AcceptButton = this.btnDone;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tlpMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PhraseBuildingForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Choose Words";
            this.Load += new System.EventHandler(this.PhraseBuildingForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PhraseBuildingForm_KeyDown);
            this.tlpMain.ResumeLayout(false);
            this.tlpBottom.ResumeLayout(false);
            this.tlpBottom.PerformLayout();
            this.tlpMiddle.ResumeLayout(false);
            this.tlpHeader.ResumeLayout(false);
            this.tlpHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ListBox lstWords;
        private System.Windows.Forms.Button btnAnd;
        private System.Windows.Forms.Button btnOr;
        private System.Windows.Forms.Button btnNot;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TextBox txtPhrase;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClearSearch;
        private System.Windows.Forms.TableLayoutPanel tlpHeader;
        private System.Windows.Forms.TableLayoutPanel tlpBottom;
        private System.Windows.Forms.TableLayoutPanel tlpMiddle;
        private System.Windows.Forms.Button btnAdd;
    }
}