using DSPAlgorithms.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPAlgorithms.Algorithms
{
    public class DCT: Algorithm
    {
        public Signal InputSignal { get; set; }
        public Signal OutputSignal { get; set; }

        public override void Run()
        {
            
            double N = InputSignal.Samples.Count;
            OutputSignal = new Signal(new List<float>(), false);
            for (int k = 0; k < N; k++)
            {
                double sum = 0;
                for (int n = 0; n < N; n++)
                {
                    sum += InputSignal.Samples[n] * Math.Cos((((2*n)+1)*k*Math.PI)/(2*N));
                }
                if (k == 0)
                   sum = sum * Math.Sqrt(1.0 / N);
                else
                   sum = sum * Math.Sqrt(2.0 / N);
                OutputSignal.Samples.Add((float)sum);
            }
           // throw new NotImplementedException();
        }
    }
}
