using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDataGenerator.Generators
{
    internal class SampleDataGenerator
    {
        private readonly Random magneticPropertiesRandom;
        private readonly float magneticAmplitudeHeight;
        private readonly float magneticPhaseWidth;
        private readonly float magneticPhaseStartPosition;

        private readonly Random surfaceTexturePropertiesRandom;
        private readonly float surfaceTextureWidth;
        private readonly float surfaceTextureStartPosition;

        private readonly Random ultraViolateAbsorbtionPropertiesRandom;
        private readonly int ultraViolateAbsorbtionWidth;
        private readonly int ultraViolateAbsorbtionStartPosition;
        public SampleDataGenerator(int seed)
        {
            var random= new Random(seed);
            magneticPropertiesRandom = new Random(random.Next());
            magneticPhaseWidth = magneticPropertiesRandom.Next(50, 150) / 10;
            magneticPhaseStartPosition = (float)(magneticPropertiesRandom.Next((int)((Facts.MagneticPhaseMaximum-magneticPhaseWidth)*10))/10);
            magneticAmplitudeHeight = magneticPropertiesRandom.Next(100,800) / 1000f; //a height between 10%..80% of the total avianble Range.

            surfaceTexturePropertiesRandom = new Random(random.Next());
            surfaceTextureWidth = surfaceTexturePropertiesRandom.Next(0, 2000)/1000;
            surfaceTextureStartPosition = (float)(surfaceTexturePropertiesRandom.NextDouble()* Facts.SurfacxeTextureMaximum);

            ultraViolateAbsorbtionPropertiesRandom = new Random(random.Next());
            ultraViolateAbsorbtionWidth = ultraViolateAbsorbtionPropertiesRandom.Next(500, 1500);
            ultraViolateAbsorbtionStartPosition = ultraViolateAbsorbtionPropertiesRandom.Next(Facts.UVMinimum, Facts.UVMaximum - ultraViolateAbsorbtionWidth);
        }

        public MaterialProperty NextProperty()
        {
            (var amplitude, var phase) = NextMagneticValue();
            return new MaterialProperty(
                uvAbsorbatironRate: NextUVValue(),
                surfaceTexture: NextSurfaceValue(),
                magneticAmplitde: amplitude,
                MagneticPhase:phase
                );
        }

        private int NextUVValue()
        {
            return ultraViolateAbsorbtionStartPosition + ultraViolateAbsorbtionPropertiesRandom.Next(0, ultraViolateAbsorbtionWidth);
        }

        private float NextSurfaceValue()
        {
            return surfaceTextureStartPosition + surfaceTexturePropertiesRandom.NextSingle() * surfaceTextureWidth;
        }

        private (ushort amplitude, float phase) NextMagneticValue()
        {
            var x = magneticPropertiesRandom.NextSingle();
            var h = magneticAmplitudeHeight;

            var phase = magneticPhaseStartPosition + (x * magneticPhaseWidth);

            //f(x)=-4h((x-0.5)^2)+h
            var maxAmplitudeForPhase = (ushort)((-4 * h * Math.Pow(x - 0.5, 2) + h) * Facts.MagneticAmplitudeMaximum);
            var amplitude = (ushort)(maxAmplitudeForPhase * magneticPropertiesRandom.NextSingle());

            return (amplitude, phase);
        }

    }
}
