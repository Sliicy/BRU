
namespace STAAC {
    partial class TemplateForm {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TemplateForm));
            this.btnHelp = new System.Windows.Forms.Button();
            this.coolDown = new System.Windows.Forms.Timer(this.components);
            this.btnOnScreenKeyboard = new System.Windows.Forms.Button();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.Location = new System.Drawing.Point(447, 0);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(6);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(150, 44);
            this.btnHelp.TabIndex = 5;
            this.btnHelp.Text = "&Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.BtnHelp_Click);
            // 
            // coolDown
            // 
            this.coolDown.Interval = 5000;
            this.coolDown.Tick += new System.EventHandler(this.CoolDown_Tick);
            // 
            // btnOnScreenKeyboard
            // 
            this.btnOnScreenKeyboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOnScreenKeyboard.Location = new System.Drawing.Point(149, 0);
            this.btnOnScreenKeyboard.Name = "btnOnScreenKeyboard";
            this.btnOnScreenKeyboard.Size = new System.Drawing.Size(150, 44);
            this.btnOnScreenKeyboard.TabIndex = 3;
            this.btnOnScreenKeyboard.Text = "&Keyboard";
            this.btnOnScreenKeyboard.UseVisualStyleBackColor = true;
            this.btnOnScreenKeyboard.Click += new System.EventHandler(this.BtnOnScreenKeyboard_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnBack);
            this.pnlBottom.Controls.Add(this.btnEdit);
            this.pnlBottom.Controls.Add(this.btnOnScreenKeyboard);
            this.pnlBottom.Controls.Add(this.btnHelp);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 626);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(798, 44);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(0, 0);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(150, 44);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "&Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(298, 0);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(6);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(150, 44);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "&Edit Buttons";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlButtons.Location = new System.Drawing.Point(0, 0);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(798, 626);
            this.pnlButtons.TabIndex = 0;
            this.pnlButtons.Resize += new System.EventHandler(this.PnlButtons_Resize);
            // 
            // TemplateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 670);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "TemplateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "STAAC";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Timer coolDown;
        private System.Windows.Forms.Button btnOnScreenKeyboard;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnBack;
    }
}

