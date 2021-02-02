
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
            this.btnBack = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.tlpDock = new System.Windows.Forms.TableLayoutPanel();
            this.btnRepeat = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnOn = new System.Windows.Forms.Button();
            this.btnYes = new System.Windows.Forms.Button();
            this.btnOff = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.btnGood = new System.Windows.Forms.Button();
            this.btnMaybe = new System.Windows.Forms.Button();
            this.btnNot = new System.Windows.Forms.Button();
            this.btnGo = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnHot = new System.Windows.Forms.Button();
            this.btnCold = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnBetter = new System.Windows.Forms.Button();
            this.btnPain = new System.Windows.Forms.Button();
            this.btnBad = new System.Windows.Forms.Button();
            this.tlpTopBar = new System.Windows.Forms.TableLayoutPanel();
            this.txtSpeechBar = new System.Windows.Forms.TextBox();
            this.btnSpeak = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.tlpDock.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tlpTopBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnHelp
            // 
            this.btnHelp.BackColor = System.Drawing.Color.Red;
            this.btnHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHelp.ForeColor = System.Drawing.Color.White;
            this.btnHelp.Location = new System.Drawing.Point(639, 3);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(156, 38);
            this.btnHelp.TabIndex = 29;
            this.btnHelp.Text = "&Help";
            this.btnHelp.UseVisualStyleBackColor = false;
            this.btnHelp.Click += new System.EventHandler(this.BtnHelp_Click);
            // 
            // coolDown
            // 
            this.coolDown.Interval = 5000;
            this.coolDown.Tick += new System.EventHandler(this.CoolDown_Tick);
            // 
            // btnOnScreenKeyboard
            // 
            this.btnOnScreenKeyboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOnScreenKeyboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOnScreenKeyboard.Location = new System.Drawing.Point(162, 3);
            this.btnOnScreenKeyboard.Name = "btnOnScreenKeyboard";
            this.btnOnScreenKeyboard.Size = new System.Drawing.Size(153, 38);
            this.btnOnScreenKeyboard.TabIndex = 26;
            this.btnOnScreenKeyboard.Text = "&Keyboard ⌨";
            this.btnOnScreenKeyboard.UseVisualStyleBackColor = true;
            this.btnOnScreenKeyboard.Click += new System.EventHandler(this.BtnOnScreenKeyboard_Click);
            // 
            // btnBack
            // 
            this.btnBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(3, 3);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(153, 38);
            this.btnBack.TabIndex = 25;
            this.btnBack.Text = "&Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEdit.Location = new System.Drawing.Point(321, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(153, 38);
            this.btnEdit.TabIndex = 27;
            this.btnEdit.Text = "&Edit Buttons";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlButtons.Location = new System.Drawing.Point(0, 44);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(598, 582);
            this.pnlButtons.TabIndex = 4;
            this.pnlButtons.Resize += new System.EventHandler(this.PnlButtons_Resize);
            // 
            // tlpDock
            // 
            this.tlpDock.ColumnCount = 5;
            this.tlpDock.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpDock.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpDock.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpDock.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpDock.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpDock.Controls.Add(this.btnBack, 0, 0);
            this.tlpDock.Controls.Add(this.btnEdit, 2, 0);
            this.tlpDock.Controls.Add(this.btnOnScreenKeyboard, 1, 0);
            this.tlpDock.Controls.Add(this.btnHelp, 4, 0);
            this.tlpDock.Controls.Add(this.btnRepeat, 3, 0);
            this.tlpDock.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlpDock.Location = new System.Drawing.Point(0, 626);
            this.tlpDock.Name = "tlpDock";
            this.tlpDock.RowCount = 1;
            this.tlpDock.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDock.Size = new System.Drawing.Size(798, 44);
            this.tlpDock.TabIndex = 24;
            // 
            // btnRepeat
            // 
            this.btnRepeat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRepeat.Location = new System.Drawing.Point(480, 3);
            this.btnRepeat.Name = "btnRepeat";
            this.btnRepeat.Size = new System.Drawing.Size(153, 38);
            this.btnRepeat.TabIndex = 28;
            this.btnRepeat.Text = "&Repeat ⭮";
            this.btnRepeat.UseVisualStyleBackColor = true;
            this.btnRepeat.Click += new System.EventHandler(this.BtnRepeat_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnOn, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnYes, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnOff, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnNo, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnGood, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnMaybe, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnNot, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnGo, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnStop, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnHot, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnCold, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnUp, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.btnDown, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.btnLeft, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.btnRight, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.btnBetter, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.btnPain, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.btnBad, 1, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(598, 44);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 582);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // btnOn
            // 
            this.btnOn.BackColor = System.Drawing.Color.White;
            this.btnOn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOn.Location = new System.Drawing.Point(3, 259);
            this.btnOn.Name = "btnOn";
            this.btnOn.Size = new System.Drawing.Size(94, 58);
            this.btnOn.TabIndex = 14;
            this.btnOn.Text = "On";
            this.btnOn.UseVisualStyleBackColor = false;
            this.btnOn.Click += new System.EventHandler(this.BtnHelp_Click);
            // 
            // btnYes
            // 
            this.btnYes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnYes.Location = new System.Drawing.Point(3, 3);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(94, 58);
            this.btnYes.TabIndex = 6;
            this.btnYes.Text = "&Yes";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.BtnHelp_Click);
            // 
            // btnOff
            // 
            this.btnOff.BackColor = System.Drawing.Color.Black;
            this.btnOff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOff.ForeColor = System.Drawing.Color.White;
            this.btnOff.Location = new System.Drawing.Point(103, 259);
            this.btnOff.Name = "btnOff";
            this.btnOff.Size = new System.Drawing.Size(94, 58);
            this.btnOff.TabIndex = 15;
            this.btnOff.Text = "Off";
            this.btnOff.UseVisualStyleBackColor = false;
            this.btnOff.Click += new System.EventHandler(this.BtnHelp_Click);
            // 
            // btnNo
            // 
            this.btnNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNo.Location = new System.Drawing.Point(103, 3);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(94, 58);
            this.btnNo.TabIndex = 7;
            this.btnNo.Text = "&No";
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnNo.Click += new System.EventHandler(this.BtnHelp_Click);
            // 
            // btnGood
            // 
            this.btnGood.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGood.Location = new System.Drawing.Point(3, 323);
            this.btnGood.Name = "btnGood";
            this.btnGood.Size = new System.Drawing.Size(94, 58);
            this.btnGood.TabIndex = 16;
            this.btnGood.Text = "Good";
            this.btnGood.UseVisualStyleBackColor = true;
            this.btnGood.Click += new System.EventHandler(this.BtnHelp_Click);
            // 
            // btnMaybe
            // 
            this.btnMaybe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMaybe.Location = new System.Drawing.Point(3, 67);
            this.btnMaybe.Name = "btnMaybe";
            this.btnMaybe.Size = new System.Drawing.Size(94, 58);
            this.btnMaybe.TabIndex = 8;
            this.btnMaybe.Text = "Maybe";
            this.btnMaybe.UseVisualStyleBackColor = true;
            this.btnMaybe.Click += new System.EventHandler(this.BtnHelp_Click);
            // 
            // btnNot
            // 
            this.btnNot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNot.Location = new System.Drawing.Point(103, 67);
            this.btnNot.Name = "btnNot";
            this.btnNot.Size = new System.Drawing.Size(94, 58);
            this.btnNot.TabIndex = 9;
            this.btnNot.Text = "Not";
            this.btnNot.UseVisualStyleBackColor = true;
            this.btnNot.Click += new System.EventHandler(this.BtnHelp_Click);
            // 
            // btnGo
            // 
            this.btnGo.BackColor = System.Drawing.Color.SpringGreen;
            this.btnGo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGo.Location = new System.Drawing.Point(3, 131);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(94, 58);
            this.btnGo.TabIndex = 10;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = false;
            this.btnGo.Click += new System.EventHandler(this.BtnHelp_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Red;
            this.btnStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStop.ForeColor = System.Drawing.Color.White;
            this.btnStop.Location = new System.Drawing.Point(103, 131);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(94, 58);
            this.btnStop.TabIndex = 11;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.BtnHelp_Click);
            // 
            // btnHot
            // 
            this.btnHot.BackColor = System.Drawing.Color.LightSalmon;
            this.btnHot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHot.Location = new System.Drawing.Point(3, 195);
            this.btnHot.Name = "btnHot";
            this.btnHot.Size = new System.Drawing.Size(94, 58);
            this.btnHot.TabIndex = 12;
            this.btnHot.Text = "Hot";
            this.btnHot.UseVisualStyleBackColor = false;
            this.btnHot.Click += new System.EventHandler(this.BtnHelp_Click);
            // 
            // btnCold
            // 
            this.btnCold.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnCold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCold.Location = new System.Drawing.Point(103, 195);
            this.btnCold.Name = "btnCold";
            this.btnCold.Size = new System.Drawing.Size(94, 58);
            this.btnCold.TabIndex = 13;
            this.btnCold.Text = "Cold";
            this.btnCold.UseVisualStyleBackColor = false;
            this.btnCold.Click += new System.EventHandler(this.BtnHelp_Click);
            // 
            // btnUp
            // 
            this.btnUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUp.Location = new System.Drawing.Point(3, 387);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(94, 58);
            this.btnUp.TabIndex = 18;
            this.btnUp.Text = "Up";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.BtnHelp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDown.Location = new System.Drawing.Point(103, 387);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(94, 58);
            this.btnDown.TabIndex = 19;
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.BtnHelp_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLeft.Location = new System.Drawing.Point(3, 451);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(94, 58);
            this.btnLeft.TabIndex = 20;
            this.btnLeft.Text = "Left";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.BtnHelp_Click);
            // 
            // btnRight
            // 
            this.btnRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRight.Location = new System.Drawing.Point(103, 451);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(94, 58);
            this.btnRight.TabIndex = 21;
            this.btnRight.Text = "Right";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.BtnHelp_Click);
            // 
            // btnBetter
            // 
            this.btnBetter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBetter.Location = new System.Drawing.Point(3, 515);
            this.btnBetter.Name = "btnBetter";
            this.btnBetter.Size = new System.Drawing.Size(94, 64);
            this.btnBetter.TabIndex = 22;
            this.btnBetter.Text = "Better";
            this.btnBetter.UseVisualStyleBackColor = true;
            this.btnBetter.Click += new System.EventHandler(this.BtnHelp_Click);
            // 
            // btnPain
            // 
            this.btnPain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPain.Location = new System.Drawing.Point(103, 515);
            this.btnPain.Name = "btnPain";
            this.btnPain.Size = new System.Drawing.Size(94, 64);
            this.btnPain.TabIndex = 23;
            this.btnPain.Text = "Pain";
            this.btnPain.UseVisualStyleBackColor = true;
            this.btnPain.Click += new System.EventHandler(this.BtnHelp_Click);
            // 
            // btnBad
            // 
            this.btnBad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBad.Location = new System.Drawing.Point(103, 323);
            this.btnBad.Name = "btnBad";
            this.btnBad.Size = new System.Drawing.Size(94, 58);
            this.btnBad.TabIndex = 17;
            this.btnBad.Text = "Bad";
            this.btnBad.UseVisualStyleBackColor = true;
            this.btnBad.Click += new System.EventHandler(this.BtnHelp_Click);
            // 
            // tlpTopBar
            // 
            this.tlpTopBar.ColumnCount = 3;
            this.tlpTopBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTopBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpTopBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpTopBar.Controls.Add(this.txtSpeechBar, 0, 0);
            this.tlpTopBar.Controls.Add(this.btnSpeak, 1, 0);
            this.tlpTopBar.Controls.Add(this.btnClear, 2, 0);
            this.tlpTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpTopBar.Location = new System.Drawing.Point(0, 0);
            this.tlpTopBar.Name = "tlpTopBar";
            this.tlpTopBar.RowCount = 1;
            this.tlpTopBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTopBar.Size = new System.Drawing.Size(798, 44);
            this.tlpTopBar.TabIndex = 0;
            // 
            // txtSpeechBar
            // 
            this.txtSpeechBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSpeechBar.Location = new System.Drawing.Point(3, 3);
            this.txtSpeechBar.Multiline = true;
            this.txtSpeechBar.Name = "txtSpeechBar";
            this.txtSpeechBar.Size = new System.Drawing.Size(592, 38);
            this.txtSpeechBar.TabIndex = 1;
            this.txtSpeechBar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSpeechBar_KeyDown);
            // 
            // btnSpeak
            // 
            this.btnSpeak.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSpeak.Location = new System.Drawing.Point(601, 3);
            this.btnSpeak.Name = "btnSpeak";
            this.btnSpeak.Size = new System.Drawing.Size(94, 38);
            this.btnSpeak.TabIndex = 2;
            this.btnSpeak.Text = "&Speak";
            this.btnSpeak.UseVisualStyleBackColor = true;
            this.btnSpeak.Click += new System.EventHandler(this.BtnSpeak_Click);
            // 
            // btnClear
            // 
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClear.Location = new System.Drawing.Point(701, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(94, 38);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "&Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // TemplateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 670);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tlpTopBar);
            this.Controls.Add(this.tlpDock);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "TemplateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "STAAC";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tlpDock.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tlpTopBar.ResumeLayout(false);
            this.tlpTopBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Timer coolDown;
        private System.Windows.Forms.Button btnOnScreenKeyboard;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TableLayoutPanel tlpDock;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.Button btnMaybe;
        private System.Windows.Forms.Button btnNot;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnHot;
        private System.Windows.Forms.Button btnCold;
        private System.Windows.Forms.Button btnGood;
        private System.Windows.Forms.Button btnBad;
        private System.Windows.Forms.TableLayoutPanel tlpTopBar;
        private System.Windows.Forms.TextBox txtSpeechBar;
        private System.Windows.Forms.Button btnSpeak;
        private System.Windows.Forms.Button btnRepeat;
        private System.Windows.Forms.Button btnOn;
        private System.Windows.Forms.Button btnOff;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnBetter;
        private System.Windows.Forms.Button btnPain;
        private System.Windows.Forms.Button btnClear;
    }
}

