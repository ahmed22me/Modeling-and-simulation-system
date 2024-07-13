using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiQueueModels
{
    public class TimeDistribution
    {

        public TimeDistribution()
        {

        }


        public int Time { get; set; }
        public decimal Probability { get; set; }
        public decimal CummProbability { get; set; }
        public int MinRange { get; set; }
        public int MaxRange { get; set; }

        public TimeDistribution(int Time, decimal Probability)
        {
            this.Time = Time;
            this.Probability = Probability;
        }

        public void calculateCummProbabilit(Server s)
        {
            for (int i = 0; i < s.TimeDistribution.Count; i++)
            {

                if (i == 0)
                {
                    s.TimeDistribution[i].CummProbability = s.TimeDistribution[i].Probability;
                    s.TimeDistribution[i].MinRange = 1;
                }
                else
                {
                    s.TimeDistribution[i].CummProbability = s.TimeDistribution[i - 1].CummProbability + s.TimeDistribution[i].Probability;
                    s.TimeDistribution[i].MinRange = s.TimeDistribution[i - 1].MaxRange + 1;
                }
                s.TimeDistribution[i].MaxRange = decimal.ToInt32(s.TimeDistribution[i].CummProbability * 100);
            }
        }

    }
}
