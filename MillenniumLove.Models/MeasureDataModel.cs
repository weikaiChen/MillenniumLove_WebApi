using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MillenniumLove.Models
{
    public class MeasureDataModel
    {
        public string OpMid { get; set; }
        public string MeasureTime { get; set; }
        public string MeasureCity { get; set; }
        public string MeasureDistrict { get; set; }
        public decimal? Height { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Waist { get; set; }
        public decimal? BMI { get; set; }
        public decimal? SystolicPressure { get; set; }
        public decimal? DiastolicPressure { get; set; }
        public decimal? HeartRate { get; set; }
        public decimal? BodyTemperature { get; set; }
        public decimal? BodyFatRatio { get; set; }

    }
}
