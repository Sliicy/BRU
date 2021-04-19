using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * Model used to store information about a Template.
 * Each Template has a name, author, category, color scheme, matrix data, & dimensions for building that matrix.
 */
namespace STAAC.Models {
    public class TemplateModel {

        // Holds the name of the Template:
        private string name;

        // Holds the author's name:
        private string author;
        
        // Holds the category name:
        private string category;
        
        // Holds the color scheme to use for the template:
        private string colorScheme;

        // Holds a string containing the layout of the buttons, separated by commas, and prepended with "Matrix Data=":
        private string matrixData;

        // Holds the dimensions used to build the matrix:
        private int matrixWidth = 1;
        private int matrixHeight = 1;

        // Constructor with name, and dimensions to use for the Template:
        public TemplateModel(string name, int matrixWidth, int matrixHeight) {
            this.name = name;

            // Default color scheme is none:
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
            if (newName != null)
                if (newName.Length > 0)
                    name = newName;
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
