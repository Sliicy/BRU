using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAAC.Models {
    public class ButtonModel {

        private string name;
        private System.Drawing.Bitmap image;

        public ButtonModel(string name) {
            this.name = name;
        }

        public string GetName() {
            return name;
        }

        public void SetName(string newName) {
            if (newName.Length > 0)
                name = newName;
        }
    }
}
