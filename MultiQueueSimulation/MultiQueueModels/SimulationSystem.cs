
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiQueueModels
{
    public class SimulationSystem
    {
        public SimulationSystem()
        {
            this.Servers = new List<Server>();
            this.InterarrivalDistribution = new List<TimeDistribution>();
            this.PerformanceMeasures = new PerformanceMeasures();
            this.SimulationTable = new List<SimulationCase>();
            this.StoppingCriteria = new Enums.StoppingCriteria();
            this.SelectionMethod = new Enums.SelectionMethod();
            this.random = new Random();
            this.totalSimulationTime = 0;
            this.totalWaitTime = 0;
            this.totalCustomersWaited = 0;
        }
        ///////////// INPUTS ///////////// 
        public int NumberOfServers { get; set; }
        public int StoppingNumber { get; set; }
        public List<Server> Servers { get; set; }
        public List<TimeDistribution> InterarrivalDistribution { get; set; }
        public Enums.StoppingCriteria StoppingCriteria { get; set; }
        public Enums.SelectionMethod SelectionMethod { get; set; }

        public int totalWaitTime = 0;
        public int totalCustomersWaited = 0;
        private Random random;
        public int totalSimulationTime = 0;
        public Random rnd;
        public int finishTime = 0;
        public int arrivalTime = 0;


        ///////////// OUTPUTS /////////////
        public List<SimulationCase> SimulationTable { get; set; }
        public PerformanceMeasures PerformanceMeasures { get; set; }


        Server s = new Server();


      
        int index = 0;
        //calculating cumulative probability for all system
        public int calcProb(int index)
        {
            if (index == 0)
            {
                InterarrivalDistribution[index].MinRange = 1;
                InterarrivalDistribution[index].CummProbability = InterarrivalDistribution[index].Probability;
            }
           else
           {
                InterarrivalDistribution[index].MinRange = InterarrivalDistribution[index - 1].MaxRange + 1;
                InterarrivalDistribution[index].CummProbability = InterarrivalDistribution[index - 1].CummProbability + InterarrivalDistribution[index].Probability;
           }
            int max = (int)(InterarrivalDistribution[index].CummProbability * 100);
            InterarrivalDistribution[index].MaxRange = max;

            return InterarrivalDistribution[index].MaxRange;
        }

        TimeDistribution ti = new TimeDistribution();
        public void calculateCummProbability()
        {

            int i = 0;
            while (i < InterarrivalDistribution.Count)
            {
                int maxRange = calcProb(i);
                i++;
            }

            for (int j = 0; j < Servers.Count; j++)
            {
                var server = Servers[j];
                ti.calculateCummProbabilit(server);

            }

        }

        public int calculateInterArrival(SimulationCase Case) //time bet arrival
        {
            int i = 0;
            while (i < InterarrivalDistribution.Count)
            {
                if (Case.RandomInterArrival <= InterarrivalDistribution[i].MaxRange)
                {
                    if (Case.RandomInterArrival >= InterarrivalDistribution[i].MinRange)

                        return InterarrivalDistribution[i].Time;
                }
                i++;
            }
            return 0;
        }
        public int calculateServiceTime(SimulationCase Case) 
        {
            int i = 0;
            while (i < Case.AssignedServer.TimeDistribution.Count)
            {
                if (Case.RandomService <= Case.AssignedServer.TimeDistribution[i].MaxRange)
                {
                    if (Case.RandomService >= Case.AssignedServer.TimeDistribution[i].MinRange)
                        return Case.AssignedServer.TimeDistribution[i].Time;
                }
                i++;
            }
            return 0;
        }

        private int LeastUtilizationMethod(List<int> ServersIDs)
        {
            // decimal random = 100000000;
            decimal random =decimal.MaxValue;
            int serverID = -1;
            int id = 0;

            for (int i = 0; i < ServersIDs.Count; i++)
            {
                if (this.finishTime == 0)
                    this.finishTime = 1;
               
                decimal tmp = (Servers[i].TotalWorkingTime / this.finishTime);
                
                if (random > tmp)
                {
                    random = tmp;
                    serverID = i;
                }
            }
            id = serverID;
            return id;
        }

       
        private int HighestPriorityMethod(List<int> IdelServersList)
        {

            int id = IdelServersList[0];
            return id;
        }

      
        private int RandomMethod(List<int> IdelServersList)
        {
            int RandomNum = this.random.Next(0, IdelServersList.Count);

            return IdelServersList[RandomNum];
        }


        // Return the id of the server who will be idle first
        private List<int> MinFinishTime(List<Server> Servers)
        {
            int minFtime = 100000000;
            int serverID = -1;
            List<int> ServersIndecies = new List<int>();

            int i = 0;
            while (i < this.Servers.Count)
            {
                if (minFtime > Servers[i].FinishTime)
                {
                    minFtime = Servers[i].FinishTime;
                    serverID = i;
                }
                i++;

               
            }
            int j = 0;
            while (j < this.Servers.Count)
            {
                if (this.Servers[j].FinishTime == this.Servers[serverID].FinishTime)
                {
                    ServersIndecies.Add(j);
                }
                j++;
            }
            
            return ServersIndecies;
        }

       
        private int assignServer(int arrivalTime)
        {
            
            int status = 0;
            List<int> IdelServersList = new List<int>();
            int serverInd;

            for (int i = 0; i < this.Servers.Count; ++i)
            {
                // Checks if server idle to add to IdelServersList
                if (this.Servers[i].FinishTime <= arrivalTime)
                {
                    IdelServersList.Add(i);
                    status = 1;
                }
            }
            if (status == 0) // If server not idle, choose servers who will be idle first
            {
                IdelServersList = MinFinishTime(this.Servers);
                totalCustomersWaited++;
            }

            // Get the server depending on the selection method
            switch (SelectionMethod)
            {
                case Enums.SelectionMethod.Random:
                    serverInd = RandomMethod(IdelServersList);
                    break;
                case Enums.SelectionMethod.HighestPriority:
                    serverInd = HighestPriorityMethod(IdelServersList);
                    break;
                default:
                    serverInd = LeastUtilizationMethod(IdelServersList);
                    break;
            }
            return serverInd;
        }

        

        public void displayIntervals(Server s)
        {
            Console.WriteLine("Server:" + s.ID);

            for (int i = 0; i < s.Intervals.Count; i++)
            {
                Console.WriteLine(s.Intervals[i].Key + " " + s.Intervals[i].Value);
            }
            Console.WriteLine();
        }


        public void calculateAverageServiceTime(Server s)
        {
            if (s.numberOfCustomers != 0)
                s.AverageServiceTime = (decimal)s.TotalWorkingTime / (decimal)s.numberOfCustomers;
        }

        public void calculateIdleProbability(int totalSimulationTime, Server s)
        {
            int totalIdleTime = totalSimulationTime - s.TotalWorkingTime;
            s.IdleProbability = (decimal)totalIdleTime / (decimal)totalSimulationTime;
        }


        public decimal calculateUtilization(int totalSimulationTime, Server s)
        {
            if (totalSimulationTime != 0)
                return s.Utilization = (decimal)s.TotalWorkingTime / (decimal)totalSimulationTime;
            else
                return 0;
        }

        public void calculateServersPerformanceMeasures()
        {
            for (int i = 0; i < Servers.Count; i++)
            {
                var server = Servers[i];

                displayIntervals(server);
                calculateAverageServiceTime(server);
                calculateIdleProbability(totalSimulationTime, server);
                calculateUtilization(totalSimulationTime, server);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
    
        public int calculateMaximumQueueLength()
        {
            int maximumQueueLength = 0;
            int count = 0;

            if (totalCustomersWaited == 0)
            {
                return 0;
            }
            else
            {
                int i = 0;
                while (i < SimulationTable.Count)
                {
                    int j = i;
                    count = 0;

                    while (j < SimulationTable.Count)
                    {
                        if (SimulationTable[i].StartTime > SimulationTable[j].ArrivalTime)
                        {
                            count++;
                        }
                        j++;
                    }

                    if (count > maximumQueueLength)
                    {
                        maximumQueueLength = count;
                    }
                    i++;
                }
                int len = PerformanceMeasures.MaxQueueLength = maximumQueueLength;
                return len;
            }
        }

        public decimal cals_wait_prob()
        {
            decimal wait_prob = PerformanceMeasures.WaitingProbability = (decimal)totalCustomersWaited / (decimal)StoppingNumber;
            return wait_prob;
        }
        public decimal calc_avg_wait_time()
        {
            decimal avg_wait_time = PerformanceMeasures.AverageWaitingTime = (decimal)totalWaitTime / (decimal)StoppingNumber; ;
            return avg_wait_time;
        }
        public void calculateSystemPerformanceMeasures()
        {
            calc_avg_wait_time();
            cals_wait_prob();
            calculateMaximumQueueLength();
        }

        public int getSimulationTime()
        {
            return this.totalSimulationTime;
        }

        //Table creation using Customer numbers
        public void createTableUsingCustomersNo()
        {
            SimulationCase customerCase;
            int i = 0;
            while (i < StoppingNumber)
            {
                customerCase = new SimulationCase();
                customerCase.CustomerNumber = i + 1;
                customerCase.RandomService = random.Next(1, 100);

                if (i == 0)
                {
                    customerCase.ArrivalTime = i;
                    customerCase.InterArrival = i;
                    customerCase.RandomInterArrival = i + 1;
                }
                else if (i != 0)
                {
                    customerCase.RandomInterArrival = random.Next(1, 100);
                    // Access random and get InterArrival (Time between arrivals)
                    customerCase.InterArrival = calculateInterArrival(customerCase);
                    // Clock of time Arrival
                    customerCase.ArrivalTime = customerCase.InterArrival + SimulationTable[i - 1].ArrivalTime;
                }

                int assignedServerIndex = assignServer(customerCase.ArrivalTime);
                customerCase.AssignedServer = Servers[assignedServerIndex];
                int t = Math.Max(customerCase.ArrivalTime, customerCase.AssignedServer.FinishTime);
                customerCase.StartTime = t;
                int e = customerCase.StartTime - customerCase.ArrivalTime;
                customerCase.TimeInQueue = e;
                totalWaitTime = totalWaitTime + customerCase.TimeInQueue;


                customerCase.ServiceTime = calculateServiceTime(customerCase);
                customerCase.EndTime = customerCase.StartTime + customerCase.ServiceTime;
                Servers[assignedServerIndex].FinishTime = customerCase.EndTime;
                Servers[assignedServerIndex].TotalWorkingTime = Servers[assignedServerIndex].TotalWorkingTime + customerCase.ServiceTime;
                Servers[assignedServerIndex].numberOfCustomers += 1;

                Servers[assignedServerIndex].Intervals.Add(new KeyValuePair<int, int>(customerCase.StartTime, customerCase.EndTime));
                int h = Math.Max(totalSimulationTime, customerCase.EndTime);
                totalSimulationTime = h;
                SimulationTable.Add(customerCase);

                i++;
            }
        }

        public void clearSimulation()
        {
            for (int i = 0; i < SimulationTable.Count; i++)
            {
                var customerCase = SimulationTable[i];
                customerCase.AssignedServer.FinishTime = 0;
            }
        }


        public void Simulate()
        {
            getSimulationTime();
            calcProb(index);
            //assignServer(arrivalTime);
            calculateCummProbability();
            createTableUsingCustomersNo();
            //select_method();
            calculateServersPerformanceMeasures();
            calc_avg_wait_time();
            cals_wait_prob();
            calculateMaximumQueueLength();
            calculateSystemPerformanceMeasures();
            clearSimulation();
        }
    }
}
