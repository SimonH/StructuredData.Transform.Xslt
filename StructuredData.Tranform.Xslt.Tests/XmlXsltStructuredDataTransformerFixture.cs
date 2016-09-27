using System.Xml.Linq;
using NUnit.Framework;
using StructuredData.Transform.Xslt;

namespace StructuredData.Tranform.Xslt.Tests
{
    [TestFixture]
    public class XmlXsltStructuredDataTransformerFixture
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
            var candidate = new XmlXsltStructuredDataTransformer().Transform(xml.ToString(), transform);
            Assert.That(XElement.Parse(candidate).ToString(), Is.EqualTo(expected.ToString()));
        }
    }
}