using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAAC.Models {
    public class ButtonModel {

        private string name;
        private Bitmap image;

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

        public Bitmap GetImage() {
            return image;
        }

        public void SetImage(Bitmap image) {
            this.image = image;
        }
    }
}
