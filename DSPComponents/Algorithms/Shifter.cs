using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class Shifter : Algorithm
    {
        public Signal InputSignal { get; set; }
        public int ShiftingValue { get; set; }
        public Signal OutputShiftedSignal { get; set; }

        public override void Run()
        {
            OutputShiftedSignal = new DSPAlgorithms.DataStructures.Signal(new List<float>() { }, false, new List<float>(), new List<float>(), new List<float>());
            //right delay -ve no fold
            //left advance +ve no fold
            if (InputSignal.Periodic == true)
            {
                for (int i = 0; i < InputSignal.Samples.Count; i++)
                {
                    OutputShiftedSignal.SamplesIndices.Add(InputSignal.SamplesIndices[i] + ShiftingValue);
                    OutputShiftedSignal.Samples.Add(InputSignal.Samples[i]);
                }
                OutputShiftedSignal.Periodic = true;
            }
            else
            {
                for (int i = 0; i < InputSignal.Samples.Count; i++)
                {
                    OutputShiftedSignal.SamplesIndices.Add(InputSignal.SamplesIndices[i] - ShiftingValue);
                    OutputShiftedSignal.Samples.Add(InputSignal.Samples[i]);
                }
            }
            //  if (ShiftingValue > 0)
            // {
            /*  if (InputSignal.Frequencies.Count % 2 != 0)
              {
                  for (int i = 0; i < InputSignal.Samples.Count; i++)
                  {
                      if (ShiftingValue < 0)
                      {
                          OutputShiftedSignal.SamplesIndices.Add(InputSignal.SamplesIndices[i] + ShiftingValue);
                          OutputShiftedSignal.Samples.Add(InputSignal.Samples[i]);

                      }
                      else 
                      {
                          OutputShiftedSignal.SamplesIndices.Add(InputSignal.SamplesIndices[i] - ShiftingValue);
                          OutputShiftedSignal.Samples.Add(InputSignal.Samples[i]);
          
                      }
                  }
              }
              else 
              {
                  if (ShiftingValue < 0)
                  {
                      for (int i = 0; i < InputSignal.Samples.Count; i++)
                      {
                          OutputShiftedSignal.SamplesIndices.Add(InputSignal.SamplesIndices[i] - ShiftingValue);
                          OutputShiftedSignal.Samples.Add(InputSignal.Samples[i]);
                      }
                  }
                  else 
                  {
                      for (int i = 0; i < InputSignal.Samples.Count; i++)
                      {
                          OutputShiftedSignal.SamplesIndices.Add(InputSignal.SamplesIndices[i] - ShiftingValue);
                          OutputShiftedSignal.Samples.Add(InputSignal.Samples[i]);
                      }
                  }
              }*/

            //     
            //}
            //else if (ShiftingValue < 0) 
            //{
            //  //  ShiftingValue *= -1;
            //    for (int i = 0; i < InputSignal.Samples.Count; i++)
            //    {
            //        OutputShiftedSignal.SamplesIndices.Add(InputSignal.SamplesIndices[i] + ShiftingValue);
            //        OutputShiftedSignal.Samples.Add(InputSignal.Samples[i]);
            //    }
            //    //      //     
            //}
            //       throw new NotImplementedException();
        }
    }
}
