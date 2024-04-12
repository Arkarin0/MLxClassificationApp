using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SampleDataGenerator.Generators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SampleDataGenerator.UI
{
    public partial class MainViewModel : ObservableObject
    {
        public ICommand GenerateSampleData { get; }
        private readonly Generators.SampleDataGenerator ProbabilityGenerator;

        public MainViewModel()
        {
            this.ProbabilityGenerator = Workspace.MaterialDataGenerator;

            GenerateSampleData= new RelayCommand(GenerateData);
        }

        [ObservableProperty]
        private int _SampleCount=10000;

        [ObservableProperty]
        private string[] _sampleNames= new []{ "Metal","Wood","Plastic","Textiles","Glas","Paper","Rubber","Electronics" };


        private void GenerateData()
        {
            var rdm = new Random(1235);
            foreach (var name in SampleNames)
            {
                var data = new List<MaterialProperty>();
                var generator = new Generators.SampleDataGenerator(rdm.Next(65535));
                for (int i = 0; i < this.SampleCount; i++)
                {
                    data.Add(generator.NextProperty());
                }
                Exporter.ExportMaterialProperty(name, data, "tempData.csv");
            }
            

            
        }
    }
}
