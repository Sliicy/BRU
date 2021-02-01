using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STAAC {
    public partial class newTemplateForm : Form {
        public newTemplateForm() {
            InitializeComponent();
        }

        private void BtnCreate_Click(object sender, EventArgs e) {
            if (Directory.Exists(Path.Combine(Application.StartupPath, MenuForm.templateFolderName, txtName.Text))) {
                MessageBox.Show("A template with the name \"" + txtName.Text + "\" already exists! Please choose a different name.", "Template Name Conflict", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                if (!(txtName.Text.All(c => char.IsLetterOrDigit(c) || c == '_' || c == ' ' || c == '.' || c == '-' || c == '!'))) {
                    MessageBox.Show("Name cannot contain any special symbols.", "No Special Characters", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else {
                    Directory.CreateDirectory(Path.Combine(Application.StartupPath, MenuForm.templateFolderName, txtName.Text));
                    string commas = "";
                    for (int i = 0; i < int.Parse(txtWidth.Text) * int.Parse(txtHeight.Text); i++) {
                        commas += ",";
                    }
                    File.WriteAllText(Path.Combine(Application.StartupPath, MenuForm.templateFolderName, txtName.Text, MenuForm.settingsFileName),
                        "Author=" + txtAuthor.Text + Environment.NewLine +
                        "Category=" + txtCategory.Text + Environment.NewLine +
                        "Last Accessed=" + DateTime.Now + Environment.NewLine +
                        "Matrix Size=" + txtWidth.Text + "x" + txtHeight.Text + Environment.NewLine +
                        "Color Scheme=" + cbColorScheme.Text + Environment.NewLine +
                        "Matrix Data=" + commas);
                    Close();
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e) {
            Close();
        }

        private void NewTemplateForm_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Escape) {
                Close();
            }
        }

        private void NewTemplateForm_Load(object sender, EventArgs e) {
            cbColorScheme.SelectedIndex = 0;
        }
    }
}
