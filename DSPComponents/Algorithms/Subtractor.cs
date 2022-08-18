using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class Subtractor : Algorithm
    {
        public Signal InputSignal1 { get; set; }
        public Signal InputSignal2 { get; set; }
        public Signal OutputSignal { get; set; }

        /// <summary>
        /// To do: Subtract Signal2 from Signal1 
        /// i.e OutSig = Sig1 - Sig2 
        /// </summary>
        public override void Run()
        {
            OutputSignal = InputSignal2;
            for (int i = 0; i < InputSignal2.Samples.Count; i++)
            {
                OutputSignal.Samples[i] *= -1;
            }
            float sum_sample = 0;
            for (int j = 0; j < InputSignal1.Samples.Count; j++)
            {
                sum_sample = InputSignal1.Samples[j] + InputSignal2.Samples[j];
                OutputSignal.Samples[j] = sum_sample;
            }
           
          

                
           
           // throw new NotImplementedException();
        }
    }
}