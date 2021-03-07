using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STAAC {
    public partial class EditButtonForm : Form {
        public EditButtonForm() {
            InitializeComponent();
        }

        readonly string originalName = "";
        public string newName = "";
        public bool saveChanges = false;

        public EditButtonForm(string oldName) {
            InitializeComponent();
            originalName = oldName;
        }

        private void NewNameForm_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Escape || (ModifierKeys == Keys.Control && e.KeyCode == Keys.W)) {
                Close();
            }
        }

        private void NewNameForm_Load(object sender, EventArgs e) {
            txtName.Text = originalName;
            txtName.SelectAll();

            // Swap Assignment Button to delete the existing wordlist:
            if (File.Exists(Path.Combine(Application.StartupPath, MenuForm.wordlistsFolderName, txtName.Text + ".txt"))) {
                btnAssignWordlist.Text = "&Delete Wordlist";
            }
        }

        private void TxtName_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                btnOK.PerformClick();
            }
        }

        private void BtnOK_Click(object sender, EventArgs e) {
            if (!(txtName.Text.All(c => char.IsLetterOrDigit(c) || c == '_' || c == ' ' || c == '.' || c == '-' || c == '?' || c == '!'))) {
                MessageBox.Show("Text cannot contain any special symbols.", "No Special Characters", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                newName = txtName.Text;
                saveChanges = true;
                if (File.Exists(Path.Combine(Application.StartupPath, MenuForm.templateFolderName, MenuForm.selectedTemplate, originalName + ".png"))) {
                    File.Move(Path.Combine(Application.StartupPath, MenuForm.templateFolderName, MenuForm.selectedTemplate, originalName + ".png"), Path.Combine(Application.StartupPath, MenuForm.templateFolderName, MenuForm.selectedTemplate, newName + ".png"));
                }
                Close();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e) {
            Close();
        }

        private void NewNameForm_FormClosing(object sender, FormClosingEventArgs e) {
            newName = txtName.Text;
        }

        private void BtnImageSet_Click(object sender, EventArgs e) {
            var picSelect = new OpenFileDialog() {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),
                Multiselect = false,
                Title = "Select image for \"" + txtName.Text + "\":",
                Filter = "Image files (*.bmp, *.jpg, *.jpeg, *.jpe, *.jfif, *.png, *.tiff) | *.bmp; *.jpg; *.jpeg; *.jpe; *.jfif; *.png; *.tiff"
            };

            DialogResult selection = picSelect.ShowDialog();
            if (selection == DialogResult.OK) {

                Bitmap b = (Bitmap)Image.FromFile(picSelect.FileName);
                using (MemoryStream ms = new MemoryStream()) {
                    b.Save(Path.Combine(Application.StartupPath, MenuForm.templateFolderName, MenuForm.selectedTemplate, txtName.Text + ".png"), ImageFormat.Png);
                }
            }

        }

        private void BtnClearImage_Click(object sender, EventArgs e) {
            if (File.Exists(Path.Combine(Application.StartupPath, MenuForm.templateFolderName, MenuForm.selectedTemplate, originalName + ".png"))) {
                DialogResult result = MessageBox.Show("Are you sure you want to permanently delete the picture for \"" + originalName + "\"?" + Environment.NewLine + "It is located at: " + Path.Combine(Application.StartupPath, MenuForm.templateFolderName, MenuForm.selectedTemplate, originalName + ".png"), "Confirm Deletion?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes) {
                    try {
                        File.Delete(Path.Combine(Application.StartupPath, MenuForm.templateFolderName, MenuForm.selectedTemplate, originalName + ".png"));
                    } catch (Exception) {
                        MessageBox.Show("Couldn't delete \"" + originalName + "\"!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnAssignWordlist_Click(object sender, EventArgs e) {
            // Create a wordlist or else remove it:
            if (File.Exists(Path.Combine(Application.StartupPath, MenuForm.wordlistsFolderName, txtName.Text + ".txt"))) {
                var response = MessageBox.Show("Are you sure you want to remove the wordlist associated with " + txtName.Text + "?", "Confirm Deletion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (response == DialogResult.Yes) {
                    try {
                        File.Delete(Path.Combine(Application.StartupPath, MenuForm.wordlistsFolderName, txtName.Text + ".txt"));
                        btnAssignWordlist.Text = "&Add Wordlist";
                    } catch (Exception) {
                        MessageBox.Show(txtName.Text + " couldn't be deleted!", "Failed to delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            } else {
                File.AppendAllText(Path.Combine(Application.StartupPath, MenuForm.wordlistsFolderName, txtName.Text + ".txt"), "");
                btnAssignWordlist.Text = "&Delete Wordlist";
            }
        }

        private void TxtName_HelpRequested(object sender, HelpEventArgs hlpevent) {
            MenuForm.ShowHelp("This is the name the button will use. It can be changed to any combination of words, but commas cannot be used.");
        }

        private void BtnAssignWordlist_HelpRequested(object sender, HelpEventArgs hlpevent) {
            MenuForm.ShowHelp("This button either assigns or removes a wordlist linked to the word. This can be used to create a list of subcategory words for a desired word.");
        }

        private void BtnImageSet_HelpRequested(object sender, HelpEventArgs hlpevent) {
            MenuForm.ShowHelp("This let's a button have an image associated with it.");
        }

        private void BtnClearImage_HelpRequested(object sender, HelpEventArgs hlpevent) {
            MenuForm.ShowHelp("This will remove any images associated with the button.");
        }

        private void BtnCancel_HelpRequested(object sender, HelpEventArgs hlpevent) {
            MenuForm.ShowHelp("Cancel the operation.");
        }
    }
}
