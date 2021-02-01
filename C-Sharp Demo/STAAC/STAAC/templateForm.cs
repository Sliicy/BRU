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
    public partial class TemplateForm : Form {

        // List of words that the user is angry about (deliberately repeatedly pressing):
        List<string> emphasizable = new List<string>();

        readonly string templateFolderName = "Templates";
        readonly string settingsFileName = "info.txt";

        // Controls whether the template is in edit mode:
        bool editMode = false;

        // Controls whether mouse is dragging a button to re-arrange it:
        bool mouseDragging = false;
        Point dragLocation = new Point(0, 0);

        string author = "";
        string category = "";
        DateTime lastAccessed = new DateTime();

        int buttonWidth = 0;
        int buttonHeight = 0;

        string matrixData = "";

        int matrixWidth = 1;
        int matrixHeight = 1;
        List<List<string>> twoDimensionalMatrix;


        public TemplateForm() {
            InitializeComponent();
        }

        SpeechSynthesizer narrator;

        void reloadButtons(string line) {
            pnlButtons.Controls.Clear();
            buttonWidth = pnlButtons.Width / matrixWidth;
            buttonHeight = pnlButtons.Height / matrixHeight;

            int countX = 0;
            int countY = 0;
            foreach (string segment in line.Split('=')[1].Split(',')) {
                if (segment.Length > 0) {

                    Button newButton = new Button {
                        Text = segment,
                        Size = new Size(buttonWidth, buttonHeight),
                        Location = new Point(buttonWidth * countX, buttonHeight * countY)
                    };
                    newButton.Click += new EventHandler(ButtonClick);
                    newButton.MouseDown += new MouseEventHandler(ButtonMouseDown);
                    newButton.MouseMove += new MouseEventHandler(ButtonMouseMove);
                    newButton.MouseUp += new MouseEventHandler(ButtonMouseUp);

                    // Add .png image if exists:
                    if (File.Exists(Path.Combine(Application.StartupPath, templateFolderName, menuForm.selectedTemplate, segment + ".png"))) {
                        newButton.BackgroundImage = Image.FromFile(Path.Combine(Application.StartupPath, templateFolderName, menuForm.selectedTemplate, segment + ".png"));
                        newButton.BackgroundImageLayout = ImageLayout.Zoom;
                    }
                    pnlButtons.Controls.Add(newButton);
                }
                countX++;
                if (countX > matrixWidth - 1) {
                    countX = 0;
                    countY++;
                }
            }
        }

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
                            



                        } else if (line.ToLower().Contains("matrix data")) {
                            matrixData = line;
                            reloadButtons(matrixData);
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
            if (emphasizable.Contains(buttonPressed.Text.Replace("&", ""))) {
                narrator.SpeakSsmlAsync("<speak version=\"1.0\" xmlns=\"http://www.w3.org/2001/10/synthesis\" xml:lang=\"en-US\"><emphasis>" + buttonPressed.Text.Replace("&", "") + "</emphasis></speak>");
            } else {
                narrator.SpeakAsync(buttonPressed.Text.Replace("&", ""));
                emphasizable.Add(buttonPressed.Text.Replace("&", ""));
                coolDown.Start();
            }
        }

        void ButtonClick(object sender, EventArgs e) {
            if (editMode) {
                if (!mouseDragging) {
                    Button buttonClicked = (Button)sender;
                    NewNameForm n = new NewNameForm(buttonClicked.Text);
                    n.ShowDialog();
                    if (n.saveChanges) buttonClicked.Text = n.newName;
                    n.Dispose();
                }
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
        void ButtonMouseDown(object sender, MouseEventArgs e) {
            // Responsible for initiating a button drag:
            if (editMode) {
                mouseDragging = true;
                Button buttonDragged = (Button)sender;
                dragLocation = new Point(MousePosition.X - RectangleToScreen(ClientRectangle).Left - pnlButtons.Left - buttonDragged.Left, MousePosition.Y - RectangleToScreen(ClientRectangle).Top - pnlButtons.Top - buttonDragged.Top);
            }
        }
        void ButtonMouseMove(object sender, MouseEventArgs e) {
            // Responsible for processing the button drag:
            if (mouseDragging) {
                Button buttonDragged = (Button)sender;
                buttonDragged.Left = MousePosition.X - RectangleToScreen(ClientRectangle).Left - pnlButtons.Left - dragLocation.X;
                buttonDragged.Top = MousePosition.Y - RectangleToScreen(ClientRectangle).Top - pnlButtons.Top - dragLocation.Y;
            }
        }
        void ButtonMouseUp(object sender, MouseEventArgs e) {
            // Stops the button drag:
            mouseDragging = false;
            Button buttonDragged = (Button)sender;
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

        private void BtnEdit_Click(object sender, EventArgs e) {
            editMode = !editMode;
            if (editMode) {
                btnEdit.Text = "Don&e";
            } else {
                btnEdit.Text = "&Edit Buttons";
            }
        }

        private void PnlButtons_Resize(object sender, EventArgs e) {
            foreach (string line in File.ReadAllLines(Path.Combine(Application.StartupPath, templateFolderName, menuForm.selectedTemplate, settingsFileName))) {
                if (line.ToLower().Contains("matrix data")) {
                    reloadButtons(matrixData);
                }
            }
        }
    }
}
