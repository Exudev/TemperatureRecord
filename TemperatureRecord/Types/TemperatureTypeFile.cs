using CsvHelper;
using System.Globalization;
using System.Reflection.PortableExecutable;
using TemperatureRecord.Models;

namespace TemperatureRecord.Types
{
    public abstract class TemperatureTypeFile
    {
        protected abstract string _Format { get; init; }
        protected IList<decimal> _Temperatures { get; set; }

        protected TemperatureTypeFile()
        {
            _Format = ".csv";
            _Temperatures = new List<decimal>();
        }

        public Stats Analyze()
        {

            decimal AvgTemperature = Math.Round(_Temperatures.Average(), 2);
            decimal MaxTemperature = _Temperatures.Max();
            decimal MinTemperature = _Temperatures.Min();

            return new(AvgTemperature, MaxTemperature, MinTemperature);
        }
        protected virtual bool IsEmpty(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                Console.WriteLine("---File is empty---");
                return false;
            }
            else
                return true;
        }
        protected virtual bool CheckFileType(string path)
        {
            if (path[^4..] != _Format)
            {
                Console.WriteLine("---File not an : " + _Format + "---");
                return false;
            }
            else
                return true;
        }
        public virtual void OpenDirectory(string path)
        {
            _Temperatures.Clear();
            
            if (IsEmpty(path) && CheckFileType(path))
            {
                try
                {
                    DeserializeFile(path, out IEnumerable<Temp> csv);

                    foreach (var temp in csv)
                        _Temperatures.Add(temp.Meassure);
                }
                catch (Exception error)
                {
                    Console.WriteLine(error.Message);
                }
            }
            else
                Environment.Exit(1);
            
     
        }
        protected virtual void DeserializeFile(string path, out IEnumerable<Temp> csv)
        {
            var file = new StreamReader(path);
            file.Read();
            var Reader = new CsvReader(file, CultureInfo.InvariantCulture);
            Reader.Read();
            csv = Reader.GetRecords<Temp>()!;
            
        }
       
    }
}
        
