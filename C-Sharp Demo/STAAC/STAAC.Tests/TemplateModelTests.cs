using System;
using Xunit;
using STAAC;
using STAAC.Models;

namespace STAAC.Tests {
    public class TemplateModelTests {
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
