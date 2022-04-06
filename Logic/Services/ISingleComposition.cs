using Logic.Model;
using System.Threading.Tasks;

namespace Logic
{
    public interface ISingleComposition
    {
        IStairs StairsProcessor { get; set; }

        Task<bool> CheckSingleComposition(CalculationModel input);
        Task<bool> LevelValidation(decimal maxHeight, decimal floorHeight);
    }
}