﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSPAlgorithms.DataStructures;

namespace DSPAlgorithms.Algorithms
{
    public class TimeDelay:Algorithm
    {
        public Signal InputSignal1 { get; set; }
        public Signal InputSignal2 { get; set; }
        public float InputSamplingPeriod { get; set; }
        public float OutputTimeDelay { get; set; }

        public override void Run()
        {
            DirectCorrelation dc = new  DirectCorrelation();
            dc.InputSignal1 = InputSignal1;
            dc.InputSignal2 = InputSignal2;
            List<float>correlation = new List<float>();
            dc.Run();
            correlation = dc.OutputNormalizedCorrelation;
            int max_correlation_lag = correlation.IndexOf(correlation.Max());
            OutputTimeDelay = max_correlation_lag * InputSamplingPeriod;
       //     throw new NotImplementedException();
        }
    }
}
