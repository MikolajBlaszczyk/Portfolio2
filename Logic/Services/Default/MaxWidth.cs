using Logic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services
{
    public class MaxWidth : IMaxWidth
    {
        public async Task<double> CheckMaxWidth(CalculationModel input)
        {
            if (input.DetachedHouse == true)
            {
                return Convert.ToDouble(MinimumWidth.DetachedHouse);
            }
            else if (input.MultiFamilyHouse == true)
            {
                return Convert.ToDouble(MinimumWidth.MultiFamilyHouse);
            }
            else if (input.Kindergarten == true)
            {
                return Convert.ToDouble(MinimumWidth.Kindergarten);
            }
            else if (input.HealthCareBuilding == true)
            {
                return Convert.ToDouble(MinimumWidth.HealthCareBuilding);
            }
            else if (input.Garage == true)
            {
                return Convert.ToDouble(MinimumWidth.Garage);
            }
            else if (input.Underground == true)
            {
                return Convert.ToDouble(MinimumWidth.Underground);
            }
            else
            {
                throw new Exception("No boolean prop was checked");
            }
        }
    }
}
