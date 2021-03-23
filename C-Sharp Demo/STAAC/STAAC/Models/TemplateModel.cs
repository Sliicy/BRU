using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STAAC.Models {
    public class TemplateModel {

        private string name;
        private string author;
        private string category;
        private string colorScheme;

        // String representation of matrix:
        private string matrixData;

        // Contains dimensions of matrix:
        private int matrixWidth = 1;
        private int matrixHeight = 1;

        public TemplateModel(string name) {
            this.name = name;
            colorScheme = "None";
        }

        public TemplateModel(string name, int matrixWidth, int matrixHeight) {
            this.name = name;
            colorScheme = "None";
            if (matrixWidth > 0) {
                this.matrixWidth = matrixWidth;
            } else {
                throw new ArgumentOutOfRangeException("Matrix size must be at least 1x1.");
            }
            if (matrixHeight > 0) {
                this.matrixHeight = matrixHeight;
            } else {
                throw new ArgumentOutOfRangeException("Matrix size must be at least 1x1.");
            }
        }

        public string GetName() {
            return name;
        }

        public void SetName(string newName) {
            if (newName != null) {
                if (newName.Length > 0)
                    name = newName;
            }
        }

        public string GetAuthor() {
            return author;
        }

        public void SetAuthor(string author) {
            this.author = author;
        }

        public string GetCategory() {
            return category;
        }

        public void SetCategory(string category) {
            this.category = category;
        }

        public string GetColorScheme() {
            return colorScheme;
        }

        public void SetColorScheme(string colorScheme) {
            this.colorScheme = colorScheme;
        }

        public int GetMatrixWidth() {
            return matrixWidth;
        }

        public void SetMatrixWidth(int matrixWidth) {
            this.matrixWidth = matrixWidth;
        }

        public int GetMatrixHeight() {
            return matrixHeight;
        }

        public void SetMatrixHeight(int matrixHeight) {
            this.matrixHeight = matrixHeight;
        }

        public string GetMatrixData() {
            return matrixData;
        }

        public void SetMatrixData(string matrixData) {
            if (!matrixData.StartsWith("Matrix Data=")) {
                throw new ArgumentException("Matrix Data must start with \"Matrix Data=\"");
            }
            this.matrixData = matrixData;
        }
    }
}
