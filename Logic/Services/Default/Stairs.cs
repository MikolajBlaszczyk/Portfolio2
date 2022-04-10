using Logic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Stairs : IStairs
    {
        //necessary?
        public async Task<int> AmountOfStairs(decimal floorHeight, decimal maxStairHeight)
        {
            return Convert.ToInt32(Math.Ceiling(floorHeight / maxStairHeight));
        }
        //probalby will work on its own 
        public async Task<int> AmountOfStairs(CalculationModel input)
        {
            decimal floorHeight = Convert.ToDecimal(input.FloorHeight);
            if (input.DetachedHouse == true)
            {
                return await AmountOfStairs(floorHeight, MaximumHeight.DetachedHouse);
            }
            else if (input.MultiFamilyHouse == true)
            {
                return await AmountOfStairs(floorHeight, MaximumHeight.MultiFamilyHouse);
            }
            else if (input.Kindergarten == true)
            {
                return await AmountOfStairs(floorHeight, MaximumHeight.Kindergarten);
            }
            else if (input.HealthCareBuilding == true)
            {
                return await AmountOfStairs(floorHeight, MaximumHeight.HealthCareBuilding);
            }
            else if (input.Garage == true)
            {
                return await AmountOfStairs(floorHeight, MaximumHeight.Garage);
            }
            else if (input.Underground == true)
            {
                return await AmountOfStairs(floorHeight, MaximumHeight.Underground);
            }
            else
            {
                throw new Exception("No boolean prop was checked");
            }
        }
    }
}
