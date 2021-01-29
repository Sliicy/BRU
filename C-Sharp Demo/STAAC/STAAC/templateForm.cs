using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Synthesis;
using System.IO;
using System.Diagnostics;

namespace STAAC {
    public partial class templateForm : Form {

        // List of words that the user is angry about (deliberately repeatedly pressing):
        List<string> emphasizable = new List<string>();
        readonly string templateFolderName = "Templates";
        readonly string settingsFileName = "info.txt";

        public templateForm() {
            InitializeComponent();
        }

        SpeechSynthesizer narrator;

        private void MainForm_Load(object sender, EventArgs e) {
            // Insert template name into window title:
            Text = "STAAC - " + menuForm.selectedTemplate;

            // Try to load appropriate template:
            if (Directory.Exists(Path.Combine(Application.StartupPath, templateFolderName, menuForm.selectedTemplate))) {
                if (File.Exists(Path.Combine(Application.StartupPath, templateFolderName, menuForm.selectedTemplate, settingsFileName))) {

                    // Read the Matrix Size

                    // Read all the button names and create buttons for each one

                    // Look for any pictures to add

                    // Assign all buttons' click event to the Help Button click event

                } else {
                    // Settings file wasn't found. Abort:
                    MessageBox.Show("Couldn't find " + settingsFileName + " inside of " + Path.Combine(Application.StartupPath, templateFolderName, menuForm.selectedTemplate) + "!",
                        "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    Close();
                }
            }
        }
        
        private void BtnHelp_Click(object sender, EventArgs e) {
            narrator = new SpeechSynthesizer();
            Button buttonPressed = (Button)sender;
            if (emphasizable.Contains(buttonPressed.Text)) {
                narrator.SpeakSsmlAsync("<speak version=\"1.0\" xmlns=\"http://www.w3.org/2001/10/synthesis\" xml:lang=\"en-US\"><emphasis>" + buttonPressed.Text + "</emphasis></speak>");
            } else {
                narrator.SpeakAsync(buttonPressed.Text);
                emphasizable.Add(buttonPressed.Text);
                coolDown.Start();
            }
        }

        private void CoolDown_Tick(object sender, EventArgs e) {
            // Pop first word from emphasizable list:
            if (emphasizable.Count > 0) emphasizable.RemoveAt(0);
        }

        private void BtnOnScreenKeyboard_Click(object sender, EventArgs e) {
            // Kills any on-screen keyboards, and then launches a new one:
            var tabProcesses = Process.GetProcessesByName("TabTip");
            foreach (Process p in tabProcesses) {
                p.Kill();
            }
            string keyboardPath = Path.Combine(@"C:\Program Files\Common Files\Microsoft Shared\ink", "TabTip.exe");
            Process.Start(keyboardPath);
        }
    }
}
