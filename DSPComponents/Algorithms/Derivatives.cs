using DSPAlgorithms.DataStructures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPAlgorithms.Algorithms
{
    public class Derivatives : Algorithm
    {
        public Signal InputSignal { get; set; }
        public Signal FirstDerivative { get; set; }
        public Signal SecondDerivative { get; set; }

        public override void Run()
        {
            FirstDerivative = new DSPAlgorithms.DataStructures.Signal(new List<float>() { }, false);
            SecondDerivative = new DSPAlgorithms.DataStructures.Signal(new List<float>() { }, false);
            Signal Signal1 = new DSPAlgorithms.DataStructures.Signal(new List<float>() { }, false);
            Signal Signal2 = new DSPAlgorithms.DataStructures.Signal(new List<float>() { }, false);
            Signal Signal3 = new DSPAlgorithms.DataStructures.Signal(new List<float>() { }, false);
            for (int i = 0; i < InputSignal.Samples.Count; i++)
            {
                Signal1.SamplesIndices.Add(InputSignal.SamplesIndices[i]);
                Signal1.Samples.Add(InputSignal.Samples[i]);

                Signal2.SamplesIndices.Add(InputSignal.SamplesIndices[i] - 1);
                Signal2.Samples.Add(InputSignal.Samples[i]);

                Signal3.SamplesIndices.Add(InputSignal.SamplesIndices[i] + 1);
                Signal3.Samples.Add(InputSignal.Samples[i]);
            }
            for (int i = 1; i < InputSignal.Samples.Count; i++)
            {
                FirstDerivative.Samples.Add(Signal1.Samples[i] - Signal2.Samples[i - 1]);
                FirstDerivative.SamplesIndices.Add(i - 1);
            }

            for (int i = 1; i < InputSignal.Samples.Count; i++)
            {
                if (i == InputSignal.Samples.Count - 1)
                {
                    i = i - 1;
                    SecondDerivative.Samples.Add(Signal3.Samples[i + 1] - (2 * Signal1.Samples[i]) + Signal2.Samples[i - 1]);
                    SecondDerivative.SamplesIndices.Add(i - 1 + 1);
                    break;

                }
                SecondDerivative.Samples.Add(Signal3.Samples[i + 1] - (2 * Signal1.Samples[i]) + Signal2.Samples[i - 1]);
                SecondDerivative.SamplesIndices.Add(i - 1);
            }

            //throw new NotImplementedException();
        }
    }
}
