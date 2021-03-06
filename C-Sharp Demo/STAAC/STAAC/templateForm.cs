﻿using System;
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
using STAAC.Models;

/**
 * Class responsible for displaying buttons to use from the template, as well as editing those buttons, generating audio,
 * and everything else STAAC promises.
 */
namespace STAAC {
    public partial class TemplateForm : Form {

        // List of words that the user is deliberate about (deliberately repeatedly pressing any specific button):
        readonly List<string> emphasizable = new List<string>();

        // Controls whether the template buttons can be edited or not:
        bool editMode = false;

        // Controls whether the mouse is dragging a button to re-arrange it:
        bool mouseDragging = false;
        Point dragLocation = new Point();
        Point oldButtonLocation = new Point();

        // Contains a model of each template:
        readonly TemplateModel bm = new TemplateModel(MenuForm.selectedTemplate, 1, 1);

        // Holds the dimensions used to calculate the button's size for height and width:
        int buttonWidth = 0;
        int buttonHeight = 0;

        // Speech object used to speak:
        SpeechSynthesizer narrator;

        // String to remember the last phrase just spoken:
        string lastPhraseSpoken = "";

        // Controls whether to clear the speech box:
        bool clearTextOnNextPress = false;

        public TemplateForm() {
            InitializeComponent();
        }

        /*
         * Load a bitmap without the file becoming locked:
         * Source: http://csharphelper.com/blog/2014/07/load-images-without-locking-their-files-in-c/
        */
        public static Bitmap LoadBitmapUnlocked(string fileName) {
            using (Bitmap bm = new Bitmap(fileName)) {
                return new Bitmap(bm);
            }
        }

        // Function that refreshes all buttons on the grid, based on the matrix data line found in the info file:
        void ReloadButtons(string line) {
            pnlButtons.Controls.Clear();
            buttonWidth = pnlButtons.Width / bm.GetMatrixWidth();
            buttonHeight = pnlButtons.Height / bm.GetMatrixHeight();

            // These values increment as buttons are added. They are used to properly space everything:
            int countX = 0;
            int countY = 0;

            // For each word found in the settings file, delimited by commas (coming from the "Matrix Data=" entrypoint):
            foreach (string segment in line.Split('=')[1].Split(',')) {

                // Create a new button to project onto the form:
                Button newButton = new Button {

                    // Assign the text and sizes obtained from the settings file:
                    Text = segment,
                    Size = new Size(buttonWidth, buttonHeight),
                    Location = new Point(buttonWidth * countX, buttonHeight * countY)
                };

                // Check for the appropriate colors for all the buttons to follow:
                if (bm.GetColorScheme().Length > 0) {
                    switch (bm.GetColorScheme().ToLower()) {
                        case "none":
                            break;
                        default:
                            newButton.BackColor = Color.FromName(bm.GetColorScheme());
                            break;
                    }
                }

                // Assign all buttons' click events, and drag events (so they can all dynamically be edited):
                newButton.Click += new EventHandler(ButtonClick);
                newButton.MouseDown += new MouseEventHandler(ButtonMouseDown);
                newButton.MouseMove += new MouseEventHandler(ButtonMouseMove);
                newButton.MouseUp += new MouseEventHandler(ButtonMouseUp);

                // Add a .PNG image if one exists for that particular button:
                AddPicture(segment, newButton);

                // Finally, add button to the template:
                pnlButtons.Controls.Add(newButton);

                // Keep counting horizontally, and then vertically:
                countX++;
                if (countX > bm.GetMatrixWidth() - 1) {
                    countX = 0;
                    countY++;
                }
            }
        }

        private static void AddPicture(string filename, Button button) {

            // Load the appropriate image from the Template folder given the name of the button, if it exists:
            if (File.Exists(Path.Combine(Application.StartupPath, MenuForm.TEMPLATE_FOLDER_NAME, MenuForm.selectedTemplate, filename + ".png"))) {
                button.BackgroundImage = LoadBitmapUnlocked(Path.Combine(Application.StartupPath, MenuForm.TEMPLATE_FOLDER_NAME, MenuForm.selectedTemplate, filename + ".png"));
                button.BackgroundImageLayout = ImageLayout.Zoom;
            }
        }

        // Function used to redraw the matrix of buttons:
        void RecalculateMatrix() {
            bm.SetMatrixData("Matrix Data=");

            // Sort controls by location (top, then left):
            var allButtons = new List<Control>();
            foreach (Control c in pnlButtons.Controls) {
                allButtons.Add(c);
            }
            var leftToRightButtonList = allButtons.OrderBy(o => o.Top).ThenBy(o => o.Left).ToList();
            
            // Sequentially add each button's text into the matrixData:
            foreach (var button in leftToRightButtonList) {
                bm.SetMatrixData(bm.GetMatrixData() + button.Text + ",");
            }
            bm.SetMatrixData(bm.GetMatrixData().Remove(bm.GetMatrixData().Length - 1, 1));
        }

        // Method to save all changes made to the settings file:
        void SaveSettings() {
            if (!Directory.Exists(Path.Combine(Application.StartupPath, MenuForm.TEMPLATE_FOLDER_NAME, MenuForm.selectedTemplate))) {
                Directory.CreateDirectory(Path.Combine(Application.StartupPath, MenuForm.TEMPLATE_FOLDER_NAME, MenuForm.selectedTemplate));
            }
            File.WriteAllText(Path.Combine(Application.StartupPath, MenuForm.TEMPLATE_FOLDER_NAME, MenuForm.selectedTemplate, MenuForm.SETTINGS_FILE_NAME), 
                "Author=" + bm.GetAuthor() + Environment.NewLine +
                "Category=" + bm.GetCategory() + Environment.NewLine +
                "Last Accessed=" + DateTime.Now + Environment.NewLine +
                "Matrix Size=" + bm.GetMatrixWidth() + "x" + bm.GetMatrixHeight() + Environment.NewLine +
                "Color Scheme=" + bm.GetColorScheme() + Environment.NewLine +
                bm.GetMatrixData());
        }

        private void MainForm_Load(object sender, EventArgs e) {

            // Insert template name into window title:
            Text = "STAAC - " + MenuForm.selectedTemplate;

            // Create wordlists folder if it doesn't exist:
            if (!Directory.Exists(Path.Combine(Application.StartupPath, MenuForm.WORDLISTS_FOLDER_NAME))) {
                Directory.CreateDirectory(Path.Combine(Application.StartupPath, MenuForm.WORDLISTS_FOLDER_NAME));
            }

            // Try to load appropriate template:
            if (Directory.Exists(Path.Combine(Application.StartupPath, MenuForm.TEMPLATE_FOLDER_NAME, MenuForm.selectedTemplate))) {
                if (File.Exists(Path.Combine(Application.StartupPath, MenuForm.TEMPLATE_FOLDER_NAME, MenuForm.selectedTemplate, MenuForm.SETTINGS_FILE_NAME))) {

                    // Load all settings found based on predefined entrypoints from settings file (case-insensitive):
                    foreach (string line in File.ReadAllLines(Path.Combine(Application.StartupPath, MenuForm.TEMPLATE_FOLDER_NAME, MenuForm.selectedTemplate, MenuForm.SETTINGS_FILE_NAME))) {
                        if (line.ToLower().Contains("author")) {
                            bm.SetAuthor(line.Split('=')[1]);
                        } else if (line.ToLower().Contains("category")) {
                            bm.SetCategory(line.Split('=')[1]);
                        } else if (line.ToLower().Contains("matrix size")) {

                            // Read Matrix size:
                            bm.SetMatrixWidth(int.Parse(line.Split('=')[1].Split('x')[0]));
                            bm.SetMatrixHeight(int.Parse(line.Split('=')[1].Split('x')[1]));

                        } else if (line.ToLower().Contains("color scheme")) {
                            bm.SetColorScheme(line.Split('=')[1]);
                        } else if (line.ToLower().Contains("matrix data")) {

                            // Read all the button names and create buttons for each one:
                            bm.SetMatrixData(line);
                            ReloadButtons(bm.GetMatrixData());
                        }
                    }
                } else {

                    // Settings file wasn't found. Abort:
                    MessageBox.Show("Couldn't find " + MenuForm.SETTINGS_FILE_NAME + " inside of " + Path.Combine(Application.StartupPath, MenuForm.TEMPLATE_FOLDER_NAME, MenuForm.selectedTemplate) + "!",
                        "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    Close();
                }
            }
        }
        
        private void BtnHelp_Click(object sender, EventArgs e) {

            // Create a Speech object to pronounce words based on their text contents:
            narrator = new SpeechSynthesizer();
            Button buttonPressed = (Button)sender;
            if (emphasizable.Contains(buttonPressed.Text.Replace("&", ""))) {
                narrator.SpeakSsmlAsync("<speak version=\"1.0\" xmlns=\"http://www.w3.org/2001/10/synthesis\" xml:lang=\"en-US\"><emphasis>" + buttonPressed.Text.Replace("&", "") + "</emphasis></speak>");
            } else {
                narrator.SpeakAsync(buttonPressed.Text.Replace("&", ""));

                // Add the word to emphasizable list, which is also removed from said list after a few seconds:
                emphasizable.Add(buttonPressed.Text.Replace("&", ""));
                coolDown.Start();
            }
        }

        void ButtonClick(object sender, EventArgs e) {

            // Erase old words if "Clear" is pressed:
            if (clearTextOnNextPress) {
                txtSpeechBar.Clear();
            }
            clearTextOnNextPress = false;
            
            // Check if edit mode is on or off:
            Button buttonPressed = (Button)sender;
            if (editMode) {
                
                // Allow the button to be edited:
                if (oldButtonLocation == buttonPressed.Location) {
                    EditButtonForm n = new EditButtonForm(buttonPressed.Text);
                    n.ShowDialog();
                    if (n.saveChanges) buttonPressed.Text = n.newName;
                    buttonPressed.BackgroundImage = null;
                    AddPicture(buttonPressed.Text, buttonPressed);
                    n.Dispose();
                }
            } else {

                // Process any special words that have dictionaries associated with them:
                if (File.Exists(Path.Combine(Application.StartupPath, MenuForm.WORDLISTS_FOLDER_NAME, buttonPressed.Text + ".txt"))) {
                    var wordForm = new PhraseBuildingForm(buttonPressed.Text);
                    wordForm.ShowDialog();
                    string fullPhrase = wordForm.ProcessPhrase();
                    txtSpeechBar.Text += " " + fullPhrase;
                } else {
                    txtSpeechBar.Text += " " + buttonPressed.Text;
                }
                txtSpeechBar.Text = txtSpeechBar.Text.Trim();
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
            
            // Check if any button beneath the button that was dragged:
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
            // Toggle editing mode:
            editMode = !editMode;
            if (editMode) {
                btnEdit.Text = "Sav&e Changes";
                btnEdit.BackColor = Color.Yellow;
            } else {
                btnEdit.Text = "&Edit Buttons";
                btnEdit.BackColor = Color.FromKnownColor(KnownColor.Control);
                RecalculateMatrix();
                SaveSettings();
            }
        }

        private void PnlButtons_Resize(object sender, EventArgs e) {

            // Redraw the matrix of buttons whenever the form is resized:
            foreach (string line in File.ReadAllLines(Path.Combine(Application.StartupPath, MenuForm.TEMPLATE_FOLDER_NAME, MenuForm.selectedTemplate, MenuForm.SETTINGS_FILE_NAME))) {
                if (line.ToLower().Contains("matrix data")) {
                    ReloadButtons(bm.GetMatrixData());
                }
            }
        }

        private void BtnBack_Click(object sender, EventArgs e) {
            Close();
        }

        private void BtnSpeak_Click(object sender, EventArgs e) {

            // Create a Speech object to pronounce words based on their text contents:
            narrator = new SpeechSynthesizer();
            if (emphasizable.Contains(txtSpeechBar.Text)) {
                narrator.SpeakSsmlAsync("<speak version=\"1.0\" xmlns=\"http://www.w3.org/2001/10/synthesis\" xml:lang=\"en-US\"><emphasis>" + txtSpeechBar.Text + "</emphasis></speak>");
            } else {
                narrator.SpeakAsync(txtSpeechBar.Text);

                // Add the word to emphasizable list, which is also removed from said list after a few seconds:
                emphasizable.Add(txtSpeechBar.Text);
                coolDown.Start();
            }
            clearTextOnNextPress = true;
            lastPhraseSpoken = txtSpeechBar.Text;
        }

        private void BtnClear_Click(object sender, EventArgs e) {
            txtSpeechBar.Clear();
        }

        private void BtnRepeat_Click(object sender, EventArgs e) {

            // Repeat the last phrase just spoken:
            txtSpeechBar.Text = lastPhraseSpoken;
            txtSpeechBar.Text = txtSpeechBar.Text.Trim();
            btnSpeak.PerformClick();
        }

        private void TxtSpeechBar_KeyDown(object sender, KeyEventArgs e) {

            // Use Enter to trigger the Speak button:
            if (e.KeyCode == Keys.Enter) {
                e.Handled = true;
                btnSpeak.PerformClick();
            }
        }

        private void TxtSpeechBar_HelpRequested(object sender, HelpEventArgs hlpevent) {
            MenuForm.ShowHelp("This textbox will fill with words clicked from the word matrix. It is spoken when the \"Speak\" button is pressed.");
        }

        private void BtnSpeak_HelpRequested(object sender, HelpEventArgs hlpevent) {
            MenuForm.ShowHelp("Press this button to speak the text in the textbox.");
        }

        private void BtnClear_HelpRequested(object sender, HelpEventArgs hlpevent) {
            MenuForm.ShowHelp("Press this to clear the textbox of all words.");
        }

        private void BtnRightPanel_HelpRequested(object sender, HelpEventArgs hlpevent) {
            MenuForm.ShowHelp("Pressing any of the buttons in the right panel will immediately speak it aloud. These buttons can't be changed for safety reasons.");
        }

        private void BtnBack_HelpRequested(object sender, HelpEventArgs hlpevent) {
            MenuForm.ShowHelp("Go back to the previous menu.");
        }

        private void BtnOnScreenKeyboard_HelpRequested(object sender, HelpEventArgs hlpevent) {
            MenuForm.ShowHelp("Press this to show an on-screen keyboard (must be running Windows 10 or newer).");
        }

        private void BtnEdit_HelpRequested(object sender, HelpEventArgs hlpevent) {
            MenuForm.ShowHelp("Press this button to change the position, imagery, text, or word associations with the word matrix. Buttons can be edited when this button is yellow.");
        }

        private void BtnRepeat_HelpRequested(object sender, HelpEventArgs hlpevent) {
            MenuForm.ShowHelp("Repeat the last spoken phrase.");
        }

        private void BtnHelp_HelpRequested(object sender, HelpEventArgs hlpevent) {
            MenuForm.ShowHelp("This is a universal help button that's always available in the bottom right corner.");
        }

        private void PnlButtons_HelpRequested(object sender, HelpEventArgs hlpevent) {
            MenuForm.ShowHelp("Press any of these buttons to add the text to the textbox at the top of the window. Alternatively, press \"Edit Buttons\" and then click a button to modify it.");
        }

        private void TemplateForm_FormClosing(object sender, FormClosingEventArgs e) {
            SaveSettings();
        }
    }
}
