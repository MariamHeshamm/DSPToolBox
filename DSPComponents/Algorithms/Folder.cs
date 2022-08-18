using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class Folder : Algorithm
    {
        public Signal InputSignal { get; set; }
        public Signal OutputFoldedSignal { get; set; }

        public override void Run()
        {
            //        public Signal(List<float> _SignalSamples, bool _periodic, List<float> _SignalFrequencies, List<float> _SignalFrequenciesAmplitudes, List<float> _SignalFrequenciesPhaseShifts)

            InputSignal.Frequencies = new List<float>();
            OutputFoldedSignal = new DSPAlgorithms.DataStructures.Signal(new List<float>() { }, false, new List<float>(), new List<float>(), new List<float>());
            for (int i = InputSignal.Samples.Count - 1; i > -1; i--)
            {
                OutputFoldedSignal.Samples.Add(InputSignal.Samples[i]);
                OutputFoldedSignal.SamplesIndices.Add(InputSignal.SamplesIndices[i] * -1);
            }
            //for (int i = 0; i < InputSignal.Samples.Count; i++)
            //{

            //}
            if (InputSignal.Periodic == true)
            {
                OutputFoldedSignal.Periodic = false;
            }
            else
                OutputFoldedSignal.Periodic = true;

            //  OutputFoldedSignal.Frequencies.Add(1);
            //if (InputSignal.Frequencies.Add)
            //{
            //    OutputFoldedSignal.Frequencies.Add(1);
            //}
            //else
            //    OutputFoldedSignal.Frequencies.Clear();

        }
    }
}
