using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryModels
{
    public class SimulationSystem
    {
        List<int> demand_random;


        Random r = new Random();
        public SimulationSystem()
        {
            DemandDistribution = new List<Distribution>();
            LeadDaysDistribution = new List<Distribution>();
            SimulationTable = new List<SimulationCase>();
            PerformanceMeasures = new PerformanceMeasures();
        }

        ///////////// INPUTS /////////////

        public int OrderUpTo { get; set; }
        public int ReviewPeriod { get; set; }
        public int NumberOfDays { get; set; }
        public int StartInventoryQuantity { get; set; }
        public int StartLeadDays { get; set; }
        public int StartOrderQuantity { get; set; }

        public List<Distribution> DemandDistribution { get; set; }
        public List<Distribution> LeadDaysDistribution { get; set; }

        ///////////// OUTPUTS /////////////

        public List<SimulationCase> SimulationTable { get; set; }
        public PerformanceMeasures PerformanceMeasures { get; set; }


        public void ReadTestcases(string path)
        {
            string[] lines = System.IO.File.ReadAllLines(path);
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] == "") { continue; }
                else if (lines[i] == "OrderUpTo")
                {
                    this.OrderUpTo = int.Parse(lines[i + 1]);
                    i++;
                }

                else if (lines[i] == "ReviewPeriod")
                {
                    this.ReviewPeriod = int.Parse(lines[i + 1]);
                    i++;
                }
                else if (lines[i] == "StartInventoryQuantity")
                {
                    this.StartInventoryQuantity = int.Parse(lines[i + 1]);
                    i++;
                }
                else if (lines[i] == "StartLeadDays")
                {
                    this.StartLeadDays = int.Parse(lines[i + 1]);
                    i++;
                }
                else if (lines[i] == "StartOrderQuantity")
                {
                    this.StartOrderQuantity = int.Parse(lines[i + 1]);
                    i++;
                }
                else if (lines[i] == "NumberOfDays")
                {
                    this.NumberOfDays = int.Parse(lines[i + 1]);
                    i++;
                }
                else if (lines[i] == "DemandDistribution")
                {

                    for (int j = 0; j < 5; j++)
                    {
                        string[] demandDist = lines[i + j + 1].Split(',', (char)StringSplitOptions.RemoveEmptyEntries);
                        Distribution d = new Distribution();
                        d.Value = int.Parse(demandDist[0]);
                        d.Probability = decimal.Parse(demandDist[1]);
                        this.DemandDistribution.Add(d);


                    }
                    for (int j = 0; j < this.DemandDistribution.Count; j++)
                    {
                        if (j == 0)
                        {
                            this.DemandDistribution[j].CummProbability = this.DemandDistribution[j].Probability;
                            this.DemandDistribution[j].MinRange = 1;

                        }
                        else
                        {

                            this.DemandDistribution[j].CummProbability = this.DemandDistribution[j - 1].CummProbability + this.DemandDistribution[j].Probability;
                            this.DemandDistribution[j].MinRange = this.DemandDistribution[j].MaxRange + 1;

                        }
                        decimal v = (this.DemandDistribution[j].CummProbability) * 100;

                        this.DemandDistribution[j].MaxRange = (int)v;

                    }


                }

                else if (lines[i] == "LeadDaysDistribution")
                {

                    for (int j = 0; j < 3; j++)
                    {
                        string[] leadDist = lines[i + j + 1].Split(',', (char)StringSplitOptions.RemoveEmptyEntries);
                        Distribution d = new Distribution();
                        d.Value = int.Parse(leadDist[0]);
                        d.Probability = decimal.Parse(leadDist[1]);
                        this.LeadDaysDistribution.Add(d);


                    }

                    for (int k = 0; k < this.LeadDaysDistribution.Count; k++)
                    {
                        if (k == 0)
                        {
                            this.LeadDaysDistribution[k].CummProbability = this.LeadDaysDistribution[k].Probability;
                            this.LeadDaysDistribution[k].MinRange = 1;

                        }
                        else
                        {

                            this.LeadDaysDistribution[k].CummProbability =
                             this.LeadDaysDistribution[k - 1].CummProbability + this.LeadDaysDistribution[k].Probability;
                            this.LeadDaysDistribution[k].MinRange = this.LeadDaysDistribution[k].MaxRange + 1;


                        }
                        decimal v = (this.LeadDaysDistribution[k].CummProbability) * 100;

                        this.LeadDaysDistribution[k].MaxRange = (int)v;

                    }


                }

            }
        }

        public void CreateSimulationTable()
        {
            var r = new Random();

            SimulationCase sc, prev = null;
            int order = StartOrderQuantity;
            bool isLast;
            for (int days = 1; days <= this.NumberOfDays; days++)
            {
                isLast = days % this.ReviewPeriod == 0;
                sc = new SimulationCase();
                sc.Day = days;
                sc.Cycle = days / this.ReviewPeriod + 1;
                sc.DayWithinCycle = (days % this.ReviewPeriod);

                //StartInventoryQuantity
                if (days > 1)
                {
                    sc.BeginningInventory = prev.EndingInventory;
                }
                else
                {
                    sc.BeginningInventory = this.StartInventoryQuantity;
                }
                sc.RandomDemand = r.Next(1, 100);

                //ShortageQuantity
                if (days > 1)
                {
                    sc.ShortageQuantity = prev.ShortageQuantity;
                }
                else
                {
                    sc.ShortageQuantity = 0;
                }


                sc.OrderQuantity = 0;

                //RandomLeadDays
                if (isLast)
                {
                    sc.RandomLeadDays = r.Next(1, 100);
                }
                else
                {
                    sc.RandomLeadDays = 0;
                }

                sc.LeadDays = 0;


                //DaysUntilOrderArrives
                if (days > 1)
                {
                    sc.DaysUntilOrderArrives = prev.DaysUntilOrderArrives - 1;
                }
                else
                {
                    sc.DaysUntilOrderArrives = this.StartLeadDays - 1;
                }
                sc.Demand = GetValue(this.DemandDistribution, sc.RandomDemand);



                if (sc.DaysUntilOrderArrives == -1) //The day the order arrives
                {
                    sc.BeginningInventory += order;

                    sc.ShortageQuantity -= sc.BeginningInventory;
                    if (sc.ShortageQuantity < 0)
                    {
                        sc.EndingInventory = -1 * sc.ShortageQuantity - sc.Demand;
                        sc.ShortageQuantity = 0;
                    }
                    else // Shoratge is greater than recieved order
                    {
                        sc.EndingInventory -= sc.ShortageQuantity + sc.Demand;
                    }
                }
                else // Any other day
                    sc.EndingInventory = sc.BeginningInventory - sc.Demand;

                if (sc.EndingInventory < 0) //Demand is higher than Begining inventory
                {
                    if (sc.DaysUntilOrderArrives == -1)
                    {
                        sc.ShortageQuantity = (sc.EndingInventory * -1);
                    }
                    else
                        sc.ShortageQuantity += (sc.EndingInventory * -1);

                    sc.EndingInventory = 0;
                }

                if (isLast) // Last day in the cycle
                {
                    sc.DayWithinCycle = this.ReviewPeriod;
                    sc.Cycle--;
                    order = sc.OrderQuantity = this.OrderUpTo - sc.EndingInventory + sc.ShortageQuantity;
                    // Generate lead days and calc days until order arrives
                    sc.RandomLeadDays = r.Next(1, 100);
                    sc.LeadDays = GetValue(this.LeadDaysDistribution, sc.RandomLeadDays);
                    sc.DaysUntilOrderArrives = sc.LeadDays;

                }
                prev = sc;
                this.SimulationTable.Add(sc);
            }
            this.PerformanceMeasures = CalculatePerformance(this.SimulationTable);
            foreach (var simCase in this.SimulationTable)
            {
                if (simCase.DaysUntilOrderArrives < 0)
                {
                    simCase.DaysUntilOrderArrives = 0;
                }

            }

        }


        //    public void CreateSimulationTable()
        //    {
        //        var r = new Random();
        //        int order = StartOrderQuantity;
        //        SimulationCase sc, prev = null;
        //        bool isLast;

        //        for (int days = 1; days <= this.NumberOfDays; days++)
        //        {
        //            isLast = days % this.ReviewPeriod == 0;
        //            sc = CreateSimulationCase(days, prev, order, r, isLast);
        //            UpdateInventoryAndShortage(sc, prev, order);

        //            if (isLast)
        //            {
        //                order = UpdateCycleInformation(sc, order, r);
        //            }

        //            prev = sc;
        //            this.SimulationTable.Add(sc);
        //        }

        //        this.PerformanceMeasures = CalculatePerformance(this.SimulationTable);

        //        foreach (var simCase in this.SimulationTable)
        //        {
        //            if (simCase.DaysUntilOrderArrives < 0)
        //            {
        //                simCase.DaysUntilOrderArrives = 0;
        //            }
        //        }
        //    }

        //    private SimulationCase CreateSimulationCase(int days, SimulationCase prev, int order, Random r, bool isLast)
        //    {
        //        return new SimulationCase()
        //        {
        //            Day = days,
        //            Cycle = days / this.ReviewPeriod + 1,
        //            DayWithinCycle = (days % this.ReviewPeriod),
        //            BeginningInventory = (days > 1) ? prev.EndingInventory : this.StartInventoryQuantity,
        //            RandomDemand = r.Next(1, 100),
        //            ShortageQuantity = (days > 1) ? prev.ShortageQuantity : 0,
        //            OrderQuantity = 0,
        //            RandomLeadDays = (isLast) ? r.Next(1, 100) : 0,
        //            LeadDays = 0,
        //            DaysUntilOrderArrives = (days > 1) ? prev.DaysUntilOrderArrives - 1 : this.StartLeadDays - 1
        //        };
        //    }

        //    private void UpdateInventoryAndShortage(SimulationCase sc, SimulationCase prev, int order)
        //    {
        //        sc.Demand = GetValue(this.DemandDistribution, sc.RandomDemand);

        //        if (sc.DaysUntilOrderArrives == -1)
        //        {
        //            sc.BeginningInventory += order;

        //            sc.ShortageQuantity -= sc.BeginningInventory;
        //            if (sc.ShortageQuantity < 0)
        //            {
        //                sc.EndingInventory = -1 * sc.ShortageQuantity - sc.Demand;
        //                sc.ShortageQuantity = 0;
        //            }
        //            else
        //            {
        //                sc.EndingInventory -= sc.ShortageQuantity + sc.Demand;
        //            }
        //        }
        //        else
        //        {
        //            sc.EndingInventory = sc.BeginningInventory - sc.Demand;
        //        }

        //        if (sc.EndingInventory < 0)
        //        {
        //            if (sc.DaysUntilOrderArrives == -1)
        //            {
        //                sc.ShortageQuantity = (sc.EndingInventory * -1);
        //            }
        //            else
        //            {
        //                sc.ShortageQuantity += (sc.EndingInventory * -1);
        //            }
        //            sc.EndingInventory = 0;
        //        }
        //    }

        //    private int UpdateCycleInformation(SimulationCase sc, int order, Random r)
        //    {
        //        sc.DayWithinCycle = this.ReviewPeriod;
        //        sc.Cycle--;
        //        order = sc.OrderQuantity = this.OrderUpTo - sc.EndingInventory + sc.ShortageQuantity;
        //        sc.RandomLeadDays = r.Next(1, 100);
        //        sc.LeadDays = GetValue(this.LeadDaysDistribution, sc.RandomLeadDays);
        //        sc.DaysUntilOrderArrives = sc.LeadDays;

        //        return order;
        //    }





        public PerformanceMeasures CalculatePerformance(List<SimulationCase> SimCases)
        {
            PerformanceMeasures performanceMeasures = new PerformanceMeasures();

            int ending = 0, shortage = 0;
            foreach (SimulationCase simCase in SimCases)
            {
                ending += simCase.EndingInventory;
                shortage += simCase.ShortageQuantity;
            }

            performanceMeasures.EndingInventoryAverage = (decimal)ending / SimCases.Count;
            performanceMeasures.ShortageQuantityAverage = (decimal)shortage / SimCases.Count;

            return performanceMeasures;
        }

        private int GetValue(List<Distribution> distributions, int randomDemand)
        {
            foreach (var x in distributions)
                if (randomDemand >= x.MinRange && randomDemand <= x.MaxRange)
                    return x.Value;
            throw new Exception("Unrecognized");
        }

    }
}





