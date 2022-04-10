using Logic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Services.Change
{
    public class ChangeParams : IChangeParams
    {
        public async Task<double> MatchParams(double height, double depth)
        {
            double pattern = 2 * height + depth;

            if (pattern <= 0.65 && pattern >= 0.60)
            {
                return depth;
            }
            else
            {
                if (pattern > 0.65)
                {
                    depth = 0.65 - (2 * height);
                }
                else if (pattern < 0.60)
                {
                    depth = 0.6 - (2 * height);
                }
                return  depth;
            }
        }
    }
}
