using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class DirectConvolution : Algorithm
    {
        public Signal InputSignal1 { get; set; }
        public Signal InputSignal2 { get; set; }
        public Signal OutputConvolvedSignal { get; set; }

        /// <summary>
        /// Convolved InputSignal1 (considered as X) with InputSignal2 (considered as H)
        /// </summary>
        public override void Run()
        {
            Dictionary<int, float> x = new Dictionary<int, float>();
            Dictionary<int, float> h = new Dictionary<int, float>();
            OutputConvolvedSignal = new Signal(new List<float>(),new List<int>(),false);

            for (int i = 0; i < InputSignal1.Samples.Count; i++) 
            {
                x.Add(InputSignal1.SamplesIndices[i], InputSignal1.Samples[i]);
            }

            for (int i = 0; i < InputSignal2.Samples.Count; i++)
            {
                h.Add(InputSignal2.SamplesIndices[i], InputSignal2.Samples[i]);
            }

            int min_range = InputSignal1.SamplesIndices[0] + InputSignal2.SamplesIndices[0];

            int N1 = InputSignal1.SamplesIndices.Count - 1;
            int N2 = InputSignal2.SamplesIndices.Count - 1;
            int max_range = InputSignal1.SamplesIndices[N1] + InputSignal2.SamplesIndices[N2];

            float sum = 0;
            for (int n = min_range; n <= max_range; n++) 
            {
                sum = 0;
                int k = x.Keys.Min();//bbtdy 3ala 7asab 2a2l index fl x
                for (; ;) 
                {
                    if (n - k > h.Keys.Max()) //hna b2a lw 3adet elmax index fel h
                    {
                        k++;
                        continue;
                    }
                    try
                    {
                        sum += x[k] * h[n - k];
                        k++;
                    }
                    catch
                    {
                        //hyd5ol flcatch lw la2a k mlhash key aslun
                        OutputConvolvedSignal.Samples.Add(sum);
                        OutputConvolvedSignal.SamplesIndices.Add(n);
                        break;
                    }
                }
            }





            int index = OutputConvolvedSignal.Samples.Count - 1;//ab2a ns2l feha l2n elmford ytl3 zero 3ady w leha index
            if (OutputConvolvedSignal.Samples[index] == 0) 
            {
                OutputConvolvedSignal.Samples.RemoveAt(index);
                OutputConvolvedSignal.SamplesIndices.RemoveAt(index);
            }
           // throw new NotImplementedException();
        }
    }
}
