// See https://aka.ms/new-console-template for more information
using Learner;

Console.WriteLine("Hello, We will now start learning the data.");

string resultFile = Path.Join(Directory.GetCurrentDirectory(), "mlModel.zip");
ClassificationAppModel.Train(resultFile);
Console.WriteLine($"training finished. Model saved to '{resultFile}'.");
