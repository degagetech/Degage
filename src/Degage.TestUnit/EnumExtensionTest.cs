using Microsoft.VisualStudio.TestTools.UnitTesting;
using Degage.Extension;
namespace Degage.TestUnit
{
    [TestClass]
    public class EnumExtensionTest
    {
        [TestMethod]
        public void GetEnumSchemaByAttribute()
        {
         
            var enumText = TestEunum.Test1.EnumText();
            var enumColor = TestEunum.Test1.EnumColor();

            if (enumText.IsNullOrEmpty())
            {
                Assert.Fail();
            }

            if (!enumColor.HasValue)
            {
                Assert.Fail();
            }
        }
    }
    public enum TestEunum
    {
        [EnumText("Test1")]
        [EnumColor(244, 244, 244)]
        Test1
    }
}
