using System;
using Xunit;
using STAAC;
using STAAC.Models;

namespace STAAC.Tests {
    public class ButtonModelTests {
        [Theory]
        [InlineData("test", "")]
        public void SetName_NameShouldNotBeNull(string initial, string change) {
            // Arrange:
            TemplateModel b = new TemplateModel(initial);

            // Act:
            b.SetName(change);

            // Assert:
            Assert.True(b.GetName().Length > 0);
        }
    }
}
