using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TemperatureRecord.Models
{
    [XmlRoot(ElementName = "row")]

    public record Temp
    {

        [XmlElement(ElementName = "id")]
        public int Id { get; set; }
        [XmlElement(ElementName = "location")]
        public string Location { get; set; } = null!;
        [XmlElement(ElementName = "date")]
        public DateTime Date { get; set; }
        [XmlElement(ElementName = "meassure")]
        public decimal Meassure { get; set; }

    }


}
