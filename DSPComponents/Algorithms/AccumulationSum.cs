using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;


namespace DSPAlgorithms.Algorithms
{
    public class AccumulationSum : Algorithm
    {
        public Signal InputSignal { get; set; }
        public Signal OutputSignal { get; set; }

        public override void Run()
        {
            OutputSignal = new DSPAlgorithms.DataStructures.Signal(new List<float>() { }, false);
            int sum = 0;
            for (int i = 0; i < InputSignal.Samples.Count; i++)
            {
                if (i == 0)
                {
                    OutputSignal.Samples.Add(InputSignal.Samples[i]);

                }
                else
                {
                    OutputSignal.Samples.Add(InputSignal.Samples[i] + OutputSignal.Samples[i - 1]);

                }
            }

            //  throw new NotImplementedException();
        }
    }
}
