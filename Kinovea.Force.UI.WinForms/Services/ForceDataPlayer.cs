using Kinovea.Force;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinovea.Force.UI.WinForms.Services
{
    public class ForceDataPlayer
    {
        public List<ForceMeasurement> Measurements { get; private set; }
        public Action<List<ForceMeasurement>> MeasurementsLoaded;

        public ForceDataPlayer() { }

        public void Load(string fileName)
        {
            FileName = fileName;
            if (File.Exists(fileName))
            {
                Measurements = JsonConvert.DeserializeObject<List<ForceMeasurement>>(File.ReadAllText(fileName));
                MeasurementsLoaded?.Invoke(Measurements);
            }
        }

        public string FileName { get; set; }

        public string FilePath
        {
            get
            {
                if (!string.IsNullOrEmpty(FileName))
                {
                    return Path.GetFullPath(FileName);
                }
                return string.Empty;
            }
        }

        public bool Loaded { get; set; }
    }
}
