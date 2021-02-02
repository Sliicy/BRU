using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;

namespace STAAC {
    public partial class MenuForm : Form {
        public MenuForm() {
            InitializeComponent();
        }

        public static string selectedTemplate = "";
        public readonly static string templateFolderName = "Templates";
        public readonly static string settingsFileName = "info.txt";

        void RefreshTemplateList() {
            // Remove pre-existing buttons:
            foreach (Control c in pnlButtons.Controls) {
                pnlButtons.Controls.Remove(c);
            }

            // Check if any template folders exist:
            string templatePath = Path.Combine(Application.StartupPath, templateFolderName);
            if (Directory.Exists(templatePath)) {
                int buttonCount = 0;

                DirectoryInfo d = new DirectoryInfo(templatePath);
                DirectoryInfo[] folders = d.GetDirectories().OrderByDescending(t => t.LastWriteTime).ToArray();

                foreach (var folder in folders) {

                    // Create a button for the folder:
                    Button template = new Button {
                        Text = Path.GetFileName(folder.Name),
                        Height = btnNew.Height,
                        Width = pnlButtons.Width,
                        Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
                    };
                    template.Top = buttonCount * template.Height + buttonCount * 12;
                    template.Click += new EventHandler(TemplateChosen);
                    pnlButtons.Controls.Add(template);
                    buttonCount++;
                }
            } else {
                Directory.CreateDirectory(templatePath);
            }
        }

        private void MenuForm_Load(object sender, EventArgs e) {
            RefreshTemplateList();
        }

        protected void TemplateChosen(object sender, EventArgs e) {
            /* This function is called by whichever template button is pressed by user.
               It then calls the templateForm with the corresponding selected template.
             */

            // Keep track of selected template:
            Button button = sender as Button;
            selectedTemplate = button.Text;

            // Show the template:
            TemplateForm form = new TemplateForm();
            form.ShowDialog();
        }

        private void BtnNew_Click(object sender, EventArgs e) {
            var newTemplate = new NewTemplateForm();
            newTemplate.ShowDialog();
            RefreshTemplateList();
        }

        private void BtnImport_Click(object sender, EventArgs e) {
            var zipSelect = new OpenFileDialog() { 
            InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
            Filter = "Compressed Zip Folder (*.zip) | *.zip",
            Multiselect = false,
            Title = "Please choose a zip file template to import."};
            var selection = zipSelect.ShowDialog();
            if (selection == DialogResult.OK) {
                if (Directory.Exists(Path.Combine(Application.StartupPath, templateFolderName, Path.GetFileNameWithoutExtension(zipSelect.FileName)))) {
                    MessageBox.Show("A template with the name \"" + Path.GetFileNameWithoutExtension(zipSelect.FileName) + "\" already exists! Please choose a different name.", "Template Name Conflict", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else {
                    ZipFile.ExtractToDirectory(zipSelect.FileName, Path.Combine(Application.StartupPath, templateFolderName, Path.GetFileNameWithoutExtension(zipSelect.FileName)));
                    MessageBox.Show("Imported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshTemplateList();
                }
            }
        }

        private void BtnExport_Click(object sender, EventArgs e) {
            var export = new ExportTemplateForm();
            export.ShowDialog();
        }

        private void BtnDelete_Click(object sender, EventArgs e) {
            DeleteTemplateForm d = new DeleteTemplateForm();
            d.ShowDialog();
            RefreshTemplateList();
        }
    }
}
