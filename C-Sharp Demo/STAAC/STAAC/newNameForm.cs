using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STAAC {
    public partial class NewNameForm : Form {
        public NewNameForm() {
            InitializeComponent();
        }

        string originalName = "";
        public string newName = "";
        public bool saveChanges = false;

        public NewNameForm(string oldName) {
            InitializeComponent();
            originalName = oldName;
        }

            private void NewNameForm_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Escape) {
                Close();
            }
        }

        private void NewNameForm_Load(object sender, EventArgs e) {
            txtName.Text = originalName;
            txtName.SelectAll();
        }

        private void TxtName_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                btnOK.PerformClick();
            }
        }

        private void BtnOK_Click(object sender, EventArgs e) {
            newName = txtName.Text;
            saveChanges = true;
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e) {
            Close();
        }

        private void NewNameForm_FormClosing(object sender, FormClosingEventArgs e) {
            newName = txtName.Text;
        }

        private void TxtName_TextChanged(object sender, EventArgs e) {
            btnOK.Enabled = txtName.TextLength > 0;
        }
    }
}
