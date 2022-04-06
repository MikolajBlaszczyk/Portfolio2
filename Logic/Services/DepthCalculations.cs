using Logic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services
{
    public class DepthCalculations : IDepthCalculations
    {
        public async Task<double> CalculateDepth(CalculationModel input)
        {
            // the 2h+s should be between 0.6 to 0.65
            double h = input.MaxHeight;
            double s = 0.65 - 2 * h;
            return s;
        }


    }
}
