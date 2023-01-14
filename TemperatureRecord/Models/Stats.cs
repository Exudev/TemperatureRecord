using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureRecord.Models
{
    public record Stats
    {
        public decimal AvgTemp { get; set; }
        public decimal MaxTemp { get; set; }
        public decimal MinTemp { get; set; }


        public Stats()
        {

        }
        public Stats(decimal avgTemp, decimal maxTemp, decimal minTemp)
        {
            AvgTemp = avgTemp;
            MaxTemp = maxTemp;
            MinTemp = minTemp;
        }

    }
}