
namespace STAAC {
    partial class templateForm {
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
            this.btnHelp = new System.Windows.Forms.Button();
            this.coolDown = new System.Windows.Forms.Timer(this.components);
            this.btnOnScreenKeyboard = new System.Windows.Forms.Button();
            this.tlpButtons = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(793, 140);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(6);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(176, 44);
            this.btnHelp.TabIndex = 0;
            this.btnHelp.Text = "Help";
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
            this.btnOnScreenKeyboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOnScreenKeyboard.Location = new System.Drawing.Point(793, 15);
            this.btnOnScreenKeyboard.Name = "btnOnScreenKeyboard";
            this.btnOnScreenKeyboard.Size = new System.Drawing.Size(176, 116);
            this.btnOnScreenKeyboard.TabIndex = 1;
            this.btnOnScreenKeyboard.Text = "⌨️";
            this.btnOnScreenKeyboard.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOnScreenKeyboard.UseVisualStyleBackColor = true;
            this.btnOnScreenKeyboard.Click += new System.EventHandler(this.BtnOnScreenKeyboard_Click);
            // 
            // tlpButtons
            // 
            this.tlpButtons.ColumnCount = 1;
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpButtons.Location = new System.Drawing.Point(12, 15);
            this.tlpButtons.Name = "tlpButtons";
            this.tlpButtons.RowCount = 1;
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpButtons.Size = new System.Drawing.Size(772, 593);
            this.tlpButtons.TabIndex = 2;
            // 
            // templateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.tlpButtons);
            this.Controls.Add(this.btnOnScreenKeyboard);
            this.Controls.Add(this.btnHelp);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "templateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "STAAC";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Timer coolDown;
        private System.Windows.Forms.Button btnOnScreenKeyboard;
        private System.Windows.Forms.TableLayoutPanel tlpButtons;
    }
}

