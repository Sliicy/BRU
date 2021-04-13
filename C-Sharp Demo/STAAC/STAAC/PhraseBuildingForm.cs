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
 * Class responsible for adding sub-category words to the word just pressed.
 */
namespace STAAC {
    public partial class PhraseBuildingForm : Form {

        // Word being requested from the other form:
        readonly string incomingWord = "";

        // Output string which will be returned after this form closes:
        private string stringOutput = "";
        
        // List of words retrieved from the wordlist file:
        private string[] words;

        // Process & return the phrase to the output string:
        public string ProcessPhrase() => stringOutput;

        public PhraseBuildingForm() {
            InitializeComponent();
        }

        public PhraseBuildingForm(string initialWord) {
            InitializeComponent();

            // Get the word used to trigger this whole form and use it as the original word:
            incomingWord = initialWord;

            // Check if there's a wordlist that exists with that name:
            if (!File.Exists(Path.Combine(Application.StartupPath, MenuForm.WORDLISTS_FOLDER_NAME, incomingWord + ".txt"))) {

                // If there's no wordlist that exists with that name, then return the original word and close the form
                // (essentially returns what it was given):
                stringOutput = incomingWord;
                Close();
            }
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e) {

            // Sanitize the textbox (remove empty spaces at the ends & remove newlines):
            if (e.KeyCode == Keys.Enter) {
                e.SuppressKeyPress = true;
                txtSearch.Text = txtSearch.Text.Trim(' ').Replace(Environment.NewLine, "");
                txtPhrase.Text += " " + txtSearch.Text;
                btnClearSearch.PerformClick();
            }
        }

        private void TxtPhrase_KeyDown(object sender, KeyEventArgs e) {

            // Prevent adding a newline to the textbox (since it's only a single line textbox):
            if (e.KeyCode == Keys.Enter) {
                e.SuppressKeyPress = true;

                // Simulate and press "Done":
                btnDone.PerformClick();
            }
        }

        private void BtnClearSearch_Click(object sender, EventArgs e) {
            txtSearch.Clear();
        }

        private void BtnClear_Click(object sender, EventArgs e) {
            txtPhrase.Clear();
        }

        private void BtnAnd_Click(object sender, EventArgs e) {
            txtPhrase.Text += " and";
            btnClearSearch.PerformClick();
        }

        private void BtnOr_Click(object sender, EventArgs e) {
            txtPhrase.Text += " or";
            btnClearSearch.PerformClick();
        }

        private void BtnNot_Click(object sender, EventArgs e) {
            txtPhrase.Text += " not";
            btnClearSearch.PerformClick();
        }

        private void LstWords_SelectedIndexChanged(object sender, EventArgs e) {

            // Add the word to the output string being created whenever the list is clicked on:
            if (lstWords.SelectedItem.ToString().Length > 0) {
                txtPhrase.Text += " " + lstWords.SelectedItem.ToString();
            }
        }
        
        private void BtnDone_Click(object sender, EventArgs e) {

            // Set the output up and return it to the previous form:
            stringOutput = txtPhrase.Text;
            Close();
        }

        private void PhraseBuildingForm_KeyDown(object sender, KeyEventArgs e) {

            // Close the form if Ctrl + W or Escape is pressed:
            if (e.KeyCode == Keys.Escape || (ModifierKeys == Keys.Control && e.KeyCode == Keys.W)) {
                Close();
            }
        }

        private void PhraseBuildingForm_Load(object sender, EventArgs e) {

            // If PhraseBuildingForm(string initialWord) found an existing Wordlist file for the word, then
            // this loads those words into memory:
            words = File.ReadAllLines(Path.Combine(Application.StartupPath, MenuForm.WORDLISTS_FOLDER_NAME, incomingWord + ".txt"));
            lstWords.Items.AddRange(words);
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e) {

            // Filter the list as text is entered to search for words:
            lstWords.Items.Clear();
            foreach (var word in words) {
                if (word.Contains(txtSearch.Text.Trim(' '))) {
                    lstWords.Items.Add(word);
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e) {
            
            // Add the word that wasn't found to the wordlist file (so it can be found in the future):
            var response = MessageBox.Show("Add " + txtSearch.Text + " as a subcategory of " + incomingWord + "?", "Add new word", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (response == DialogResult.Yes) {
                File.AppendAllText(Path.Combine(Application.StartupPath, MenuForm.WORDLISTS_FOLDER_NAME, incomingWord + ".txt"), Environment.NewLine + txtSearch.Text);
                
                // Refresh the wordlist:                
                words = File.ReadAllLines(Path.Combine(Application.StartupPath, MenuForm.WORDLISTS_FOLDER_NAME, incomingWord + ".txt"));
                TxtSearch_TextChanged(sender, e);
            }
        }

        private void LstWords_DoubleClick(object sender, EventArgs e) {
            btnDone.PerformClick();
        }

        private void TxtSearch_HelpRequested(object sender, HelpEventArgs hlpevent) {
            MenuForm.ShowHelp("Type any words here to filter the list below for a specific word. If the word doesn't exist, it can be added with the \"Add\" button.");
        }

        private void BtnAdd_HelpRequested(object sender, HelpEventArgs hlpevent) {
            MenuForm.ShowHelp("Use this button to permanently add the desired word to the wordlist.");
        }

        private void BtnClearSearch_HelpRequested(object sender, HelpEventArgs hlpevent) {
            MenuForm.ShowHelp("Clear the search results and show all words again.");
        }

        private void LstWords_HelpRequested(object sender, HelpEventArgs hlpevent) {
            MenuForm.ShowHelp("Click on any words here to populate them in the textbox on the bottom.");
        }

        private void BtnAnd_HelpRequested(object sender, HelpEventArgs hlpevent) {
            MenuForm.ShowHelp("Use these 3 buttons (\"And\", \"Or\" and \"Not\") to include or exclude words from the above list.");
        }

        private void TxtPhrase_HelpRequested(object sender, HelpEventArgs hlpevent) {
            MenuForm.ShowHelp("This is the final phrase that will be used after pressing \"Done\".");
        }

        private void BtnClear_HelpRequested(object sender, HelpEventArgs hlpevent) {
            MenuForm.ShowHelp("This will reset the entire phrase being made.");
        }

        private void BtnDone_HelpRequested(object sender, HelpEventArgs hlpevent) {
            MenuForm.ShowHelp("This will close the prompt and pass along the phrase generated at the bottom of the window.");
        }
    }
}
