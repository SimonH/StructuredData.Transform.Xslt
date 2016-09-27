using System.ComponentModel.Composition;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Xsl;
using StructuredData.Transform.interfaces;

namespace StructuredData.Transform.Xslt
{
    [Export(typeof(ITransformStructuredData))]
    [ExportMetadata("MimeType", "text/xml")]
    [ExportMetadata("Method", "xslt")]
    public class XmlXsltStructuredDataTransformer : ITransformStructuredData
    {
        public string Transform(string sourceData, string transformData)
        {
            var transform = new XslCompiledTransform();
            using (var transformReader = XmlReader.Create(new StringReader(transformData)))
            {
                transform.Load(transformReader);
            }
            var result = new StringWriter();
            using (var sourceReader = XmlReader.Create(new StringReader(sourceData)))
            {
                transform.Transform(sourceReader, null, result);
            }
            return result.ToString();
        }
    }
}