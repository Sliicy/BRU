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

/**
 * Class responsible for deleting templates from the Templates folder.
 */
namespace STAAC {
    public partial class DeleteTemplateForm : Form {
        public DeleteTemplateForm() {
            InitializeComponent();
        }

        // Function used to refresh the list of folders in the Templates folder:
        void RefreshFolderList() {
            lstTemplates.Items.Clear();
            string templatePath = Path.Combine(Application.StartupPath, MenuForm.TEMPLATE_FOLDER_NAME);
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

                // Confirm that the user wants to delete the selected folder:
                string targetTemplate = lstTemplates.SelectedItem.ToString();
                DialogResult d = MessageBox.Show("Are you sure you want to delete " + targetTemplate + "?", "Delete Template", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (d == DialogResult.Yes) {
                    try {
                        // Delete entire folder and anything inside (true argument):
                        Directory.Delete(Path.Combine(Application.StartupPath, MenuForm.TEMPLATE_FOLDER_NAME, targetTemplate), true);
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
            // Enable the Delete button only if a folder is selected from the list:
            btnDelete.Enabled = lstTemplates.SelectedItem != null;
        }

        private void LstTemplates_HelpRequested(object sender, HelpEventArgs hlpevent) {
            MenuForm.ShowHelp("Click a template from this list to delete. It should be highlighted blue.");
        }

        private void BtnDelete_HelpRequested(object sender, HelpEventArgs hlpevent) {
            MenuForm.ShowHelp("Pressing this button with a template highlighted in blue will ask whether you're sure you want to delete it. Answering yes will delete it.");
        }

        private void BtnCancel_HelpRequested(object sender, HelpEventArgs hlpevent) {
            MenuForm.ShowHelp("Cancel the operation.");
        }
    }
}
