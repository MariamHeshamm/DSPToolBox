using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class QuantizationAndEncoding : Algorithm
    {
        // You will have only one of (InputLevel or InputNumBits), the other property will take a negative value
        // If InputNumBits is given, you need to calculate and set InputLevel value and vice versa
        public int InputLevel { get; set; }
        public int InputNumBits { get; set; }
        public Signal InputSignal { get; set; }
        public Signal OutputQuantizedSignal { get; set; }
        public List<int> OutputIntervalIndices { get; set; }
        public List<string> OutputEncodedSignal { get; set; }
        public List<float> OutputSamplesError { get; set; }

        public override void Run()
        {
            if (InputLevel == 0) 
            {
                InputLevel = (int)Math.Pow((double)2, (double)InputNumBits);
            }
            if(InputNumBits == 0)
            {
                InputNumBits = (int)Math.Log(InputLevel,2);
            }
            float Max_Amplitude = InputSignal.Samples.Max();
            float Min_Amplitude = InputSignal.Samples.Min();
            float delta = (Max_Amplitude - Min_Amplitude) / InputLevel;
            var Levels = new List<KeyValuePair<float, float>>();
            for (int i = 0; i < InputLevel; i++) 
            {
                Levels.Add(new KeyValuePair <float, float>(Min_Amplitude , Min_Amplitude + delta ));
                Min_Amplitude = Min_Amplitude + delta;
            }
            var Levels_count = Levels.Count;
            var MidPoints_of_levels = new List<float>();
            for (int i = 0; i < Levels_count; i++) 
            {
                float value = (Levels[i].Key + Levels[i].Value) / 2;
                MidPoints_of_levels.Add(value);
            }
            List<string> BinaryValues = new List<string>();
            for (int i = 0; i < InputLevel; i++) 
            { 
                int value = i;
                string binary = Convert.ToString(value, 2);
                BinaryValues.Add(binary);
            }
            for (int i = 0; i < BinaryValues.Count(); i++) 
            {
                while (BinaryValues[i].Count() < InputNumBits) 
                {
                    string binary = BinaryValues[i];
                    string nk =  binary.Insert(0,"0");
                    BinaryValues[i] = nk;
                }
            }
            
            OutputEncodedSignal = new List<string>();
            OutputIntervalIndices = new List<int>();
            OutputQuantizedSignal = new DSPAlgorithms.DataStructures.Signal(new List<float>() {}, false);
            OutputSamplesError = new List<float>();
            for (int i = 0; i < InputSignal.Samples.Count(); i++) 
            {
                for (int j = 0; j <Levels_count;j++ )
                {
                    string k = String.Format("{0:0.##}", Levels[j].Value);
                    if (InputSignal.Samples[i] >= Levels[j].Key && InputSignal.Samples[i] <= float.Parse(k)) 
                    {
                        OutputIntervalIndices.Add(j+1);
                        OutputEncodedSignal.Add(BinaryValues[j]);
                        OutputQuantizedSignal.Samples.Add(MidPoints_of_levels[j]);
                        OutputSamplesError.Add(MidPoints_of_levels[j] - InputSignal.Samples[i]);
                    }
                }
            }
            //throw new NotImplementedException();
        }
    }
}
