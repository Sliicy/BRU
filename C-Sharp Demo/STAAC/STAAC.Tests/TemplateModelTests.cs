using System;
using Xunit;
using STAAC;
using STAAC.Models;

namespace STAAC.Tests {
    public class TemplateModelTests {

        // Test that the SetName() function is able to change the name for Templates.
        [Theory]
        [InlineData("test", "")]
        [InlineData("test", null)]
        [InlineData("test", "1")]
        public void SetName_NameShouldNotBeNull(string initial, string change) {
            // Arrange:
            TemplateModel b = new TemplateModel(initial);

            // Act:
            b.SetName(change);

            // Assert:
            Assert.True(b.GetName().Length > 0);
        }

        // Test that the GetName() function is able to get the name for Templates.
        [Theory]
        [InlineData("test")]
        [InlineData("pizza")]
        [InlineData("!%(&#")]
        public void GetName_ShouldReturnName(string initial) {
            // Arrange:
            TemplateModel b = new TemplateModel(initial);

            // Assert:
            Assert.True(b.GetName().Equals(initial));
        }

        // Test that trying to create a Template with incorrect sizes will throw an error.
        [Theory]
        [InlineData(0, 0)]
        [InlineData(-1, -100)]
        [InlineData(int.MinValue, int.MaxValue)]
        public void TemplateModel_MatrixShouldThrowIfIncorrectSize(int incorrectWidth, int incorrectHeight) {
            // Arrange:
            string initialName = "test";
            TemplateModel b;

            // Act:
            Assert.Throws<ArgumentOutOfRangeException>(() => b = new TemplateModel(initialName, incorrectWidth, incorrectHeight));
        }

        // Test that the GetAuthor() function returns the author's name for the Template.
        [Theory]
        [InlineData("test")]
        [InlineData("")]
        public void GetAuthor_ShouldReturnAuthor(string initialAuthor) {
            // Arrange:
            TemplateModel b = new TemplateModel("test");

            // Act:
            b.SetAuthor(initialAuthor);

            // Assert:
            Assert.True(b.GetAuthor().Equals(initialAuthor));
        }

        // Test that the SetAuthor() function sets the author's name for the Template.
        [Theory]
        [InlineData("test")]
        [InlineData("")]
        public void SetAuthor_ShouldChangeAuthor(string initialAuthor) {
            // Arrange:
            TemplateModel b = new TemplateModel("test");

            // Act:
            b.SetAuthor(initialAuthor);

            // Assert:
            Assert.True(b.GetAuthor().Equals(initialAuthor));
        }

        // Test that the GetCategory() function gets the category name for the Template.
        [Theory]
        [InlineData("test")]
        [InlineData("")]
        public void GetCategory_ShouldReturnCategory(string initialCategory) {
            // Arrange:
            TemplateModel b = new TemplateModel("test");

            // Act:
            b.SetCategory(initialCategory);

            // Assert:
            Assert.True(b.GetCategory().Equals(initialCategory));
        }

        // Test that the SetCategory() function sets the category name for the Template.
        [Theory]
        [InlineData("test")]
        [InlineData("")]
        public void SetCategory_ShouldChangeCategory(string initialCategory) {
            // Arrange:
            TemplateModel b = new TemplateModel("test");

            // Act:
            b.SetCategory(initialCategory);

            // Assert:
            Assert.True(b.GetCategory().Equals(initialCategory));
        }

        // Test that the GetColorScheme() function gets the color for the Template's buttons.
        [Theory]
        [InlineData("none")]
        [InlineData("None")]
        [InlineData("")]
        [InlineData("Red")]
        public void GetColorScheme_ShouldReturnColorScheme(string initialColorScheme) {
            // Arrange:
            TemplateModel b = new TemplateModel("test");

            // Act:
            b.SetColorScheme(initialColorScheme);

            // Assert:
            Assert.True(b.GetColorScheme().Equals(initialColorScheme));
        }

        // Test that the SetColorScheme() function sets the color for the Template's buttons.
        [Theory]
        [InlineData("none")]
        [InlineData("None")]
        [InlineData("")]
        [InlineData("Red")]
        public void SetColorScheme_ShouldChangeColorScheme(string initialColorScheme) {
            // Arrange:
            TemplateModel b = new TemplateModel("test");

            // Act:
            b.SetColorScheme(initialColorScheme);

            // Assert:
            Assert.True(b.GetColorScheme().Equals(initialColorScheme));
        }

        // Test that the GetMatrixData() function returns a matrix containing a list of buttons for the Template.
        [Theory]
        [InlineData("Matrix Data=pizza,cheese")]
        [InlineData("Matrix Data=null")]
        [InlineData("Matrix Data=0")]
        [InlineData("Matrix Data=")]
        public void GetMatrixData_ShouldReturnMatrixDataWithEqualSymbol(string initial) {
            // Arrange:
            TemplateModel b = new TemplateModel("test");

            // Act:
            b.SetMatrixData(initial);

            // Assert:
            Assert.True(b.GetMatrixData().Equals(initial));
            Assert.Contains("=", b.GetMatrixData());
        }

        // Test that the SetMatrixData() function sets a new matrix for the Template (which consists of a bunch of button names).
        [Theory]
        [InlineData("Matrix Data=pizza,cheese")]
        [InlineData("Matrix Data=null")]
        [InlineData("Matrix Data=0")]
        [InlineData("Matrix Data=")]
        public void SetMatrixData_ShouldChangeMatrixData(string initial) {
            // Arrange:
            TemplateModel b = new TemplateModel("test");

            // Act:
            b.SetMatrixData(initial);

            // Assert:
            Assert.True(b.GetMatrixData().Equals(initial));
        }

        // Test that the SetMatrixData() function throws an error if the input string doesn't contain the words "Matrix Data=".
        // 'Matrix Data=' is always prepended to be used to indicate the beginning of a matrix, so that the program knows
        // when reading the settings file.
        [Theory]
        [InlineData("Matrix Data")]
        [InlineData("")]
        [InlineData("=")]
        public void SetMatrixData_ShouldFailIfNoEqualSymbolContained(string initial) {
            // Arrange:
            TemplateModel b = new TemplateModel("test");

            // Act:
            Assert.Throws<ArgumentException>(() => b.SetMatrixData(initial));
        }

    }
}
