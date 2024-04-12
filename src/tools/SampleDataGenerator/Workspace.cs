using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDataGenerator
{
    internal static class Workspace
    {

        public static Generators.SampleDataGenerator MaterialDataGenerator => _MaterialDataGenerator;
        private static Generators.SampleDataGenerator _MaterialDataGenerator = new(2135);

        public static void InitSampleDataGenerator(int seed) => _MaterialDataGenerator = new Generators.SampleDataGenerator(seed);
    }
}
