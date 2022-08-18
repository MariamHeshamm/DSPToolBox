using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class Normalizer : Algorithm
    {
        public Signal InputSignal { get; set; }
        public float InputMinRange { get; set; }
        public float InputMaxRange { get; set; }
        public Signal OutputNormalizedSignal { get; set; }

        public override void Run()
        {
            float min = InputSignal.Samples.Min();
            float max = InputSignal.Samples.Max();
                
            if (InputMaxRange == 1 && InputMinRange == 0) 
            {
                //zi = (xi – min(x)) / (max(x) – min(x))
                //OutputNormalizedSignal = InputSignal;
                for (int i = 0; i < InputSignal.Samples.Count; i++)
                {
                    InputSignal.Samples[i] = (InputSignal.Samples[i] - min) / (max - min);
                }
                OutputNormalizedSignal = InputSignal;
            }
            else if (InputMaxRange == 1 && InputMinRange == -1) 
            {
                for (int i = 0; i < InputSignal.Samples.Count; i++)
                {
                    InputSignal.Samples[i] = 2*((InputSignal.Samples[i] - min) / (max - min))-1;
                }
                OutputNormalizedSignal = InputSignal;
            }
            
            //throw new NotImplementedException();
        }
    }
}
