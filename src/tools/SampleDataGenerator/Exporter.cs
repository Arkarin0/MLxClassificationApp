using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDataGenerator
{
    internal static class Exporter
    {
        public static void ExportNoiseMap(float[,] noiseMap, string fullFilepath)
        {
            using (var fs = File.OpenWrite(fullFilepath))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                string format = "{0},{1},{2}";

                string Format(object a, object b, object c) => string.Format(CultureInfo.InvariantCulture, format, a, b, c);
                sw.WriteLine(Format("x", "y", "value"));


                for(int x=0; x < noiseMap.GetLength(0); x++)
                    for( int y=0 ; y < noiseMap.GetLength(1); y++)
                    {

                        sw.WriteLine(Format(x, y, noiseMap[x, y]));
                    }

                fs.Flush();
            }
        }

        public static void ExportNoiseMap(float[] noiseMap, string fullFilepath)
        {
            using (var fs = File.OpenWrite(fullFilepath))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                string format = "{0},{1}";

                string Format(object a, object b) => string.Format(CultureInfo.InvariantCulture, format, a, b);
                sw.WriteLine(Format("value", "probability"));


                for (int x = 0; x < noiseMap.GetLength(0); x++)
                   sw.WriteLine(Format(x, noiseMap[x]));
                   

                fs.Flush();
            }
        }

        public static void ExportMaterialProperty(string label,IEnumerable<MaterialProperty> data, string fullFilepath)
        {
            using (StreamWriter sw = File.AppendText(fullFilepath))
            {
                string format = "{0},{1},{2},{3},{4}";

                string Format(object a, object b, object c, object d, object e) => string.Format(CultureInfo.InvariantCulture, format, a, b, c, d, e);
                //no header
                //sw.WriteLine(Format("label", nameof(MaterialProperty.surfaceTexture), nameof(MaterialProperty.uvAbsorbatironRate), nameof(MaterialProperty.MagneticPahse), nameof(MaterialProperty.magneticAmplitde)));


                foreach (var prop in data)
                    sw.WriteLine(Format(label, prop.surfaceTexture, prop.uvAbsorbatironRate, prop.MagneticPhase, prop.magneticAmplitde));


                sw.Flush();
            }
        }
    }
}
