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
    public partial class deleteTemplateForm : Form {
        public deleteTemplateForm() {
            InitializeComponent();
        }
        void RefreshFolderList() {
            lstTemplates.Items.Clear();
            string templatePath = Path.Combine(Application.StartupPath, MenuForm.templateFolderName);
            if (Directory.Exists(templatePath)) {
                string[] folders = Directory.GetDirectories(templatePath);
                foreach (var folder in folders) {
                    lstTemplates.Items.Add(Path.GetFileName(folder));
                }
            }
        }

        private void DeleteTemplateForm_Load(object sender, EventArgs e) {
            RefreshFolderList();
        }

        private void BtnDelete_Click(object sender, EventArgs e) {
            if (lstTemplates.SelectedItem != null) {
                string targetTemplate = lstTemplates.SelectedItem.ToString();
                DialogResult d = MessageBox.Show("Are you sure you want to delete " + targetTemplate + "?", "Delete Template", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (d == DialogResult.Yes) {
                    try {
                        Directory.Delete(Path.Combine(Application.StartupPath, MenuForm.templateFolderName, targetTemplate), true);
                    } catch (Exception) {
                        MessageBox.Show("Unable to delete " + targetTemplate + "!", "Couldn't Delete Template", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    RefreshFolderList();
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e) {
            Close();
        }

        private void LstTemplates_SelectedIndexChanged(object sender, EventArgs e) {
            btnDelete.Enabled = lstTemplates.SelectedItem != null;
        }
    }
}
