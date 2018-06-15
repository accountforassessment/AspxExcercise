using System.Xml.Serialization;

namespace AspxExample.Models
{
    public class Sub
    {
        [XmlElement("SubmissionID")]
        public long SubmissionId { get; set; }
        [XmlElement("SubmissionNumber")]
        public string SubmissionNumber { get; set; }
        [XmlAttribute("Type")]
        public string Type { get; set; }
    }
}