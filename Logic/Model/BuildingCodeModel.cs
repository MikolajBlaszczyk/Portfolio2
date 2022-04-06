using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Model
{
    public class CalculationModel
    {
        //output
        public bool DetachedHouse { get; set; }
        public bool MultiFamilyHouse { get; set; }
        public bool Kindergarten { get; set; }
        public bool HealthCareBuilding { get; set; }
        public bool Garage { get; set; }
        public bool Underground { get; set; }
        public double FloorHeight { get; set; }
        //input
        public int AmoutOfStairs { get; set; }
        public bool Landing { get; set; }
        public double MaxHeight { get; set; }
        public double MaxWidth { get; set; }
        public double Depth { get; set; }
        public List<int> LandingStairs { get; set; }
    }
}
