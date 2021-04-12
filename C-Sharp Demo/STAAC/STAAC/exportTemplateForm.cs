using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/**
 * Class responsible for exporting templates from the Templates folder to a local .zip file.
 */
namespace STAAC {
    public partial class ExportTemplateForm : Form {
        public ExportTemplateForm() {
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

        private void BtnExport_Click(object sender, EventArgs e) {

            // Ask where to save the selected Template to, as a .zip file:
            var saveDialog = new SaveFileDialog() {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                Filter = "Compressed Zip Folder (*.zip) | *.zip",
                FileName = lstTemplates.SelectedItem.ToString() + ".zip",
                Title = "Select Location to Export"};
            var response = saveDialog.ShowDialog();
            if (response == DialogResult.OK) {
                ZipFile.CreateFromDirectory(Path.Combine(Application.StartupPath, MenuForm.TEMPLATE_FOLDER_NAME, lstTemplates.SelectedItem.ToString()), saveDialog.FileName);
                MessageBox.Show("Exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e) {
            Close();
        }

        private void ExportTemplateForm_Load(object sender, EventArgs e) {
            RefreshFolderList();
        }

        private void LstTemplates_SelectedIndexChanged(object sender, EventArgs e) {

            // Enable the Export button only if a folder is selected from the list:
            btnExport.Enabled = lstTemplates.SelectedItem != null;
        }

        private void ExportTemplateForm_KeyDown(object sender, KeyEventArgs e) {

            // Close the form if Ctrl + W or Escape is pressed:
            if (e.KeyCode == Keys.Escape || (ModifierKeys == Keys.Control && e.KeyCode == Keys.W)) {
                Close();
            }
        }

        private void LstTemplates_HelpRequested(object sender, HelpEventArgs hlpevent) {
            MenuForm.ShowHelp("Click a template from this list to export. It should be highlighted blue.");
        }

        private void BtnExport_HelpRequested(object sender, HelpEventArgs hlpevent) {
            MenuForm.ShowHelp("Pressing this button with a template highlighted in blue will ask where to export the template to, so you can share it with others.");
        }

        private void BtnCancel_HelpRequested(object sender, HelpEventArgs hlpevent) {
            MenuForm.ShowHelp("Cancel the operation.");
        }
    }
}
