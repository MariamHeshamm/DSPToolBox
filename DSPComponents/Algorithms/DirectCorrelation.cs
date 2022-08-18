using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class DirectCorrelation : Algorithm
    {
        public Signal InputSignal1 { get; set; }
        public Signal InputSignal2 { get; set; }
        public List<float> OutputNonNormalizedCorrelation { get; set; }
        public List<float> OutputNormalizedCorrelation { get; set; }

        public override void Run()
        {
            OutputNonNormalizedCorrelation = new List<float>();
            OutputNormalizedCorrelation = new List<float>();
            //ngeb value llnormalization 
            if (InputSignal2 == null)
            {
                float sum = 0;
                for (int i = 0; i < InputSignal1.Samples.Count; i++)
                {
                    sum += InputSignal1.Samples[i] * InputSignal1.Samples[i];//keda 3mlt squaring
                }
                float normalized = (float)Math.Sqrt(sum * sum) / InputSignal1.Samples.Count;
                int N = InputSignal1.Samples.Count;
                List<float> corr = new List<float>();
                //Signal shifted_signal = new Signal(new List<float>(),true);
                List<float> shifted_signal = new List<float>();
                for (int i = 0; i < InputSignal1.Samples.Count; i++)
                {
                    shifted_signal.Add(InputSignal1.Samples[i]);//deh keda elsignal ely h3od a3ml feh shift kol shwya t7t
                }
                //shifted_signal = InputSignal1;
                if (InputSignal1.Periodic == true)
                {
                    float value = 0;
                    for (int i = 0; i < InputSignal1.Samples.Count; i++)
                    {
                        if (i == 0)
                        {
                            for (int j = 0; j < InputSignal1.Samples.Count; j++)
                            {
                                value += (InputSignal1.Samples[j] * InputSignal1.Samples[j]);
                            }
                            value /= N;
                            corr.Add(value);
                            value = 0;
                        }
                        else//elmfrod n shift
                        {
                            float element_to_be_removed = shifted_signal[0];//hna bdam ana periodic bshel 2wl element w a7to fla5r  
                            shifted_signal.Add(element_to_be_removed);
                            shifted_signal.RemoveAt(0);
                            for (int l = 0; l < shifted_signal.Count; l++)
                            {
                                value += (InputSignal1.Samples[l] * shifted_signal[l]);
                            }
                            value /= N;
                            corr.Add(value);
                            value = 0;
                        }
                    }
                }
                else if (InputSignal1.Periodic == false)
                {
                    float value = 0;
                    for (int i = 0; i < InputSignal1.Samples.Count; i++)
                    {
                        if (i == 0)
                        {
                            for (int j = 0; j < InputSignal1.Samples.Count; j++)
                            {
                                value += (InputSignal1.Samples[j] * InputSignal1.Samples[j]);
                            }
                            value /= N;
                            corr.Add(value);
                            value = 0;
                        }
                        else//elmfrod n shift
                        {
                            float element_to_be_removed = shifted_signal[0];//hna ana mesh periodic f bshel 2wl element w b7ot zero
                            shifted_signal.Add(0);
                            shifted_signal.RemoveAt(0);
                            for (int l = 0; l < shifted_signal.Count; l++)
                            {
                                value += (InputSignal1.Samples[l] * shifted_signal[l]);
                            }
                            value /= N;
                            corr.Add(value);
                            value = 0;
                        }
                    }

                }
                List<float> nomalized = new List<float>();
                OutputNonNormalizedCorrelation = corr;
                for (int i = 0; i < corr.Count; i++)
                {
                    nomalized.Add(corr[i] / normalized);
                }
                OutputNormalizedCorrelation = nomalized;
                //  throw new NotImplementedException();
            }
            ////////////////////////////////////////////////////////////////////////////////
            else// keda hna b3ml cross correlation
            {
                int Length = InputSignal1.Samples.Count + InputSignal2.Samples.Count - 1;//lama 5alet eltwo signals bt3hom keda esht8l

                //if (InputSignal1.Samples.Count < InputSignal2.Samples.Count) 
                //{
                while (InputSignal1.Samples.Count != Length)
                {
                    InputSignal1.Samples.Add(0);
                }
                //}
                //   else if (InputSignal1.Samples.Count > InputSignal2.Samples.Count)
                // {
                while (InputSignal2.Samples.Count != Length)
                {
                    InputSignal2.Samples.Add(0);
                }//l7d hna ana keda bas 5alet length eltwo signals ad ba3d 
                //   }
                float sum1 = 0, sum2 = 0;
                for (int i = 0; i < InputSignal1.Samples.Count; i++)
                {
                    sum1 += InputSignal1.Samples[i] * InputSignal1.Samples[i];//keda 3mlt squaring
                }
                for (int i = 0; i < InputSignal2.Samples.Count; i++)
                {
                    sum2 += InputSignal2.Samples[i] * InputSignal2.Samples[i];//keda 3mlt squaring
                }
                float normalized = (float)Math.Sqrt(sum1 * sum2) / InputSignal1.Samples.Count;
                int N = InputSignal1.Samples.Count;
                List<float> corr = new List<float>();
                // Signal shifted_signal = new Signal(new List<float>(),true);
                List<float> shifted_signal = new List<float>();
                for (int i = 0; i < InputSignal2.Samples.Count; i++)
                {
                    shifted_signal.Add(InputSignal2.Samples[i]);
                }
                //shifted_signal = InputSignal1;
                if (InputSignal1.Periodic == true)
                {
                    float value = 0;
                    //  int k = 0;
                    for (int i = 0; i < InputSignal2.Samples.Count; i++)
                    {
                        if (i == 0)//hna keda mafesh shift
                        {
                            for (int j = 0; j < InputSignal2.Samples.Count; j++)
                            {
                                value += (InputSignal1.Samples[j] * InputSignal2.Samples[j]);
                            }
                            value /= N;
                            corr.Add(value);
                            value = 0;
                        }
                        else//elmfrod n shift
                        {
                            float element_to_be_removed = shifted_signal[0];
                            shifted_signal.Add(element_to_be_removed);
                            shifted_signal.RemoveAt(0);
                            for (int l = 0; l < shifted_signal.Count; l++)
                            {
                                value += (InputSignal1.Samples[l] * shifted_signal[l]);
                            }
                            value /= N;
                            corr.Add(value);
                            value = 0;
                        }
                    }
                }
                else if (InputSignal1.Periodic == false)
                {
                    float value = 0;
                    //  int k = 0;
                    for (int i = 0; i < InputSignal1.Samples.Count; i++)
                    {
                        if (i == 0)
                        {
                            for (int j = 0; j < InputSignal1.Samples.Count; j++)
                            {
                                value += (InputSignal1.Samples[j] * InputSignal2.Samples[j]);
                            }
                            value /= N;
                            corr.Add(value);
                            value = 0;
                        }
                        else//elmfrod n shift
                        {
                            float element_to_be_removed = shifted_signal[0];
                            shifted_signal.Add(0);
                            shifted_signal.RemoveAt(0);
                            for (int l = 0; l < shifted_signal.Count; l++)
                            {
                                value += (InputSignal1.Samples[l] * shifted_signal[l]);
                            }
                            value /= N;
                            corr.Add(value);
                            value = 0;
                        }
                    }

                }
                List<float> nomalized = new List<float>();
                OutputNonNormalizedCorrelation = corr;
                for (int i = 0; i < corr.Count; i++)
                {
                    nomalized.Add(corr[i] / normalized);
                }
                OutputNormalizedCorrelation = nomalized;


            }
        }
    }
}