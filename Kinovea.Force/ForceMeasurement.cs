using System;
using System.Collections.Generic;
using System.Text;

namespace Kinovea.Force
{
    public class ForceMeasurement
    {
        public long SequenceNumber { get; set; }
        public long TimeMs { get; set; }
        public double ADC {  get; set; }
        public double LoadPercentage { get; set; }
    }
}
