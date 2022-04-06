using Logic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class MaxHeight : IMaxHeight
    {
        public async Task<double> CheckMaxHeight(CalculationModel input)
        {
            if (input.DetachedHouse == true)
            {
                return Convert.ToDouble(MaximumHeight.DetachedHouse);
            }
            else if (input.MultiFamilyHouse == true)
            {
                return Convert.ToDouble(MaximumHeight.MultiFamilyHouse);
            }
            else if (input.Kindergarten == true)
            {
                return Convert.ToDouble(MaximumHeight.Kindergarten);
            }
            else if (input.HealthCareBuilding == true)
            {
                return Convert.ToDouble(MaximumHeight.HealthCareBuilding);
            }
            else if (input.Garage == true)
            {
                return Convert.ToDouble(MaximumHeight.Garage);
            }
            else if (input.Underground == true)
            {
                return Convert.ToDouble(MaximumHeight.Underground);
            }
            else
            {
                throw new Exception("No boolean prop was checked");
            }
        }
    }
}
