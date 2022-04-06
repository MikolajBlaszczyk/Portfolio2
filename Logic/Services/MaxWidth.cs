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
        public async Task<double> CheckMaxHeight(CalculationModel input)
        {
            if (input.DetachedHouse == true)
            {
                return Convert.ToDouble(MaximumWidth.DetachedHouse);
            }
            else if (input.MultiFamilyHouse == true)
            {
                return Convert.ToDouble(MaximumWidth.MultiFamilyHouse);
            }
            else if (input.Kindergarten == true)
            {
                return Convert.ToDouble(MaximumWidth.Kindergarten);
            }
            else if (input.HealthCareBuilding == true)
            {
                return Convert.ToDouble(MaximumWidth.HealthCareBuilding);
            }
            else if (input.Garage == true)
            {
                return Convert.ToDouble(MaximumWidth.Garage);
            }
            else if (input.Underground == true)
            {
                return Convert.ToDouble(MaximumWidth.Underground);
            }
            else
            {
                throw new Exception("No boolean prop was checked");
            }
        }
    }
}
