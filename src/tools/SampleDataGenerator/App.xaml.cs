using System.Configuration;
using System.Data;
using System.Windows;

namespace SampleDataGenerator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            int seed = 15646;
            Workspace.InitSampleDataGenerator(seed);
        }
    }

}
