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
    public partial class newNameForm : Form {
        public newNameForm() {
            InitializeComponent();
        }

        string originalName = "";
        public string newName = "";
        public bool saveChanges = false;

        public newNameForm(string oldName) {
            InitializeComponent();
            originalName = oldName;
        }

            private void newNameForm_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Escape) {
                Close();
            }
        }

        private void newNameForm_Load(object sender, EventArgs e) {
            txtName.Text = originalName;
            txtName.SelectAll();
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                btnOK.PerformClick();
            }
        }

        private void btnOK_Click(object sender, EventArgs e) {
            newName = txtName.Text;
            saveChanges = true;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            Close();
        }

        private void newNameForm_FormClosing(object sender, FormClosingEventArgs e) {
            newName = txtName.Text;
        }
    }
}
