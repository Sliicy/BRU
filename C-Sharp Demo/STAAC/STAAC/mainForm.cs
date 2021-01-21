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

namespace STAAC {
    public partial class MainForm : Form {

        // List of words that the user is angry about (deliberately repeatedly pressing):
        List<string> emphasizable = new List<string>();

        public MainForm() {
            InitializeComponent();
        }

        SpeechSynthesizer narrator;

        private void MainForm_Load(object sender, EventArgs e) {

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
    }
}
