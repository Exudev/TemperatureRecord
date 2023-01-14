using Newtonsoft.Json;
using TemperatureRecord.Models;

namespace TemperatureRecord.Types
{
    public class JsonFile : TemperatureTypeFile
    {
        protected override string _Format { get; init; }

        public JsonFile() => _Format = ".json";
        public override void OpenDirectory(string path)
        {   
            _Temperatures.Clear();
            
            if(CheckFileType(path) && IsEmpty(path))
            try
            {
                DeserializeFile(path, out IEnumerable<Temp> json);

                foreach (var temp in json)
                    _Temperatures.Add(temp.Meassure);
             
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                 
            }else
                Environment.Exit(1);
        }

        protected override bool CheckFileType(string path)
        {
            if (path[^5..] != _Format)
            {
                Console.WriteLine("---File not an : " + _Format + "---");
                return false;
            }
            else
                return true;
        }

        protected override void DeserializeFile(string path, out IEnumerable<Temp> json)
        {
            var file = new StreamReader(path);
            var data = file.ReadToEnd()
                .Trim();

            json = JsonConvert.DeserializeObject<IEnumerable<Temp>>(data)!;
        }
        
    }
}