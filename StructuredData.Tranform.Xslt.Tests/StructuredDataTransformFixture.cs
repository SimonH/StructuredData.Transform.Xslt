using System.Xml.Linq;
using NUnit.Framework;
using StructuredData.Transform;

namespace StructuredData.Tranform.Xslt.Tests
{
    [TestFixture]
    public class StructuredDataTransformFixture
    {
        [Test]
        public void SimpleTransformation()
        {
            var xml = new XElement("TestRoot", new XElement("Value", "Initial"));
            var transform = @"<?xml version=""1.0""?><xsl:stylesheet xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"" version=""1.0"">
<xsl:template match=""/TestRoot"">
<TestRoot><Value>Replaced</Value></TestRoot>
</xsl:template>
</xsl:stylesheet>";
            var expected = new XElement("TestRoot", new XElement("Value", "Replaced"));
            var candidate = xml.ToString().Transform(transform, "text/xml", "xslt");
            Assert.That(XElement.Parse(candidate).ToString(), Is.EqualTo(expected.ToString()));
        }
    }
}