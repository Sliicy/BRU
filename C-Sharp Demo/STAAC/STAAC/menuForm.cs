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

namespace STAAC {
    public partial class menuForm : Form {
        public menuForm() {
            InitializeComponent();
        }

        public static string selectedTemplate = "";

        private void MenuForm_Load(object sender, EventArgs e) {

            // Check if any template folders exist:
            string templatePath = Path.Combine(Application.StartupPath, "Templates");
            if (Directory.Exists(templatePath)) {
                int buttonCount = 0;
                string[] folders = Directory.GetDirectories(templatePath);

                foreach (var folder in folders) {

                    // Create a button for the folder:
                    Button template = new Button {
                        Text = Path.GetFileName(folder),
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

        protected void TemplateChosen(object sender, EventArgs e) {
            /* This function is called by whichever template button is pressed by user.
               It then calls the templateForm with the corresponding selected template.
             */

            // Keep track of selected template:
            Button button = sender as Button;
            selectedTemplate = button.Text;

            // Show the template:
            templateForm form = new templateForm();
            form.ShowDialog();
        }

        private void BtnNew_Click(object sender, EventArgs e) {

        }

        private void BtnImport_Click(object sender, EventArgs e) {

        }

        private void BtnExport_Click(object sender, EventArgs e) {

        }

        private void BtnDelete_Click(object sender, EventArgs e) {

        }
    }
}
