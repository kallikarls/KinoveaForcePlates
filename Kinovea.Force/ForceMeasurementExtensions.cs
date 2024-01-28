using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

namespace Kinovea.Force
{
    public static class ForceMeasurementExtensions
    {
        public static ForceMeasurement ToForceMeasurement(this string measurementValue)
        {
            ForceMeasurement measurement = new ForceMeasurement();
            if (!string.IsNullOrEmpty(measurementValue))
            {
                string[] msgContent = measurementValue.Split(';');
                if (msgContent != null && msgContent.Length > 0)
                {
                    foreach (string fld in msgContent)
                    {
                        string[] fldContent = fld.Split('=');
                        if (fldContent.Length == 2)
                        {
                            string fldName = fldContent[0];
                            if (fldName.StartsWith("SEQ"))
                            {
                                if (int.TryParse(fldContent[1], out int sequenceNumber))
                                {
                                    measurement.SequenceNumber = sequenceNumber;
                                }
                            }
                            else if (fldName.StartsWith("ADC"))
                            {
                                if (float.TryParse(fldContent[1], NumberStyles.Number, CultureInfo.InvariantCulture, out float adc))
                                {
                                    measurement.ADC = adc;
                                }
                            }
                        }
                    }
                }
            }
            return measurement;
        }
    }
}
