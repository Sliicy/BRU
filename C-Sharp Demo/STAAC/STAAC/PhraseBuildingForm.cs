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

        readonly string incomingWord = "";

        private string stringOutput = "";
        private string[] words;
        public string ProcessPhrase() {
            return stringOutput;
        }

        public PhraseBuildingForm() {
            InitializeComponent();
        }

        public PhraseBuildingForm(string initialWord) {
            InitializeComponent();
            incomingWord = initialWord;
            if (!File.Exists(Path.Combine(Application.StartupPath, MenuForm.wordlistsFolderName, incomingWord + ".txt"))) {
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
            words = File.ReadAllLines(Path.Combine(Application.StartupPath, MenuForm.wordlistsFolderName, incomingWord + ".txt"));
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
    }
}
