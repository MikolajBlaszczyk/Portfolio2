using System.Collections.Generic;

namespace ArchitectureUI.Models
{
    public class CalculateModel
    {
        //output
        public bool DetachedHouse { get; set; }
        public bool MultiFamilyHouse { get; set; }
        public bool Kindergarten { get; set; }
        public bool HealthCareBuilding { get; set; }
        public bool Garage { get; set; }
        public bool Underground { get; set; }
        public double FloorHeight { get; set; } = 0;
        //input
        public int AmoutOfStairs { get; set; }
        public bool Landing { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Depth { get; set; }
        public string LandingStairs { get; set; }
        //success 
        public bool Success { get; set; } = false;
    }
}
