using Xunit;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Model;
using Logic.Services;
using Logic.Services.Change;

namespace Logic.Tests
{
    public class CalculationTests
    {
        public Calculation Processor { get; set; }

        public CalculationTests()
        {
            
            Stairs stairs = new();
            SingleComposition comp = new(stairs);
            MaxHeight heightPr = new();
            MultiComposition multiComp = new();
            MaxWidth widthPr = new();
            DepthCalculations depth = new();
            ChangeParams changeParams = new();
            Calculation processor = new(comp, stairs, heightPr, multiComp, widthPr , depth, changeParams);
            Processor = processor;
        }
        //amount of stairs
        [Theory]
        [InlineData(3)]
        public async Task MainCalculation_ShouldCalculateAmountOfStairsForDH(double height)
        {
            CalculationModel model = new();
           
            model.DetachedHouse = true;
            model.MultiFamilyHouse = false;
            model.Kindergarten = false;
            model.HealthCareBuilding = false;
            model.Garage = false;
            model.Underground = false;
            model.FloorHeight = height;
            await Processor.MainCalculation(model, false, 0 ,0, 0);
            Assert.Equal(model.AmoutOfStairs.ToString(), "16");
        }
        [Theory]
        [InlineData(3, "18")]
        public async Task MainCalculation_ShouldCalculateAmountOfStairsForMFH(double height,string result)
        {
            CalculationModel model = new();
            model.DetachedHouse = false;
            model.MultiFamilyHouse = true;
            model.Kindergarten = false;
            model.HealthCareBuilding = false;
            model.Garage = false;
            model.Underground = false;
            model.FloorHeight = height;
            await Processor.MainCalculation(model, false, 0, 0, 0);
            Assert.Equal(model.AmoutOfStairs.ToString(), result);
        }
        [Theory]
        [InlineData(3, "20")]
        public async Task MainCalculation_ShouldCalculateAmountOfStairsForK(double height, string result)
        {
            CalculationModel model = new();
            model.DetachedHouse = false;
            model.MultiFamilyHouse = false;
            model.Kindergarten = true;
            model.HealthCareBuilding = false;
            model.Garage = false;
            model.Underground = false;
            model.FloorHeight = height;
            await Processor.MainCalculation(model, false, 0, 0, 0);
            Assert.Equal(model.AmoutOfStairs.ToString(), result);
        }
        [Theory]
        [InlineData(3, "15")]
        public async Task MainCalculation_ShouldCalculateAmountOfStairsForU(double height, string result)
        {
            CalculationModel model = new();
            model.DetachedHouse = false;
            model.MultiFamilyHouse = false;
            model.Kindergarten = false;
            model.HealthCareBuilding =false;
            model.Garage = false;
            model.Underground = true;
            model.FloorHeight = height;
            await Processor.MainCalculation(model, false, 0, 0, 0);
            Assert.Equal(model.AmoutOfStairs.ToString(), result);
        }

        [Theory]
        [InlineData(3)]
        public async Task MainCalculation_ShouldInformIfSingleCompositionCanBeDoneForDH(double height)
        {
            CalculationModel model = new();
            model.DetachedHouse =  true;
            model.MultiFamilyHouse = false;
            model.Kindergarten = false;
            model.HealthCareBuilding = false;
            model.Garage = false;
            model.Underground = false;
            model.FloorHeight = height;

            await Processor.MainCalculation(model, false, 0, 0, 0);
            Assert.False(model.Landing);
        }
        [Theory]
        [InlineData(3)]
        public async Task MainCalculation_ShouldInformIfSingleCompositionCanBeDoneForMFH(double height)
        {
            CalculationModel model = new();
            model.DetachedHouse = false;
            model.MultiFamilyHouse = true;
            model.Kindergarten = false;
            model.HealthCareBuilding = false;
            model.Garage = false;
            model.Underground = false;
            model.FloorHeight = height;

            await Processor.MainCalculation(model, false, 0, 0, 0);
            Assert.True(model.Landing);
        }
        [Theory]
        [InlineData(4)]
        public async Task MainCalculation_ShouldGiveNumbersOfLanding4(double height)
        {
            CalculationModel model = new();
            model.DetachedHouse = true;
            model.MultiFamilyHouse = false;
            model.Kindergarten = false;
            model.HealthCareBuilding = false;
            model.Garage = false;
            model.Underground = false;
            model.FloorHeight = height;

            await Processor.MainCalculation(model, false, 0, 0, 0);
            Assert.Equal(model.LandingStairs.Count().ToString(), "1");
        }
        [Theory]
        [InlineData(8)]
        public async Task MainCalculation_ShouldGiveNumbersOfLanding8(double height)
        {
            CalculationModel model2 = new();
            model2.DetachedHouse = true;
            model2.MultiFamilyHouse = true;
            model2.Kindergarten = false;
            model2.HealthCareBuilding = false;
            model2.Garage = false;
            model2.Underground = false;
            model2.FloorHeight = height;

            await Processor.MainCalculation(model2, false, 0, 0, 0);
            Assert.Equal(model2.LandingStairs.Count().ToString(), "2");
        }
        [Theory]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(3.3)]
        public async Task MainCalculation_ShouldGiveExactNumberOfLanding(double height)
        {
            CalculationModel model2 = new();
            model2.DetachedHouse = true;
            model2.MultiFamilyHouse = true;
            model2.Kindergarten = false;
            model2.HealthCareBuilding = false;
            model2.Garage = false;
            model2.Underground = false;
            model2.FloorHeight = height;

            await Processor.MainCalculation(model2, false, 0, 0, 0);
            Assert.Equal(model2.LandingStairs[0].ToString(), (model2.AmoutOfStairs/2).ToString());
        }
    }


}