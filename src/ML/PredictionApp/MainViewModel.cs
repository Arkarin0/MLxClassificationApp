using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Learner;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredictionApp
{
    public partial class MainViewModel:ObservableObject
    {
        [ObservableProperty]
        int _UVValue= 5_000;

        [ObservableProperty]
        float _surfaceTexture=10f;

        [ObservableProperty]
        ushort _magneticApmlitude=35_000;

        [ObservableProperty]
        float _magneticPhase=180f;

        [ObservableProperty]
        string _result;

        public MainViewModel()
        {
            
        }

        [RelayCommand]
        private void Predict()
        {
            //Load sample data
            var sampleData = new ClassificationAppModel.ModelInput()
            {
                Col1 = this.SurfaceTexture,
                Col2 = this.UVValue,
                Col3 = this.MagneticPhase,
                Col4 = this.MagneticApmlitude,
            };

            //Load model and predict output
            var result = ClassificationAppModel.Predict(sampleData);
            var labels= ClassificationAppModel.GetSortedScoresWithLabels(result);

            this.Result =
                $"winner:\t{result.PredictedLabel}\n\n" + 
                string.Join("\n", labels.Where(v=> v.Value>0.0001).Select((v) => $"{v.Key,-12}\t: {v.Value*100,5:00.00}%"));

        }
    }
}
