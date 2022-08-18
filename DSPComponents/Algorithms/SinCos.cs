using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class SinCos: Algorithm
    {
        public string type { get; set; }
        public float A { get; set; }
        public float PhaseShift { get; set; }
        public float AnalogFrequency { get; set; }
        public float SamplingFrequency { get; set; }
        public List<float> samples { get; set; }
        public override void Run()
        {

            if (type == "cos") 
            {
                samples = new List<float>();
                for (int i = 0; i < SamplingFrequency; i++) 
                {
                    double result = A * Math.Cos((2 * Math.PI * i * AnalogFrequency / SamplingFrequency) + PhaseShift); 
                    samples.Add((float)Math.Round(result,6));
                }
            }
            else if (type == "sin") 
            {
                samples = new List<float>();
                for (int i = 0; i < SamplingFrequency; i++)
                {
                    double result = A * Math.Sin((2 * Math.PI * i * AnalogFrequency / SamplingFrequency) + PhaseShift);
                    samples.Add((float)Math.Round(result, 6));
                }
            }
          //  throw new NotImplementedException();
        }
    }
}
