using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemperatureRecord.Models;

namespace TemperatureRecord.Types
{
    public class CsvFile: TemperatureTypeFile
    {
        protected override string _Format { get; init; }

        public CsvFile() => _Format = ".csv";

        public void ReadFile(string path)
        {
            var fileReading = File.ReadLines(path).ToList();
            fileReading.RemoveAt(0);
            foreach (var item in fileReading)
            {
                var div = item.Split(',');
                var meassure = div[3];
                _Temperatures.Add(decimal.Parse(meassure));

            }
        }

    }

}

