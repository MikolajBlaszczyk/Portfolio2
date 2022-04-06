using Logic.Model;
using System.Threading.Tasks;

namespace Logic
{
    public interface ICalculation
    {
        IMaxHeight HeightProcessor { get; set; }
        IMultiComposition MultiComposition { get; set; }
        ISingleComposition SingleComposition { get; set; }
        IStairs StairsProcessor { get; set; }

        Task MainCalculation(CalculationModel model);
    }
}