using Logic.Model;
using Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Calculation : ICalculation
    {

        public ISingleComposition SingleComposition { get; set; }
        public IStairs StairsProcessor { get; set; }
        public IMaxHeight HeightProcessor { get; set; }
        public IMultiComposition MultiComposition { get; set; }
        public IMaxWidth WidthProcessor { get; set; }
        public IDepthCalculations DepthCalculations { get; set; }

        public Calculation(ISingleComposition singleComposition, IStairs stairsProcessor,
            IMaxHeight heightProcessor, IMultiComposition multiComposition, IMaxWidth widthProcessor, IDepthCalculations depthCalculations)
        {
            SingleComposition = singleComposition;
            StairsProcessor = stairsProcessor;
            HeightProcessor = heightProcessor;
            MultiComposition = multiComposition;
            WidthProcessor = widthProcessor;
            DepthCalculations = depthCalculations;
        }

        public async Task MainCalculation(CalculationModel model)
        {
            //single composition
            bool singleComposition = await SingleComposition.CheckSingleComposition(model);

            model.AmoutOfStairs = await StairsProcessor.AmountOfStairs(model);
            model.MaxHeight = await HeightProcessor.CheckMaxHeight(model);
            model.Depth = await DepthCalculations.CalculateDepth(model);
            model.MaxWidth = await WidthProcessor.CheckMaxHeight(model);
            if (singleComposition == true)
            {
                model.Landing = false;
            }
            else if (singleComposition == false)
            {
                model.Landing = true;
                model.LandingStairs = await MultiComposition.CalculateLandings(model);
            }
        }
    }
}
