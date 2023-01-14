using System.Xml.Serialization;
using TemperatureRecord.Models;

namespace TemperatureRecord.Types
{
    public class XmlFile : TemperatureTypeFile
    {
        protected override string _Format { get; init; }

        public XmlFile() => _Format = ".xml";

        public override void OpenDirectory(string path)
        {
            _Temperatures.Clear();
            
           
            if (IsEmpty(path) && CheckFileType(path))
            {
                try
                {
                    var file = new StreamReader(path);
                    var xmlSerializer = new XmlSerializer(typeof(TempList));
                    TempList xml = (TempList)xmlSerializer.Deserialize(file)!;
                    foreach (var temp in xml.lista)
                        _Temperatures.Add(temp.Meassure);
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                }
            }else
                Environment.Exit(1);

        }
    }
}