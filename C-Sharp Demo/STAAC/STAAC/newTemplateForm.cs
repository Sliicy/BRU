﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STAAC {
    public partial class NewTemplateForm : Form {
        public NewTemplateForm() {
            InitializeComponent();
        }

        private void BtnCreate_Click(object sender, EventArgs e) {
            // Filter for only numbers for dimensions:
            txtWidth.Text = Regex.Replace(txtWidth.Text, "[^0-9]", "");
            txtHeight.Text = Regex.Replace(txtHeight.Text, "[^0-9]", "");
            if (txtWidth.Text.Trim() == "" || txtHeight.Text.Trim() == "") {
                MessageBox.Show("Width and Height must be greater than 0.", "Size Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Directory.Exists(Path.Combine(Application.StartupPath, MenuForm.templateFolderName, txtName.Text))) {
                MessageBox.Show("A template with the name \"" + txtName.Text + "\" already exists! Please choose a different name.", "Template Name Conflict", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                if (!(txtName.Text.All(c => char.IsLetterOrDigit(c) || c == '_' || c == ' ' || c == '.' || c == '-' || c == '!'))) {
                    MessageBox.Show("Name cannot contain any special symbols.", "No Special Characters", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else {
                    Directory.CreateDirectory(Path.Combine(Application.StartupPath, MenuForm.templateFolderName, txtName.Text));
                    string commas = "";
                    for (int i = 1; i < int.Parse(txtWidth.Text) * int.Parse(txtHeight.Text); i++) {
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
            if (e.KeyCode == Keys.Escape || (ModifierKeys == Keys.Control && e.KeyCode == Keys.W)) {
                Close();
            }
        }

        private void NewTemplateForm_Load(object sender, EventArgs e) {
            cbColorScheme.SelectedIndex = 0;
        }

        private void TxtWidth_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }
        }

        private void TxtHeight_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }
        }

        private void TxtWidth_TextChanged(object sender, EventArgs e) {
            txtWidth.Text = Regex.Replace(txtWidth.Text, "[^0-9]", "");
        }

        private void TxtHeight_TextChanged(object sender, EventArgs e) {
            txtHeight.Text = Regex.Replace(txtHeight.Text, "[^0-9]", "");
        }

        private void TxtName_HelpRequested(object sender, HelpEventArgs hlpevent) {
            MenuForm.ShowHelp("Enter the name of new template. This name must not already be in use, and can't contain special characters.");
        }

        private void TxtAuthor_HelpRequested(object sender, HelpEventArgs hlpevent) {
            MenuForm.ShowHelp("Optionally enter the name of the author (the person making this template).");
        }

        private void TxtCategory_HelpRequested(object sender, HelpEventArgs hlpevent) {
            MenuForm.ShowHelp("Optionally enter the category for this template.");
        }

        private void TxtWidth_HelpRequested(object sender, HelpEventArgs hlpevent) {
            MenuForm.ShowHelp("Specify the number of buttons that should be in each row when creating the matrix of buttons.");
        }

        private void TxtHeight_HelpRequested(object sender, HelpEventArgs hlpevent) {
            MenuForm.ShowHelp("Specify the number of buttons that should be in each column when creating the matrix of buttons.");
        }

        private void CbColorScheme_HelpRequested(object sender, HelpEventArgs hlpevent) {
            MenuForm.ShowHelp("Optionally enter the color scheme that all buttons should use (all buttons will become this color).");
        }

        private void BtnCreate_HelpRequested(object sender, HelpEventArgs hlpevent) {
            MenuForm.ShowHelp("Create a new template with the specified sizes, names and other info provided.");
        }

        private void BtnCancel_HelpRequested(object sender, HelpEventArgs hlpevent) {
            MenuForm.ShowHelp("Cancel the operation.");
        }
    }
}
