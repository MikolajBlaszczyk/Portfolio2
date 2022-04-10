using Logic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class MultiComposition : IMultiComposition
    {
        public async Task<List<int>> CalculateLandings(CalculationModel model)
        {
            List<int> output = new() { };
            if (model.AmoutOfStairs < 34)
            {
                output.Add(model.AmoutOfStairs / 2);
            }
            else
            {
                output = await Landings(model.AmoutOfStairs);
            }
            return output;
        }

        public async Task<List<int>> Landings(double stairsNumber)
        {
            List<int> output = new();
            int importantNumber = Convert.ToInt32(Math.Ceiling(stairsNumber / 17));
            int landing = 17;
            for (int i = 0; i < importantNumber - 1; i++)
            {
                output.Add(landing);
                landing += 17;
            }
            return output;
        }


    }
}
