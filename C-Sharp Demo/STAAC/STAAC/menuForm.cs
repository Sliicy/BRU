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
using STAAC.Models;

/**
 * Class responsible for presenting the main form to choose actions to perform to Templates.
 */
namespace STAAC {
    public partial class MenuForm : Form {
        public MenuForm() {
            InitializeComponent();
        }

        // Contains the name of the active template being used:
        public static string selectedTemplate = "";

        // Constants used throughout the program:
        public const string TEMPLATE_FOLDER_NAME = "Templates";
        public const string WORDLISTS_FOLDER_NAME = "Wordlists";
        public const string SETTINGS_FILE_NAME = "info.txt";

        // Contains a list of last modified dates of Templates:
        List<FolderDates> folderTimes = new List<FolderDates>();

        // Method used throughout program to control flow of help dialogues:
        public static void ShowHelp(string message) {
            MessageBox.Show(message, "Help", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        // Function used to refresh the list of folders in the Templates folder:
        void RefreshTemplateList() {
            /*
             Refreshes the list of templates.
             */

            // Remove pre-existing buttons:
            foreach (Control c in pnlButtons.Controls) {
                pnlButtons.Controls.Remove(c);
            }

            // Check if any template folders exist:
            string templatePath = Path.Combine(Application.StartupPath, TEMPLATE_FOLDER_NAME);
            if (Directory.Exists(templatePath)) {
                int buttonCount = 0;

                // List of folderTimes used to keep track of all templates by date:
                folderTimes = new List<FolderDates>();

                // Calculate each datetime of each folder based on settings file:
                DirectoryInfo di = new DirectoryInfo(templatePath);
                DirectoryInfo[] folders = di.GetDirectories();
                foreach (var folder in folders) {
                    var f = File.ReadAllLines(Path.Combine(folder.FullName, SETTINGS_FILE_NAME));
                    foreach (string line in f) {
                        if (line.ToLower().Contains("last accessed")) {

                            // Create a new FolderDate object, and store name and date:
                            var fd = new FolderDates {
                                Name = Path.GetFileName(folder.Name),
                                Modified = DateTime.Parse(line.Split('=')[1])
                            };
                            folderTimes.Add(fd);

                            // Skip to next folder:
                            break;
                        }
                    }
                }

                // Sort by datetime:
                folderTimes.Sort((x, y) => DateTime.Compare(y.Modified, x.Modified));
                
                foreach (var folderItem in folderTimes) {

                    // Create a button for each folder:
                    Button template = new Button {
                        Text = Path.GetFileName(folderItem.Name),
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
            /*
             This function is called by whichever template button is pressed by the user.
             It then calls the templateForm with the corresponding selected template.
             */

            // Keep track of selected template:
            Button button = sender as Button;
            selectedTemplate = button.Text;

            // Show the template:
            TemplateForm form = new TemplateForm();
            form.ShowDialog();
            Application.Restart();
        }

        private void BtnNew_Click(object sender, EventArgs e) {

            // Display the new Template form:
            var newTemplate = new NewTemplateForm();
            newTemplate.ShowDialog();
            Application.Restart();
        }

        private void BtnImport_Click(object sender, EventArgs e) {

            // Ask where to import the .zip file from:
            var zipSelect = new OpenFileDialog() { 
            InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
            Filter = "Compressed Zip Folder (*.zip) | *.zip",
            Multiselect = false,
            Title = "Please choose a zip file template to import."};
            var selection = zipSelect.ShowDialog();
            if (selection == DialogResult.OK) {
                if (Directory.Exists(Path.Combine(Application.StartupPath, TEMPLATE_FOLDER_NAME, Path.GetFileNameWithoutExtension(zipSelect.FileName)))) {
                    MessageBox.Show("A template with the name \"" + Path.GetFileNameWithoutExtension(zipSelect.FileName) + "\" already exists! Please choose a different name.", "Template Name Conflict", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else {
                    ZipFile.ExtractToDirectory(zipSelect.FileName, Path.Combine(Application.StartupPath, TEMPLATE_FOLDER_NAME, Path.GetFileNameWithoutExtension(zipSelect.FileName)));
                    MessageBox.Show("Imported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshTemplateList();
                }
            }
        }

        private void BtnExport_Click(object sender, EventArgs e) {

            // Display the export Template form:
            var export = new ExportTemplateForm();
            export.ShowDialog();
        }

        private void BtnDelete_Click(object sender, EventArgs e) {

            // Display the delete Template form:
            DeleteTemplateForm d = new DeleteTemplateForm();
            d.ShowDialog();
            Application.Restart();
        }

        private void BtnNew_HelpRequested(object sender, HelpEventArgs hlpevent) {
            ShowHelp("Press this button to create a new template.");
        }

        private void BtnImport_HelpRequested(object sender, HelpEventArgs hlpevent) {
            ShowHelp("Press this button to import an existing template from your computer (such as one being shared by others).");
        }

        private void BtnDelete_HelpRequested(object sender, HelpEventArgs hlpevent) {
            ShowHelp("Press this button to remove a template.");
        }

        private void BtnExport_HelpRequested(object sender, HelpEventArgs hlpevent) {
            ShowHelp("Press this button to export and share any template with others, saving it as a compressed zip file.");
        }

        private void PnlButtons_HelpRequested(object sender, HelpEventArgs hlpevent) {
            ShowHelp("Press any button here to load a template and start using it.");
        }
    }
}
