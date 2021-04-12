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

/**
 * Class responsible for editing buttons from a Template.
 */
namespace STAAC {
    public partial class EditButtonForm : Form {
        public EditButtonForm() {
            InitializeComponent();
        }

        // Holds the original name of the button before modifications:
        readonly string originalName = "";

        // Holds the new name if the user changes it:
        public string newName = "";

        // Boolean whether or not to save changes made:
        public bool saveChanges = false;

        public EditButtonForm(string oldName) {
            InitializeComponent();
            
            // Get the original name upon loading the form:
            originalName = oldName;
        }

        private void NewNameForm_KeyDown(object sender, KeyEventArgs e) {

            // Close the form if Ctrl + W or Escape is pressed:
            if (e.KeyCode == Keys.Escape || (ModifierKeys == Keys.Control && e.KeyCode == Keys.W)) {
                Close();
            }
        }

        private void NewNameForm_Load(object sender, EventArgs e) {
            // Set the textbox to contain the original name:
            txtName.Text = originalName;
            txtName.SelectAll();

            // Morph the Assignment Button into a Delete Button, depending on if there is a
            // wordlist with the original name or not:
            // If there is no wordlist, then this button functions to create a new wordlist.
            if (File.Exists(Path.Combine(Application.StartupPath, MenuForm.wordlistsFolderName, txtName.Text + ".txt"))) {
                btnAssignWordlist.Text = "&Delete Wordlist";
            }
        }

        private void TxtName_KeyDown(object sender, KeyEventArgs e) {
            
            // Pressing Enter is like clicking OK:
            if (e.KeyCode == Keys.Enter) {
                btnOK.PerformClick();
            }
        }

        private void BtnOK_Click(object sender, EventArgs e) {
            
            // Check if the textbox has any illegal characters:
            if (!(txtName.Text.All(c => char.IsLetterOrDigit(c) || c == '_' || c == ' ' || c == '.' || c == '-' || c == '?' || c == '!'))) {
                MessageBox.Show("Text cannot contain any special symbols.", "No Special Characters", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {

                // Apply the changes:
                newName = txtName.Text;
                saveChanges = true;
                
                // Check if there's also a picture that has the original name, that needs to change to the new name:
                if (File.Exists(Path.Combine(Application.StartupPath, MenuForm.templateFolderName, MenuForm.selectedTemplate, originalName + ".png"))) {
                    
                    // Rename the original image to the new name along with .png appended:
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
            
            // Ask user to pick an image to represent the button:
            var picSelect = new OpenFileDialog() {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),
                Multiselect = false,
                Title = "Select image for \"" + txtName.Text + "\":",
                Filter = "Image files (*.bmp, *.jpg, *.jpeg, *.jpe, *.jfif, *.png, *.tiff) | *.bmp; *.jpg; *.jpeg; *.jpe; *.jfif; *.png; *.tiff"
            };

            DialogResult selection = picSelect.ShowDialog();
            if (selection == DialogResult.OK) {

                // Set the image (copy the image, rename it, convert it to .png, and save it to the Template folder):
                Bitmap b = (Bitmap)Image.FromFile(picSelect.FileName);
                using (MemoryStream ms = new MemoryStream()) {
                    b.Save(Path.Combine(Application.StartupPath, MenuForm.templateFolderName, MenuForm.selectedTemplate, txtName.Text + ".png"), ImageFormat.Png);
                }
            }

        }

        private void BtnClearImage_Click(object sender, EventArgs e) {

            // Confirm to remove the image associated with that button:
            if (File.Exists(Path.Combine(Application.StartupPath, MenuForm.templateFolderName, MenuForm.selectedTemplate, originalName + ".png"))) {
                DialogResult result = MessageBox.Show("Are you sure you want to permanently delete the picture for \"" + originalName + "\"?" + Environment.NewLine + "It is located at: " + Path.Combine(Application.StartupPath, MenuForm.templateFolderName, MenuForm.selectedTemplate, originalName + ".png"), "Confirm Deletion?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes) {
                    try {

                        // Delete the image:
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
