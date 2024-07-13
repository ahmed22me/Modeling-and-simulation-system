using MultiQueueModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiQueueModels
{
    public class Server
    {
        public Server()
        {
            this.Intervals = new List<KeyValuePair<int, int>>();
            this.TimeDistribution = new List<TimeDistribution>();


            this.FinishTime = 0;
            this.TotalWorkingTime = 0;
            this.numberOfCustomers = 0;
            this.IdleProbability = 0;
            this.AverageServiceTime = 0;
            this.Utilization = 0;
          
        }

        public int ID { get; set; }
        public decimal IdleProbability { get; set; }
        public decimal AverageServiceTime { get; set; } 
        public decimal Utilization { get; set; }

        public List<TimeDistribution> TimeDistribution;

        public List<KeyValuePair<int, int>> Intervals;

        //optional if needed use them
        public int numberOfCustomers { get; set; }
        public int FinishTime { get; set; }
        public int TotalWorkingTime { get; set; }
        public List<int> servedCustomers { get; set; }
    }
}
