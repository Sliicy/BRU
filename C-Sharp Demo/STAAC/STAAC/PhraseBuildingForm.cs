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
    public partial class PhraseBuildingForm : Form {

        // Word being requested from other form:
        readonly string incomingWord = "";

        private string stringOutput = "";
        
        // List of words from wordlist file:
        private string[] words;

        public string ProcessPhrase() => stringOutput;

        public PhraseBuildingForm() {
            InitializeComponent();
        }

        public PhraseBuildingForm(string initialWord) {
            InitializeComponent();
            incomingWord = initialWord;
            if (!File.Exists(Path.Combine(Application.StartupPath, MenuForm.WORDLISTS_FOLDER_NAME, incomingWord + ".txt"))) {
                // Short-circuit and exit if file doesn't exist:
                stringOutput = incomingWord;
                Close();
            }
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                e.SuppressKeyPress = true;
                txtSearch.Text = txtSearch.Text.Trim(' ').Replace(Environment.NewLine, "");
                txtPhrase.Text += " " + txtSearch.Text;
                btnClearSearch.PerformClick();
            }
        }

        private void TxtPhrase_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                e.SuppressKeyPress = true;
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
            if (lstWords.SelectedItem.ToString().Length > 0) {
                txtPhrase.Text += " " + lstWords.SelectedItem.ToString();
            }
        }
        
        private void BtnDone_Click(object sender, EventArgs e) {
            stringOutput = txtPhrase.Text;
            Close();
        }

        private void PhraseBuildingForm_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Escape || (ModifierKeys == Keys.Control && e.KeyCode == Keys.W)) {
                Close();
            }
        }

        private void PhraseBuildingForm_Load(object sender, EventArgs e) {
            words = File.ReadAllLines(Path.Combine(Application.StartupPath, MenuForm.WORDLISTS_FOLDER_NAME, incomingWord + ".txt"));
            lstWords.Items.AddRange(words);
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e) {
            lstWords.Items.Clear();
            foreach (var word in words) {
                if (word.Contains(txtSearch.Text.Trim(' '))) {
                    lstWords.Items.Add(word);
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e) {
            
            // Append word to wordlist file:
            var response = MessageBox.Show("Add " + txtSearch.Text + " as a subcategory of " + incomingWord + "?", "Add new word", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (response == DialogResult.Yes) {
                File.AppendAllText(Path.Combine(Application.StartupPath, MenuForm.WORDLISTS_FOLDER_NAME, incomingWord + ".txt"), Environment.NewLine + txtSearch.Text);
                
                // Refresh wordlist:                
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
