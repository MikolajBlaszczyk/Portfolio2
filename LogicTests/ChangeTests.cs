using Logic.Services.Change;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LogicTests
{
    public class ChangeTests
    {
        [Theory]
        [InlineData(0.18,0.27,0.27)]
        [InlineData(0.19,0.27, 0.27)]
        [InlineData(0.19,0.3,0.27)]
        [InlineData(0.19,0.25,0.22)]
        public void ChangeParams_ShouldChangeParamsAccordingToPattern(double height, double depth, double r)
        {
            ChangeParams change = new();
            double result= change.MatchParams(height, depth).Result;

            //There is probably some sort of cut error 
            Assert.Equal(r.ToString(), result.ToString());
        }
    }
}
