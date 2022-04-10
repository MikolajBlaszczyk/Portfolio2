using Logic.Model;
using Logic.Services;
using Logic.Services.Change;
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
        public IChangeParams ChangeParams { get; set; }

        public Calculation(ISingleComposition singleComposition, IStairs stairsProcessor,
            IMaxHeight heightProcessor, IMultiComposition multiComposition, IMaxWidth widthProcessor,
            IDepthCalculations depthCalculations, IChangeParams changeParams)
        {
            SingleComposition = singleComposition;
            StairsProcessor = stairsProcessor;
            HeightProcessor = heightProcessor;
            MultiComposition = multiComposition;
            WidthProcessor = widthProcessor;
            DepthCalculations = depthCalculations;
            ChangeParams = changeParams;
        }

        public async Task MainCalculation(CalculationModel model, bool change, double maxHeight, double minWidth, double depth)
        {
            //single composition
            bool singleComposition = await SingleComposition.CheckSingleComposition(model);

            model.AmoutOfStairs = await StairsProcessor.AmountOfStairs(model);
            if (change == false)
            {
                model.MaxHeight = await HeightProcessor.CheckMaxHeight(model);
                model.Depth = await DepthCalculations.CalculateDepth(model);
                model.MinWidth = await WidthProcessor.CheckMaxWidth(model);
            }
            else if (change == true)
            {
                model.MaxHeight = maxHeight;
                model.MinWidth = minWidth;
                model.Depth = await ChangeParams.MatchParams(maxHeight, depth);
            }

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
