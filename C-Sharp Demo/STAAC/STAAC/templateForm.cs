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

        

        // Controls whether the template is in edit mode:
        bool editMode = false;

        // Controls whether mouse is dragging a button to re-arrange it:
        bool mouseDragging = false;
        Point dragLocation = new Point();
        Point oldButtonLocation = new Point();

        string author = "";
        string category = "";
        string colorScheme = "None";

        int buttonWidth = 0;
        int buttonHeight = 0;

        string matrixData = "";

        int matrixWidth = 1;
        int matrixHeight = 1;


        public TemplateForm() {
            InitializeComponent();
        }

        SpeechSynthesizer narrator;

        /*
         * Load a bitmap without locking it:
         * Source: http://csharphelper.com/blog/2014/07/load-images-without-locking-their-files-in-c/
        */
        private static Bitmap LoadBitmapUnlocked(string fileName) {
            using (Bitmap bm = new Bitmap(fileName)) {
                return new Bitmap(bm);
            }
        }

        // Function that refreshes all buttons on the grid, based on the matrix data line found in the info file:
        void ReloadButtons(string line) {
            pnlButtons.Controls.Clear();
            buttonWidth = pnlButtons.Width / matrixWidth;
            buttonHeight = pnlButtons.Height / matrixHeight;

            int countX = 0;
            int countY = 0;
            foreach (string segment in line.Split('=')[1].Split(',')) {

                Button newButton = new Button {
                    Text = segment,
                    Size = new Size(buttonWidth, buttonHeight),
                    Location = new Point(buttonWidth * countX, buttonHeight * countY)
                };

                if (colorScheme.Length > 0) {
                    switch (colorScheme.ToLower()) {
                        case "none":
                            break;
                        case "rainbow":

                            break;
                        default:
                            newButton.BackColor = Color.FromName(colorScheme);
                            break;
                    }
                }

                // Assign all buttons' click events, and drag events:
                newButton.Click += new EventHandler(ButtonClick);
                newButton.MouseDown += new MouseEventHandler(ButtonMouseDown);
                newButton.MouseMove += new MouseEventHandler(ButtonMouseMove);
                newButton.MouseUp += new MouseEventHandler(ButtonMouseUp);

                // Add .PNG image if exists:
                AddPicture(segment, newButton);

                // Add button to the template:
                pnlButtons.Controls.Add(newButton);

                countX++;
                if (countX > matrixWidth - 1) {
                    countX = 0;
                    countY++;
                }
            }
        }

        private static void AddPicture(string filename, Button button) {
            if (File.Exists(Path.Combine(Application.StartupPath, MenuForm.templateFolderName, MenuForm.selectedTemplate, filename + ".png"))) {
                button.BackgroundImage = LoadBitmapUnlocked(Path.Combine(Application.StartupPath, MenuForm.templateFolderName, MenuForm.selectedTemplate, filename + ".png"));
                button.BackgroundImageLayout = ImageLayout.Zoom;
            }
        }

        // Function to remember button changes (name, image, or location changes):
        void RecalculateMatrix() {
            matrixData = "Matrix Data=";

            foreach (Control c in pnlButtons.Controls) {
                matrixData += c.Text + ",";
            }
            matrixData = matrixData.Remove(matrixData.Length - 1, 1);
        }

        // This function saves all changes to file:
        void SaveSettings() {
            File.WriteAllText(Path.Combine(Application.StartupPath, MenuForm.templateFolderName, MenuForm.selectedTemplate, MenuForm.settingsFileName), 
                "Author=" + author + Environment.NewLine +
                "Category=" + category + Environment.NewLine +
                "Last Accessed=" + DateTime.Now + Environment.NewLine +
                "Matrix Size=" + matrixWidth + "x" + matrixHeight + Environment.NewLine +
                "Color Scheme=" + colorScheme + Environment.NewLine + 
                matrixData);
        }

        private void MainForm_Load(object sender, EventArgs e) {
            // Insert template name into window title:
            Text = "STAAC - " + MenuForm.selectedTemplate;

            // Try to load appropriate template:
            if (Directory.Exists(Path.Combine(Application.StartupPath, MenuForm.templateFolderName, MenuForm.selectedTemplate))) {
                if (File.Exists(Path.Combine(Application.StartupPath, MenuForm.templateFolderName, MenuForm.selectedTemplate, MenuForm.settingsFileName))) {



                    foreach (string line in File.ReadAllLines(Path.Combine(Application.StartupPath, MenuForm.templateFolderName, MenuForm.selectedTemplate, MenuForm.settingsFileName))) {
                        if (line.ToLower().Contains("author")) {

                            author = line.Split('=')[1];
                        } else if (line.ToLower().Contains("category")) {

                            category = line.Split('=')[1];




                        } else if (line.ToLower().Contains("matrix size")) {
                            // Read Matrix size:
                            matrixWidth = int.Parse(line.Split('=')[1].Split('x')[0]);
                            matrixHeight = int.Parse(line.Split('=')[1].Split('x')[1]);



                        } else if (line.ToLower().Contains("color scheme")) {

                            colorScheme = line.Split('=')[1];

                            // Apply a color scheme:
                            switch (colorScheme) {
                                case "rainbow":

                                    break;
                                case "red":

                                    break;
                            }

                        } else if (line.ToLower().Contains("matrix data")) {
                            // Read all the button names and create buttons for each one:
                            matrixData = line;
                            ReloadButtons(matrixData);
                        }

                    }
                } else {
                    // Settings file wasn't found. Abort:
                    MessageBox.Show("Couldn't find " + MenuForm.settingsFileName + " inside of " + Path.Combine(Application.StartupPath, MenuForm.templateFolderName, MenuForm.selectedTemplate) + "!",
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
                Button buttonClicked = (Button)sender;
                if (oldButtonLocation == buttonClicked.Location) {
                    NewNameForm n = new NewNameForm(buttonClicked.Text);
                    n.ShowDialog();
                    if (n.saveChanges) buttonClicked.Text = n.newName;
                    buttonClicked.BackgroundImage = null;
                    AddPicture(buttonClicked.Text, buttonClicked);
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
                
                // Bring button above all others:
                buttonDragged.BringToFront();

                oldButtonLocation = buttonDragged.Location;
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

            // Snap button onto grid:
            buttonDragged.Left = (int)(Math.Round(buttonDragged.Left / (double)buttonDragged.Width, 0) * buttonDragged.Width);
            buttonDragged.Top = (int)(Math.Round(buttonDragged.Top / (double)buttonDragged.Height, 0) * buttonDragged.Height);
            
            // Check if any button beneath:
            foreach (Control c in pnlButtons.Controls) {
                if (c.Location == buttonDragged.Location && buttonDragged != c) {

                    // Put interfering button in place of old button:
                    c.Location = oldButtonLocation;
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

        private void BtnEdit_Click(object sender, EventArgs e) {
            editMode = !editMode;
            if (editMode) {
                btnEdit.Text = "Don&e";
            } else {
                btnEdit.Text = "&Edit Buttons";
                RecalculateMatrix();
                SaveSettings();
            }
        }

        private void PnlButtons_Resize(object sender, EventArgs e) {
            foreach (string line in File.ReadAllLines(Path.Combine(Application.StartupPath, MenuForm.templateFolderName, MenuForm.selectedTemplate, MenuForm.settingsFileName))) {
                if (line.ToLower().Contains("matrix data")) {
                    ReloadButtons(matrixData);
                }
            }
        }

        private void BtnBack_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
