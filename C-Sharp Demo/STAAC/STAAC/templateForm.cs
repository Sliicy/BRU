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
        List<string> requiredSettingOptions = new List<string>() { "Author", "Category", "Last Accessed", "Matrix Size", "Matrix Data" };

        readonly string templateFolderName = "Templates";
        readonly string settingsFileName = "info.txt";

        bool editMode = false;

        string author = "";
        string category = "";
        DateTime lastAccessed = new DateTime();


        int matrixWidth = 1;
        int matrixHeight = 1;
        List<List<string>> twoDimensionalMatrix;


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



                    foreach (string line in File.ReadAllLines(Path.Combine(Application.StartupPath, templateFolderName, menuForm.selectedTemplate, settingsFileName))) {
                        if (line.ToLower().Contains("author")) {

                            author = line.Split('=')[1];
                        } else if (line.ToLower().Contains("category")) {

                            category = line.Split('=')[1];
                        } else if (line.ToLower().Contains("matrix size")) {

                            matrixWidth = int.Parse(line.Split('=')[1].Split('x')[0]);
                            matrixHeight = int.Parse(line.Split('=')[1].Split('x')[1]);
                            tlpButtons.Controls.Clear();
                            tlpButtons.RowCount = matrixWidth;
                            tlpButtons.ColumnCount = matrixHeight;
                        } else if (line.ToLower().Contains("matrix data")) {

                            int count = 0;
                            foreach (string segment in line.Split('=')[1].Split(',')) {
                                if (segment.Length > 0) {
                                    Button newButton = new Button {
                                        Text = segment,
                                        Dock = DockStyle.Fill
                                    };
                                    newButton.Click += new EventHandler(ButtonClick);

                                    // Add .png image if exists:
                                    if (File.Exists(Path.Combine(Application.StartupPath, templateFolderName, menuForm.selectedTemplate, segment + ".png"))) {
                                        newButton.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, templateFolderName, menuForm.selectedTemplate, segment + ".png"));
                                        newButton.BackgroundImageLayout = ImageLayout.Zoom;
                                    }

                                    tlpButtons.Controls.Add(newButton, count % matrixHeight, count % matrixWidth );
                                }
                                count++;
                            }
                        }

                    }

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

        void ButtonClick(object sender, EventArgs e) {
            if (editMode) {
                Button buttonClicked = (Button)sender;
                newNameForm n = new newNameForm(buttonClicked.Text);
                n.ShowDialog();
                if (n.saveChanges) buttonClicked.Text = n.newName;

            } else {
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

        private void btnEdit_Click(object sender, EventArgs e) {
            editMode = !editMode;
            if (editMode) {
                btnEdit.Text = "Done";
            } else {
                btnEdit.Text = "Edit";
            }
        }
    }
}
