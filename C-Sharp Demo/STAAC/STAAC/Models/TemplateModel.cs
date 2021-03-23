using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAAC.Models {
    public class TemplateModel {

        private string name;

        public string Author { get; set; }
        public string Category { get; set; }
        public string ColorScheme { get; set; }

        // String representation of matrix:
        public string MatrixData { get; set; }

        // Contains dimensions of matrix:
        public int matrixWidth = 1;
        public int matrixHeight = 1;

        public TemplateModel(string name) {
            this.name = name;
            ColorScheme = "None";
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
