using Logic.Model;
using Logic.Services;
using Logic.Services.Change;
using System.Threading.Tasks;

namespace Logic
{
    public interface ICalculation
    {
        IChangeParams ChangeParams { get; set; }
        IDepthCalculations DepthCalculations { get; set; }
        IMaxHeight HeightProcessor { get; set; }
        IMultiComposition MultiComposition { get; set; }
        ISingleComposition SingleComposition { get; set; }
        IStairs StairsProcessor { get; set; }
        IMaxWidth WidthProcessor { get; set; }

        Task MainCalculation(CalculationModel model, bool change, double maxHeight, double minWidth, double depth);
    }
}