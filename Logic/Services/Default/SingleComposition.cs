using Logic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class SingleComposition : ISingleComposition
    {
        public IStairs StairsProcessor { get; set; }

        public SingleComposition(IStairs stairsProcessor)
        {
            StairsProcessor = stairsProcessor;
        }

        public async Task<bool> CheckSingleComposition(CalculationModel input)
        {
            decimal floorHeight = Convert.ToDecimal(input.FloorHeight);

            if (input.DetachedHouse == true)
            {
                return await LevelValidation(MaximumHeight.DetachedHouse, floorHeight);
            }
            else if (input.MultiFamilyHouse == true)
            {
                return await LevelValidation(MaximumHeight.MultiFamilyHouse, floorHeight);
            }
            else if (input.Kindergarten == true)
            {
                return await LevelValidation(MaximumHeight.Kindergarten, floorHeight);
            }
            else if (input.HealthCareBuilding == true)
            {
                return await LevelValidation(MaximumHeight.HealthCareBuilding, floorHeight);
            }
            else if (input.Garage == true)
            {
                return await LevelValidation(MaximumHeight.Garage, floorHeight);
            }
            else if (input.Underground == true)
            {
                return await LevelValidation(MaximumHeight.Underground, floorHeight);
            }
            else
            {
                throw new Exception("No boolean prop was checked");
            }
        }

        public async Task<bool> LevelValidation(decimal maxHeight, decimal floorHeight)
        {
            int result = await StairsProcessor.AmountOfStairs(floorHeight, maxHeight);

            if (result > 17)
            {
                return false;
            }
            else if (result <= 17 && result > 0)
            {
                return true;
            }
            else
            {
                throw new Exception("the number of stairs is incorrect");
            }
        }

    }
}
